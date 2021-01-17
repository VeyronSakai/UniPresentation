using System.Collections.Generic;
using PrefabGenerator;
using UniPresentation.Cameras;
using UniPresentation.Presenter;
using UniPresentation.TouchBlock;
using UnityEngine;

namespace UniPresentation.Canvases
{
    public static class CanvasBuilder
    {
        public static CanvasContainer BuildCanvases(ICamera renderCamera, CanvasPathParams canvasPathParams,
            string touchBlockPrefabPath, Transform rootTransform)
        { 
            var canvasList = new List<ICanvas>();
            
            foreach (var canvasPath in canvasPathParams.CanvasPaths)
            {
                var canvas = CreateCanvas(renderCamera, rootTransform, canvasPath, touchBlockPrefabPath);
                canvasList.Add(canvas);
            }
            
            return new CanvasContainer(canvasList);
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