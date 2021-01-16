using PrefabGenerator;

namespace UniPresentation.Cameras
{
    public abstract class CameraBase : PrefabBase, ICamera
    {
        public abstract UnityEngine.Camera GetRawCamera();
    }
}