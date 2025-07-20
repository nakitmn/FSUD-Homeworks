using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class RaycastUseCase
    {
        /*public static bool RaycastPlaneGround(in IGameContext gameContext,
            Vector2 screenPosition, out Vector3 point)
        {
            var plane = gameContext.GetGroundPlane();
            Ray ray = gameContext.GetCamera().ScreenPointToRay(screenPosition);

            if (plane.Raycast(ray, out var distance))
            {
                point = ray.GetPoint(distance);
                return true;
            }

            point = default;
            return false;
        }*/

        public static bool RaycastGround(in IGameContext context, Vector2 screenPosition, out Vector3 point)
        {
            Ray ray = context.GetCamera().ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.CompareTag("Ground"))
            {
                point = hit.point;
                return true;
            }

            point = default;
            return false;
        }

        public static bool RaycastTarget<T>(in IGameContext context, Vector2 screenPosition, out T target)
        {
            Ray ray = context.GetCamera().ScreenPointToRay(screenPosition);
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