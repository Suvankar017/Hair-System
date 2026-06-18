using UnityEngine;
using PerformantHairSystem.Core;
using PerformantHairSystem.Data;

namespace PerformantHairSystem.Simulation
{
    public static class VerletSolver
    {
        public static void Simulate(
            HairWorld world,
            float gravity,
            float damping,
            float dt)
        {
            Vector2 gravityForce =
                dt * gravity * Vector2.down;

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

                bool dirty = false;

                for (int i = 1;
                     i < length;
                     i++)
                {
                    int p = start + i;

                    Vector2 current =
                        world.Position[p];

                    Vector2 velocity =
                        current -
                        world.PreviousPosition[p];

                    velocity *= damping;

                    world.Position[p] += velocity;

                    world.Position[p] += gravityForce;

                    world.PreviousPosition[p] =
                        current;

                    if (velocity.sqrMagnitude >
                        0.0000001f)
                    {
                        dirty = true;
                    }
                }

                if (dirty)
                {
                    world.Flags[strand] |= StrandFlags.Dirty;
                    //StrandFlagUtility.Add(world, strand, StrandFlags.Dirty);

                    HairWorldDirtyUtility.MarkDirty(world, strand);
                }
            }
        }
    }
}