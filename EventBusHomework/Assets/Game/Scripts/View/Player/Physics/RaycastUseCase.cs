using UnityEngine;

namespace SampleGame
{
    public static class RaycastUseCase
    {
        public static bool RaycastGround(Camera camera, Vector2 screenPosition, out Vector3 point)
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.CompareTag("Ground"))
            {
                point = hit.point;
                return true;
            }

            point = default;
            return false;
        }

        public static bool RaycastTarget<T>(Camera camera, Vector2 screenPosition, out T target)
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.TryGetComponent(out target))
                return true;

            target = default;
            return false;
        }

        public static Collider[] ScanTargets(Vector3 position, float radius)
        {
            return Physics.OverlapSphere(position, radius, Physics.AllLayers, QueryTriggerInteraction.UseGlobal);
        }
    }
}