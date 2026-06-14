using UnityEngine;

namespace HairSystem.Configuration.Physics
{
    [CreateAssetMenu(
        fileName = "HairPhysicsConfig",
        menuName = "Hair System/Physics Config")]
    public sealed class HairPhysicsConfig
        : ScriptableObject
    {
        [Header("Simulation")]
        [SerializeField]
        private Vector2 _gravity = new(0f, -9.81f);

        [SerializeField]
        [Range(0f, 1f)]
        private float _damping = 0.98f;

        [SerializeField]
        [Min(1)]
        private int _constraintIterations = 4;

        [Header("Shape Memory")]
        [SerializeField]
        [Range(0f, 1f)]
        private float _shapeMemoryStrength = 0.25f;

        [Header("Sleeping")]
        [SerializeField]
        [Min(0f)]
        private float _sleepThreshold = 0.001f;

        [SerializeField]
        [Min(0f)]
        private float _wakeThreshold = 0.005f;

        [Header("Timing")]
        [SerializeField]
        [Min(0.001f)]
        private float _maxSimulationStep = 0.033333f;

        [Header("Region Multipliers")]
        [SerializeField]
        private HairRegionPhysicsMultiplierConfig _head = new();

        [SerializeField]
        private HairRegionPhysicsMultiplierConfig _beard = new();

        [SerializeField]
        private HairRegionPhysicsMultiplierConfig _mustache = new();

        public Vector2 Gravity
        {
            get
            {
                return _gravity;
            }
        }

        public float Damping
        {
            get
            {
                return _damping;
            }
        }

        public int ConstraintIterations
        {
            get
            {
                return _constraintIterations;
            }
        }

        public float ShapeMemoryStrength
        {
            get
            {
                return _shapeMemoryStrength;
            }
        }

        public float SleepThreshold
        {
            get
            {
                return _sleepThreshold;
            }
        }

        public float WakeThreshold
        {
            get
            {
                return _wakeThreshold;
            }
        }

        public float MaxSimulationStep
        {
            get
            {
                return _maxSimulationStep;
            }
        }

        public HairRegionPhysicsMultiplierConfig Head
        {
            get
            {
                return _head;
            }
        }

        public HairRegionPhysicsMultiplierConfig Beard
        {
            get
            {
                return _beard;
            }
        }

        public HairRegionPhysicsMultiplierConfig Mustache
        {
            get
            {
                return _mustache;
            }
        }
    }
}