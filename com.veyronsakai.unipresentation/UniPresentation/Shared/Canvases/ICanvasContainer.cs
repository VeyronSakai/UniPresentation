using System.Collections.Generic;

namespace UniPresentation.Shared.Canvases
{
    public interface ICanvasContainer
    {
        List<ICanvas> Canvases { get; }
    }
}