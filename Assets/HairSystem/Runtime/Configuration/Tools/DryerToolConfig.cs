using UnityEngine;

namespace HairSystem.Configuration.Tools
{
    [System.Serializable]
    public sealed class DryerToolConfig
    {
        [SerializeField]
        private HairToolAreaConfig _area = new();

        [SerializeField]
        [Min(0f)]
        private float _dryRate = 1f;

        public HairToolAreaConfig Area
        {
            get
            {
                return _area;
            }
        }

        public float DryRate
        {
            get
            {
                return _dryRate;
            }
        }
    }
}