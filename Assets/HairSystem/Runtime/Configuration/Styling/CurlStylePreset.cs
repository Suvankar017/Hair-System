using UnityEngine;

namespace HairSystem.Configuration.Styling
{
    [System.Serializable]
    public sealed class CurlStylePreset
    {
        [SerializeField]
        [Min(0f)]
        private float _amplitude = 0.1f;

        [SerializeField]
        [Min(0f)]
        private float _frequency = 5f;

        public float Amplitude
        {
            get
            {
                return _amplitude;
            }
        }

        public float Frequency
        {
            get
            {
                return _frequency;
            }
        }
    }
}