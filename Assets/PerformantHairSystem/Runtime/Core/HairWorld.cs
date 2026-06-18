using UnityEngine;
using PerformantHairSystem.Data;

namespace PerformantHairSystem.Core
{
    public sealed class HairWorld
    {
        //---------------------------------
        // Capacity
        //---------------------------------

        public int MaxStrands;

        public int MaxParticlesPerStrand;

        public int ParticleCapacity;

        //---------------------------------
        // Runtime Counts
        //---------------------------------

        public int StrandCount;

        //---------------------------------
        // Strand Data
        //---------------------------------

        public int[] StrandStart;

        public ushort[] StrandLength;

        public Vector2[] RootPosition;

        public Vector2[] RootDirection;

        public float[] SegmentLength;

        public byte[] LayerId;

        public byte[] StrandStyleId;

        public float[] HoldStrength;

        public float[] Stiffness;

        public float[] Shine;

        public float[] SleepTimer;

        public StrandFlags[] Flags;

        public uint[] StrandVersion;

        //---------------------------------
        // Particle Data
        //---------------------------------

        public Vector2[] Position;

        public Vector2[] PreviousPosition;

        public Vector2[] PoseDirection;

        public float[] Thickness;

        public Color32[] Color;

        //---------------------------------
        // World Version
        //---------------------------------

        public uint SimulationVersion;
    }
}
