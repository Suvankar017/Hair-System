using UnityEngine;
using PerformantHairSystem.Core;
using PerformantHairSystem.Data;

namespace PerformantHairSystem.Simulation
{
    public static class DistanceConstraintSolver
    {
        public static void Solve(
            HairWorld world)
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

                for (int i = 0;
                     i < length - 1;
                     i++)
                {
                    int a = start + i;
                    int b = start + i + 1;

                    Vector2 delta =
                        world.Position[b] -
                        world.Position[a];

                    float distance =
                        delta.magnitude;

                    if (distance < 0.00001f)
                        continue;

                    float error =
                        distance -
                        segmentLength;

                    Vector2 correction =
                        delta.normalized *
                        error;

                    if (i == 0)
                    {
                        world.Position[b] -=
                            correction;
                    }
                    else
                    {
                        correction *= 0.5f;

                        world.Position[a] +=
                            correction;

                        world.Position[b] -=
                            correction;
                    }
                }

                world.Position[start] =
                    world.RootPosition[strand];

                world.PreviousPosition[start] =
                    world.RootPosition[strand];
            }
        }
    }
}