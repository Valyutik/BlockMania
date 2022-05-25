using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BlockMania.Mine.UI
{
    public abstract class BaseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnPressEvent, OnReleaseEvent;

        public virtual void Initialize()
        {
            
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnPressEvent?.Invoke();
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            OnReleaseEvent?.Invoke();
        }
    }
}