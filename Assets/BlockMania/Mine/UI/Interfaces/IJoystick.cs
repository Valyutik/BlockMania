using System;

namespace BlockMania.Mine.UI
{
    public interface IJoystick
    {
        event Action<float, float> OnDragEvent;
        event Action OnBeginDragEvent, OnEndDragEvent;
    }
}