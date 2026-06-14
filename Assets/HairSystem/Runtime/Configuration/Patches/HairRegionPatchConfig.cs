using UnityEngine;

namespace HairSystem.Configuration.Patches
{
    [System.Serializable]
    public sealed class HairRegionPatchConfig
    {
        [SerializeField]
        [Min(1)]
        private int _resolution = 128;

        [SerializeField]
        private Color32 _defaultColor = new(0, 0, 0, 255);

        [SerializeField]
        [Min(0f)]
        private float _growthRate = 1f;

        [SerializeField]
        [Min(0f)]
        private float _shaveRate = 1f;

        public int Resolution
        {
            get
            {
                return _resolution;
            }
        }

        public Color32 DefaultColor
        {
            get
            {
                return _defaultColor;
            }
        }

        public float GrowthRate
        {
            get
            {
                return _growthRate;
            }
        }

        public float ShaveRate
        {
            get
            {
                return _shaveRate;
            }
        }
    }
}