using PerformantHairSystem.Core;

namespace PerformantHairSystem.Authoring
{
    public static class HairWorldBaker
    {
        public static HairWorld Build(
            HairRootContainer rootContainer,
            int maxParticlesPerStrand = 24)
        {
            HairRootPoint[] roots =
                rootContainer
                    .GetComponentsInChildren<
                        HairRootPoint>();

            HairWorld world =
                HairWorldFactory.Create(
                    roots.Length,
                    maxParticlesPerStrand);

            HairWorldBuilder builder =
                new HairWorldBuilder(world);

            for (int i = 0; i < roots.Length; i++)
            {
                HairRootPoint root =
                    roots[i];

                int strand =
                    builder.AddStrand(
                        root.RootPosition,
                        root.RootDirection,
                        root.ParticleCount,
                        root.SegmentLength,
                        root.RootThickness,
                        root.TipThickness,
                        root.RootColor,
                        root.LayerId,
                        root.StyleId);

            }

            return world;
        }
    }
}