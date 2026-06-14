using UnityEngine;

namespace HairSystem.Data.Points
{
    [System.Serializable]
    public struct HairPointData
    {
        public Vector2 Position;

        public Vector2 PreviousPosition;

        public Vector2 RestPosition;

        public float Width;

        public Color32 Color;

        public HairPointData(
            Vector2 position,
            float width,
            Color32 color)
        {
            Position =
                position;

            PreviousPosition =
                position;

            RestPosition =
                position;

            Width =
                width;

            Color =
                color;
        }
    }
}