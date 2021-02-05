using PrefabGenerator;
using UniPresentation.Cameras;
using UniPresentation.TouchBlock;
using UnityEngine;

namespace UniPresentation.Canvases
{
    public abstract class CanvasBase : PrefabBase, ICanvas
    {
        public abstract void SetCamera(ICamera targetCamera);
        public abstract Camera GetCamera();
        public abstract Transform GetTransform();

        public abstract void SetActiveTouchBlockWindow(bool isActive);

        public abstract bool IsTouchBlockEnabled();
        public abstract void SetTouchBlockPresenter(UITouchBlockPresenter presenter);
    }
}