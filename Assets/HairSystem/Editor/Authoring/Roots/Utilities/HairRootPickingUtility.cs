using UnityEngine;
using HairSystem.Data.Roots;

namespace HairSystem.EditorTools.Authoring.Roots.Utilities
{
    public static class HairRootPickingUtility
    {
        public static int FindNearestRoot(
            Transform transform,
            HairRootData[] roots,
            Vector3 mouseWorldPosition,
            float maxDistance)
        {
            int selectedIndex =
                -1;

            float bestDistance =
                maxDistance;

            for (int i = 0;
                 i < roots.Length;
                 i++)
            {
                Vector3 rootPosition =
                    transform.TransformPoint(
                        roots[i].LocalPosition);

                float distance =
                    Vector2.Distance(
                        rootPosition,
                        mouseWorldPosition);

                if (distance >=
                    bestDistance)
                {
                    continue;
                }

                bestDistance =
                    distance;

                selectedIndex =
                    i;
            }

            return selectedIndex;
        }
    }
}