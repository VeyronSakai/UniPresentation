using UniPresentation.Camera;
using UniPresentation.Canvases;

namespace UniPresentation.Hierarchy
{
    public class Hierarchy
    {
        public CanvasContainer CanvasContainer;
        public ICamera Camera;

        public Hierarchy(CanvasContainer canvasContainer, ICamera camera)
        {
            CanvasContainer = canvasContainer;
            Camera = camera;
        }
    }
}