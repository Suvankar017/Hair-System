using UnityEditor;
using UnityEngine;

namespace HairSystem.EditorTools.Authoring.Roots.Utilities
{
    public static class HairRootHandleUtility
    {
        public static Vector3 GetMouseWorldPosition()
        {
            Ray ray =
                HandleUtility.GUIPointToWorldRay(
                    Event.current.mousePosition);

            Plane plane =
                new Plane(
                    Vector3.forward,
                    Vector3.zero);

            if (!plane.Raycast(
                ray,
                out float distance))
            {
                return Vector3.zero;
            }

            return ray.GetPoint(
                distance);
        }
    }
}