using System.Collections.Generic;

namespace UniPresentation.Canvases
{
    public class CanvasContainer
    {
        public List<ICanvas> Canvases { get; }

        public CanvasContainer(List<ICanvas> canvases)
        {
            Canvases = canvases;
        }
    }
}