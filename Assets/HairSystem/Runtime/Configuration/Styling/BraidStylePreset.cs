using UnityEngine;

namespace HairSystem.Configuration.Styling
{
    [System.Serializable]
    public sealed class BraidStylePreset
    {
        [SerializeField]
        private Texture2D _patternTexture;

        [SerializeField]
        [Min(0f)]
        private float _stiffnessMultiplier = 1f;

        public Texture2D PatternTexture
        {
            get
            {
                return _patternTexture;
            }
        }

        public float StiffnessMultiplier
        {
            get
            {
                return _stiffnessMultiplier;
            }
        }
    }
}