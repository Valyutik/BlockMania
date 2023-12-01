using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BlockMania.Mine.UI
{
    public class Joystick : MonoBehaviour, IPointerDownHandler,
        IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IJoystick
    {
        public event Action<float, float> OnDragEvent;
        public event Action OnBeginDragEvent, OnEndDragEvent;
        
        [SerializeField] private float handleRange = 1;
        [SerializeField] private float deadZone;
        [SerializeField] private AxisOptions axisOptions = AxisOptions.Both;
        [SerializeField] private bool snapX;
        [SerializeField] private bool snapY;
        [SerializeField] protected RectTransform background;
        [SerializeField] private RectTransform handle;
        private RectTransform baseRect;
        private Canvas canvas;
        private Camera cam;
        private Vector2 input = Vector2.zero;
        private float Horizontal => snapX ? SnapFloat(input.x, AxisOptions.Horizontal) : input.x;
        private float Vertical => snapY ? SnapFloat(input.y, AxisOptions.Vertical) : input.y;

        private float HandleRange
        {
            get => handleRange;
            set => handleRange = Mathf.Abs(value);
        }
        private float DeadZone
        {
            get => deadZone;
            set => deadZone = Mathf.Abs(value);
        } 

        public void Initialize()
        {
            HandleRange = handleRange;
            DeadZone = deadZone;
            baseRect = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");

            var center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
        }

        public void UpdatePass()
        {
            OnDragEvent?.Invoke(Vertical, Horizontal);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            cam = null;
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
                cam = canvas.worldCamera;

            var position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
            var radius = background.sizeDelta / 2;
            input = (eventData.position - position) / (radius * canvas.scaleFactor);
            FormatInput();
            HandleInput(input.magnitude, input.normalized);
            handle.anchoredPosition = input * radius * handleRange;
            OnDragEvent?.Invoke(Vertical, Horizontal);
        }

        private void HandleInput(float magnitude, Vector2 normalised)
        {
            if (magnitude > deadZone)
            {
                if (magnitude > 1)
                    input = normalised;
            }
            else
                input = Vector2.zero;
        }

        private void FormatInput()
        {
            input = axisOptions switch
            {
                AxisOptions.Horizontal => new Vector2(input.x, 0f),
                AxisOptions.Vertical => new Vector2(0f, input.y),
                _ => input
            };
        }

        private float SnapFloat(float value, AxisOptions snapAxis)
        {
            if (value == 0)
                return value;

            if (axisOptions != AxisOptions.Both)
                return value switch
                {
                    > 0 => 1,
                    < 0 => -1,
                    _ => 0
                };
            var angle = Vector2.Angle(input, Vector2.up);
            return snapAxis switch
            {
                AxisOptions.Horizontal when angle is < 22.5f or > 157.5f => 0,
                AxisOptions.Horizontal => (value > 0) ? 1 : -1,
                AxisOptions.Vertical when angle is > 67.5f and < 112.5f => 0,
                AxisOptions.Vertical => (value > 0) ? 1 : -1,
                _ => value
            };
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
        }

        protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, screenPosition, cam, out var localPoint))
                return Vector2.zero;
            Vector2 sizeDelta;
            var pivotOffset = baseRect.pivot * (sizeDelta = baseRect.sizeDelta);
            return localPoint - (background.anchorMax * sizeDelta) + pivotOffset;
        }

        public void OnBeginDrag(PointerEventData eventData) => OnBeginDragEvent?.Invoke();

        public void OnEndDrag(PointerEventData eventData) => OnEndDragEvent?.Invoke();
    }

    public enum AxisOptions { Both, Horizontal, Vertical }
}