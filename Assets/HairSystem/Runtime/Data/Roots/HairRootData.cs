using UnityEngine;

namespace HairSystem.Data.Roots
{
    [System.Serializable]
    public struct HairRootData
    {
        public Vector2 LocalPosition;

        public Vector2 Direction;

        public HairRootData(
            Vector2 localPosition,
            Vector2 direction)
        {
            LocalPosition =
                localPosition;

            Direction =
                direction.normalized;
        }
    }
}