using UniPresentation.Camera;
using UniPresentation.Canvases;

namespace UniPresentation.Hierarchy
{
    public class Hierarchy
    {
        public ICanvasContainer CanvasContainer;
        public ICamera Camera;

        public Hierarchy(ICanvasContainer canvasContainer, ICamera camera)
        {
            CanvasContainer = canvasContainer;
            Camera = camera;
        }
    }
}