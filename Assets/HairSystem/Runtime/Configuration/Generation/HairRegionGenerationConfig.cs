using UnityEngine;

namespace HairSystem.Configuration.Generation
{
    [System.Serializable]
    public sealed class HairRegionGenerationConfig
    {
        [SerializeField]
        private bool _enabled = true;

        [SerializeField]
        [Min(0)]
        private int _strandCount = 100;

        [SerializeField]
        [Min(2)]
        private int _pointCount = 8;

        [SerializeField]
        [Min(0f)]
        private float _minimumLength = 0.1f;

        [SerializeField]
        [Min(0f)]
        private float _maximumLength = 2f;

        [SerializeField]
        [Min(0f)]
        private float _defaultRootWidth = 0.08f;

        [SerializeField]
        [Min(0f)]
        private float _defaultTipWidth = 0.02f;

        [SerializeField]
        private Color32 _defaultColor = new(40, 20, 10, 255);

        [SerializeField]
        private AnimationCurve _widthProfile = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
        }

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

        public float MinimumLength
        {
            get
            {
                return _minimumLength;
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

        public Color32 DefaultColor
        {
            get
            {
                return _defaultColor;
            }
        }

        public AnimationCurve WidthProfile
        {
            get
            {
                return _widthProfile;
            }
        }


        public float LengthRange
        {
            get
            {
                return _maximumLength - _minimumLength;
            }
        }
    }
}