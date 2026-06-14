using UnityEngine;

namespace HairSystem.Configuration.Tools
{
    [System.Serializable]
    public sealed class ShowerToolConfig
    {
        [SerializeField]
        private HairToolAreaConfig _area = new();

        [SerializeField]
        [Min(0f)]
        private float _wetnessRate = 1f;

        public HairToolAreaConfig Area
        {
            get
            {
                return _area;
            }
        }

        public float WetnessRate
        {
            get
            {
                return _wetnessRate;
            }
        }
    }
}