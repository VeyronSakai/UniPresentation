using PrefabGenerator;
using UnityEngine;

namespace UniPresentation.Cameras
{
    public abstract class CameraBase : PrefabBase, ICamera
    {
        private Camera _rawCamera;

        public Camera GetRawCamera()
        {
            if (_rawCamera == null)
            {
                _rawCamera = GetComponent<Camera>();
            }

            return _rawCamera;
        }
    }
}