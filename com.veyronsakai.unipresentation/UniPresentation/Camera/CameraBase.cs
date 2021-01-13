using PrefabGenerator;

namespace UniPresentation.Camera
{
    public abstract class CameraBase : PrefabBase, ICamera
    {
        public abstract UnityEngine.Camera GetRawCamera();
    }
}