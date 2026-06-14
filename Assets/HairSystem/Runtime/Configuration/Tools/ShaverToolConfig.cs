using UnityEngine;

namespace HairSystem.Configuration.Tools
{
    [System.Serializable]
    public sealed class ShaverToolConfig
    {
        [SerializeField]
        private HairToolAreaConfig _area = new();

        [SerializeField]
        [Min(0f)]
        private float _shaveRate = 1f;

        public HairToolAreaConfig Area
        {
            get
            {
                return _area;
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