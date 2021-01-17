using PrefabGenerator;
using UnityEngine;

namespace UniPresentation.Cameras
{
    public sealed class CameraBuilder
    {
        public static ICamera BuildCamera<T>(string cameraPrefabPath, Transform parentTransform) where T : CameraBase
        {
            var camera = PrefabFactory.Create<T>(cameraPrefabPath, parentTransform);
            return camera;
        }
    }
}