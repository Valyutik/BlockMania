using System;

namespace BlockMania.Mine.UI
{
    public interface IDigButton
    {
        event Action OnPressEvent, OnReleaseEvent;
    }
}