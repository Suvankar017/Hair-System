using UnityEngine;

namespace PerformantHairSystem.Authoring
{
    public class HairRootPoint : MonoBehaviour
    {
        [Header("Strand")]

        public int ParticleCount = 16;

        public float SegmentLength = 0.12f;

        [Header("Thickness")]

        public float RootThickness = 0.08f;

        public float TipThickness = 0.02f;

        [Header("Color")]

        public Color RootColor =
            new(0.25f, 0.18f, 0.12f);

        [Header("Rendering")]

        public byte LayerId;

        public byte StyleId;

        public Vector2 RootPosition =>
            transform.position;

        public Vector2 RootDirection =>
            transform.up.normalized;
    }
}