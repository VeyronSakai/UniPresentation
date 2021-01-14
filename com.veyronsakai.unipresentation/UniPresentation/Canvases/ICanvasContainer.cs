using System.Collections.Generic;

namespace UniPresentation.Canvases
{
    public interface ICanvasContainer
    {
        List<ICanvas> Canvases { get; }
    }
}