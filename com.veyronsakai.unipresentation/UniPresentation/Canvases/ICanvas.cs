using UnityEngine;

namespace UniPresentation.Canvases
{
    public interface ICanvas
    {
        Transform GetTransform();
        void SetActiveTouchBlockWindow(bool isActive);
        bool IsTouchBlockEnabled();
    }
}
