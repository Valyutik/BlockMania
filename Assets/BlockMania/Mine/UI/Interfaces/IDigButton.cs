using System;

namespace BlockMania.Mine.UI
{
    public interface IDigButton
    {
        public event Action OnStartHoldEvent, OnEndHoldEvent;
    }
}