using UnityEngine;

namespace HairSystem.Configuration.Physics
{
    [System.Serializable]
    public sealed class HairRegionPhysicsMultiplierConfig
    {
        [SerializeField]
        [Min(0f)]
        private float _lengthMultiplier = 1f;

        [SerializeField]
        [Min(0f)]
        private float _stiffnessMultiplier = 1f;

        [SerializeField]
        [Min(0f)]
        private float _gravityMultiplier = 1f;

        [SerializeField]
        [Min(0f)]
        private float _dampingMultiplier = 1f;

        public float LengthMultiplier
        {
            get
            {
                return _lengthMultiplier;
            }
        }

        public float StiffnessMultiplier
        {
            get
            {
                return _stiffnessMultiplier;
            }
        }

        public float GravityMultiplier
        {
            get
            {
                return _gravityMultiplier;
            }
        }

        public float DampingMultiplier
        {
            get
            {
                return _dampingMultiplier;
            }
        }
    }
}