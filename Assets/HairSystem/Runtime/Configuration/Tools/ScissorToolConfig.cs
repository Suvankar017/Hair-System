using UnityEngine;

namespace HairSystem.Configuration.Tools
{
    [System.Serializable]
    public sealed class ScissorToolConfig
    {
        [SerializeField]
        private HairToolAreaConfig _area = new();

        [SerializeField]
        [Min(0f)]
        private float _cutAmount = 0.1f;

        public HairToolAreaConfig Area
        {
            get
            {
                return _area;
            }
        }

        public float CutAmount
        {
            get
            {
                return _cutAmount;
            }
        }
    }
}