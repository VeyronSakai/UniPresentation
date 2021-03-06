using UniPresentation.Cameras;
using UniPresentation.TouchBlock;
using UnityEngine;

namespace UniPresentation.Canvases
{
    public interface ICanvas
    {
        void SetCamera(ICamera targetCamera);
        Camera GetCamera();
        Transform GetTransform();
        void SetActiveTouchBlockWindow(bool isActive);
        bool IsTouchBlockEnabled();
        void SetTouchBlockPresenter(UITouchBlockPresenter presenter);
    }
}