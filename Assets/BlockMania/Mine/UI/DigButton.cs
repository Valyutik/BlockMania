using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BlockMania.Mine.UI
{
    public class DigButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDigButton
    {
        public event Action OnStartHoldEvent, OnEndHoldEvent;

        public void Initialize()
        {
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnStartHoldEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnEndHoldEvent?.Invoke();
        }

    }
}