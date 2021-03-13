using PrefabGenerator;
using UniPresentation.Cameras;
using UniPresentation.TouchBlock;
using UnityEngine;

namespace UniPresentation.Canvases
{
    public abstract class CanvasBase : PrefabBase, ICanvas
    {
        private Transform _canvasTransform;
        private Canvas _rawCanvas;
        private UITouchBlockPresenter _touchBlockPresenter;
        private ICamera _targetCamera;

        public void SetCamera(ICamera targetCamera)
        {
            if (_rawCanvas == null) _rawCanvas = GetComponent<UnityEngine.Canvas>();

            _targetCamera = targetCamera;

            _rawCanvas.worldCamera = targetCamera.GetRawCamera();
        }

        public Camera GetCamera()
        {
            return _targetCamera.GetRawCamera();
        }

        public Transform GetTransform()
        {
            if (_canvasTransform == null) _canvasTransform = transform;

            return _canvasTransform;
        }

        public void SetActiveTouchBlockWindow(bool isActive)
        {
            _touchBlockPresenter.SetActiveView(isActive);
        }

        public bool IsTouchBlockEnabled()
        {
            return _touchBlockPresenter.IsViewActive();
        }

        public void SetTouchBlockPresenter(UITouchBlockPresenter presenter)
        {
            _touchBlockPresenter = presenter;
        }

        public void OnDestroy()
        {
            if (_touchBlockPresenter != null)
            {
                _touchBlockPresenter.Dispose();
                _touchBlockPresenter = null;
            }
        }
    }
}