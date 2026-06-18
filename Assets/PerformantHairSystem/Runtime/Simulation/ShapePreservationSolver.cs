using UnityEngine;
using PerformantHairSystem.Core;
using PerformantHairSystem.Data;

namespace PerformantHairSystem.Simulation
{
    public static class ShapePreservationSolver
    {
        public static void Solve(
            HairWorld world,
            float strength)
        {
            for (int strand = 0;
                 strand < world.StrandCount;
                 strand++)
            {
                if ((world.Flags[strand] & StrandFlags.Sleeping) != 0)
                {
                    continue;
                }

                int start =
                    world.StrandStart[strand];

                int length =
                    world.StrandLength[strand];

                float segmentLength =
                    world.SegmentLength[strand];

                for (int i = 1;
                     i < length;
                     i++)
                {
                    int parent =
                        start + i - 1;

                    int current =
                        start + i;

                    Vector2 desired =
                        world.Position[parent] +
                        world.PoseDirection[current] *
                        segmentLength;

                    world.Position[current] =
                        Vector2.Lerp(
                            world.Position[current],
                            desired,
                            strength);
                }
            }
        }
    }
}