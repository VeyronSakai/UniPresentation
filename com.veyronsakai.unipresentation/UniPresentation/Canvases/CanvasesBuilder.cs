using System.Collections.Generic;
using PrefabGenerator;
using UniPresentation.Camera;
using UniPresentation.Presenter;
using UniPresentation.TouchBlock;
using UnityEngine;

namespace UniPresentation.Canvases
{
    public sealed class CanvasesBuilder
    {
        private readonly Transform _parentTransform;
        private CanvasContainer _canvasContainer;
        private readonly List<ICanvas> _canvasList = new List<ICanvas>();

        public CanvasesBuilder(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public CanvasContainer BuildCanvases(ICamera renderCamera, CanvasPathParams canvasPathParams,
            string touchBlockPrefabPath)
        {
            var canvasRoot = EmptyObjectFactory.Create(canvasPathParams.CanvasRootName, _parentTransform);
            var rootTransform = canvasRoot.transform;

            foreach (var canvasPath in canvasPathParams.CanvasPaths)
            {
                var canvas = CreateCanvas(renderCamera, rootTransform, canvasPath, touchBlockPrefabPath);
                _canvasList.Add(canvas);
            }
            
            _canvasContainer = new CanvasContainer(_canvasList);

            return _canvasContainer;
        }

        private static ICanvas CreateCanvas(ICamera renderCamera, Transform rootTransform, string canvasPrefabPath,
            string touchBlockPrefabPath)
        {
            var canvas = PrefabFactory.Create<CanvasBase>(canvasPrefabPath, rootTransform);
            canvas.SetCamera(renderCamera);
            var touchBlockPresenter = CreateTouchBlockPresenter(canvas, touchBlockPrefabPath);
            canvas.SetTouchBlockPresenter(touchBlockPresenter);
            return canvas;
        }

        private static UITouchBlockPresenter CreateTouchBlockPresenter(ICanvas canvas,
            string touchBlockWindowPrefabPath)
        {
            var touchBlockPrefabParams = PrefabGenParamsFactory.Create(canvas, touchBlockWindowPrefabPath);
            var touchBlockPresenter =
                PresenterFactory<UITouchBlockPresenter, UITouchBlockWindow>.Create(touchBlockPrefabParams);
            return touchBlockPresenter;
        }
    }
}