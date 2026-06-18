using UnityEngine;
using PerformantHairSystem.Data;

namespace PerformantHairSystem.Core
{
    public static class HairWorldFactory
    {
        public static HairWorld Create(
            int maxStrands,
            int maxParticlesPerStrand)
        {
            int particleCapacity =
                maxStrands *
                maxParticlesPerStrand;

            return new HairWorld
            {
                MaxStrands = maxStrands,

                MaxParticlesPerStrand =
                    maxParticlesPerStrand,

                ParticleCapacity =
                    particleCapacity,

                //---------------------------------
                // Strand
                //---------------------------------

                StrandStart =
                    new int[maxStrands],

                StrandLength =
                    new ushort[maxStrands],

                RootPosition =
                    new Vector2[maxStrands],

                RootDirection =
                    new Vector2[maxStrands],

                SegmentLength =
                    new float[maxStrands],

                LayerId =
                    new byte[maxStrands],

                StrandStyleId =
                    new byte[maxStrands],

                HoldStrength =
                    new float[maxStrands],

                Stiffness =
                    new float[maxStrands],

                Shine =
                    new float[maxStrands],

                SleepTimer =
                    new float[maxStrands],

                Flags =
                    new StrandFlags[maxStrands],

                StrandVersion =
                    new uint[maxStrands],

                //---------------------------------
                // Particle
                //---------------------------------

                Position =
                    new Vector2[particleCapacity],

                PreviousPosition =
                    new Vector2[particleCapacity],

                PoseDirection =
                    new Vector2[particleCapacity],

                Thickness =
                    new float[particleCapacity],

                Color =
                    new Color32[particleCapacity]
            };
        }
    }
}