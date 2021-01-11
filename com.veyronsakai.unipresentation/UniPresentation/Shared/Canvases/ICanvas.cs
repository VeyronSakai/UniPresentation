using UnityEngine;

namespace UniPresentation.Shared.Canvases
{
    public interface ICanvas
    {
        Transform GetTransform();
        void SetActiveTouchBlockWindow(bool isActive);
        bool IsTouchBlockEnabled();
    }
}
