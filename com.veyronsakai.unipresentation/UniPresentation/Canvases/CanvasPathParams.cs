using System.Collections.Generic;

namespace UniPresentation.Canvases
{
    public class CanvasPathParams
    {
        public string CanvasRootName;
        public List<string> CanvasPaths;

        public CanvasPathParams(string canvasRootName, List<string> canvasPaths)
        {
            CanvasRootName = canvasRootName;
            CanvasPaths = canvasPaths;
        }
    }
}