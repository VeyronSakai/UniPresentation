using UniPresentation.Canvases;
using UnityEngine;

namespace UniPresentation.Presenter
{
    /// <summary>
    ///     Prefabを生成する際に必要な情報
    /// </summary>
    public readonly struct PrefabGenParams
    {
        public readonly ICanvas targetCanvas;
        public readonly string PrefabPath;

        public PrefabGenParams(ICanvas canvas, string prefabPath)
        {
            targetCanvas = canvas;
            PrefabPath = prefabPath;
        }

        public Transform GetCanvasTransform()
        {
            return targetCanvas.GetTransform();
        }
    }
}