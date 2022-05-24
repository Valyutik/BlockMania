using System;
using UnityEngine;

namespace BlockMania.Mine.UI
{
    public interface ICameraRotatePanel
    {
        public event Action<Vector3> OnDragEvent;
    }
}