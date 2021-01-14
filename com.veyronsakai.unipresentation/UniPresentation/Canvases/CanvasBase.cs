using PrefabGenerator;
using UnityEngine;

namespace UniPresentation.Canvases
{
    public abstract class CanvasBase : PrefabBase, ICanvas
    {
        public abstract Transform GetTransform();

        public abstract void SetActiveTouchBlockWindow(bool isActive);

        public abstract bool IsTouchBlockEnabled();
    }
}
