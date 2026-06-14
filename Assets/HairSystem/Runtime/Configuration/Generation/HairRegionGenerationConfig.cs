using UnityEngine;

namespace HairSystem.Configuration.Generation
{
    [System.Serializable]
    public sealed class HairRegionGenerationConfig
    {
        [SerializeField]
        [Min(0)]
        private int _strandCount = 100;

        [SerializeField]
        [Min(2)]
        private int _pointCount = 8;

        [SerializeField]
        [Min(0f)]
        private float _maximumLength = 2f;

        [SerializeField]
        [Min(0f)]
        private float _defaultRootWidth = 0.08f;

        [SerializeField]
        [Min(0f)]
        private float _defaultTipWidth = 0.02f;

        public int StrandCount
        {
            get
            {
                return _strandCount;
            }
        }

        public int PointCount
        {
            get
            {
                return _pointCount;
            }
        }

        public float MaximumLength
        {
            get
            {
                return _maximumLength;
            }
        }

        public float DefaultRootWidth
        {
            get
            {
                return _defaultRootWidth;
            }
        }

        public float DefaultTipWidth
        {
            get
            {
                return _defaultTipWidth;
            }
        }
    }
}