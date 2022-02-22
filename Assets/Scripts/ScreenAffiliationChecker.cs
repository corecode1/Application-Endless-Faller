using UnityEngine;

namespace EndlessFaller
{
    public class ScreenAffiliationChecker
    {
        private Camera _camera;
        private Plane[] _cameraPlanes;

        public ScreenAffiliationChecker(Camera camera)
        {
            _camera = camera;
            _cameraPlanes = GeometryUtility.CalculateFrustumPlanes(_camera);
        }

        public bool IsInsideScreen(Vector3 position)
        {
            Vector3 screenPoint = _camera.WorldToScreenPoint(position);
            return Screen.safeArea.Contains(screenPoint);
        }

        public bool IsInsideScreen(Bounds bounds)
        {
            return GeometryUtility.TestPlanesAABB(_cameraPlanes, bounds);
        }
    }
}