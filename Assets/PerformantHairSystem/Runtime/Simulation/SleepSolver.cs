using UnityEngine;
using PerformantHairSystem.Core;
using PerformantHairSystem.Data;

namespace PerformantHairSystem.Simulation
{
    public static class SleepSolver
    {
        public static void Solve(
            HairWorld world,
            float dt)
        {
            for (int strand = 0;
                 strand < world.StrandCount;
                 strand++)
            {
                float maxVelocity = 0f;

                int start =
                    world.StrandStart[strand];

                int length =
                    world.StrandLength[strand];

                for (int i = 1;
                     i < length;
                     i++)
                {
                    int p = start + i;

                    Vector2 velocity =
                        world.Position[p] -
                        world.PreviousPosition[p];

                    maxVelocity =
                        Mathf.Max(
                            maxVelocity,
                            velocity.sqrMagnitude);
                }

                if (maxVelocity < 0.000001f)
                {
                    world.SleepTimer[strand] += dt;

                    if (world.SleepTimer[strand] >
                        0.4f)
                    {
                        world.Flags[strand] |= StrandFlags.Sleeping;
                        //StrandFlagUtility.Add(world, strand, StrandFlags.Sleeping);
                    }
                }
                else
                {
                    world.SleepTimer[strand] = 0f;

                    world.Flags[strand] &= ~StrandFlags.Sleeping;
                    //StrandFlagUtility.Remove(world, strand, StrandFlags.Sleeping);
                }
            }
        }
    }
}