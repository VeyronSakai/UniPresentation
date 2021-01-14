using UniPresentation.Canvases;

namespace UniPresentation.Presenter
{
    public static class PrefabGenParamsFactory
    {
        public static PrefabGenParams Create(ICanvas canvas, string prefabPath)
        {
            return new PrefabGenParams(canvas, prefabPath);
        }
    }
}