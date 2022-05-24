using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BlockMania.Mine.UI
{
    public class CameraRotatePanel : MonoBehaviour, IDragHandler, IPointerDownHandler, ICameraRotatePanel
    {
        public event Action<Vector3> OnDragEvent;

        public void Initialize()
        {
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            var delta = new Vector2(eventData.delta.x, -eventData.delta.y);
            OnDragEvent?.Invoke(delta);
        }

        public void OnPointerDown(PointerEventData eventData) => OnDrag(eventData);
    }
}