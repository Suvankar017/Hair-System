using UnityEngine;

namespace HairSystem.Configuration.Tools
{
    [System.Serializable]
    public sealed class GrowthToolConfig
    {
        [SerializeField]
        private HairToolAreaConfig _area = new();

        [SerializeField]
        [Min(0f)]
        private float _growthRate = 1f;

        public HairToolAreaConfig Area
        {
            get
            {
                return _area;
            }
        }

        public float GrowthRate
        {
            get
            {
                return _growthRate;
            }
        }
    }
}