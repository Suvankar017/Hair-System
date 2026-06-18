using UnityEngine;

namespace PerformantHairSystem.Core
{
    public sealed class HairWorldBuilder
    {
        private readonly HairWorld world;

        public HairWorldBuilder(
            HairWorld world)
        {
            this.world = world;
        }

        public int AddStrand(
            Vector2 rootPosition,
            Vector2 rootDirection,
            int particleCount,
            float segmentLength,
            float rootThickness,
            float tipThickness,
            Color32 color,
            byte layerId,
            byte styleId)
        {
            int strand =
                world.StrandCount++;

            int start =
                strand *
                world.MaxParticlesPerStrand;

            world.StrandStart[strand] =
                start;

            world.StrandLength[strand] =
                (ushort)particleCount;

            world.RootPosition[strand] =
                rootPosition;

            world.RootDirection[strand] =
                rootDirection;

            world.SegmentLength[strand] =
                segmentLength;

            world.LayerId[strand] =
                layerId;

            world.StrandStyleId[strand] =
                styleId;

            for (int i = 0;
                 i < particleCount;
                 i++)
            {
                int p = start + i;

                float t =
                    i /
                    (float)(particleCount - 1);

                Vector2 pos =
                    rootPosition +
                    i * segmentLength * rootDirection;

                world.Position[p] =
                    pos;

                world.PreviousPosition[p] =
                    pos;

                world.PoseDirection[p] =
                    rootDirection;

                world.Color[p] =
                    color;

                world.Thickness[p] =
                    Mathf.Lerp(
                        rootThickness,
                        tipThickness,
                        t);
            }

            return strand;
        }
    }
}