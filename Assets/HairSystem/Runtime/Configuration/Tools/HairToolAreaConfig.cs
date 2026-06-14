using UnityEngine;

namespace HairSystem.Configuration.Tools
{
    [System.Serializable]
    public sealed class HairToolAreaConfig
    {
        [SerializeField]
        [Min(0f)]
        private float _radius = 1f;

        [SerializeField]
        [Min(0f)]
        private float _strength = 1f;

        [SerializeField]
        private AnimationCurve _falloff =
            AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

        public float Radius
        {
            get
            {
                return _radius;
            }
        }

        public float Strength
        {
            get
            {
                return _strength;
            }
        }

        public AnimationCurve Falloff
        {
            get
            {
                return _falloff;
            }
        }
    }
}