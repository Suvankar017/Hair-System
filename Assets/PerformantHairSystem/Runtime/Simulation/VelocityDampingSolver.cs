using UnityEngine;
using PerformantHairSystem.Core;
using PerformantHairSystem.Data;

namespace PerformantHairSystem.Simulation
{
    public static class VelocityDampingSolver
    {
        public static void Solve(
            HairWorld world,
            float damping)
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

                for (int i = 1;
                     i < length;
                     i++)
                {
                    int p = start + i;

                    Vector2 velocity =
                        world.Position[p] -
                        world.PreviousPosition[p];

                    velocity *= damping;

                    world.PreviousPosition[p] =
                        world.Position[p] -
                        velocity;
                }
            }
        }
    }
}