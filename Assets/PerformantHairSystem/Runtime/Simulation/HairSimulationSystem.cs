using UnityEngine;
using PerformantHairSystem.Core;

namespace PerformantHairSystem.Simulation
{
    public class HairSimulationSystem : MonoBehaviour
    {
        [SerializeField]
        private HairWorldComponent worldComponent;

        [SerializeField]
        private float gravity = 12f;

        [SerializeField]
        private float damping = 0.98f;

        [SerializeField]
        private float shapeStrength = 0.05f;

        [SerializeField]
        private int constraintIterations = 2;

        private HairWorld world;

        private void Start()
        {
            world = worldComponent.World;
        }

        private void FixedUpdate()
        {
            VerletSolver.Simulate(
                world,
                gravity,
                damping,
                Time.fixedDeltaTime);

            ShapePreservationSolver.Solve(
                world,
                shapeStrength);

            for (int i = 0;
                 i < constraintIterations;
                 i++)
            {
                DistanceConstraintSolver.Solve(
                    world);
            }

            VelocityDampingSolver.Solve(
                world,
                damping);

            SleepSolver.Solve(
                world,
                Time.fixedDeltaTime);

            //UpdateSleeping(Time.fixedDeltaTime);

            //world.SimulationVersion++;
        }

        private void UpdateSleeping(float deltaTime)
        {
            for (int strand = 0; strand < world.StrandCount; strand++)
            {
                if (HairSleepUtility.IsSleeping(world, strand))
                {
                    continue;
                }

                float maxVelocity = 0f;

                int start = world.StrandStart[strand];

                int length = world.StrandLength[strand];

                for (int i = 0; i < length; i++)
                {
                    int p = start + i;

                    Vector2 velocity = world.Position[p] - world.PreviousPosition[p];

                    float speed = velocity.sqrMagnitude;

                    if (speed > maxVelocity)
                    {
                        maxVelocity = speed;
                    }
                }

                if (maxVelocity < 0.000001f)
                {
                    world.SleepTimer[strand] += deltaTime;

                    if (world.SleepTimer[strand] >= 0.35f)
                    {
                        HairSleepUtility.Sleep(world, strand);
                    }
                }
                else
                {
                    world.SleepTimer[strand] = 0f;
                }
            }
        }
    }
}