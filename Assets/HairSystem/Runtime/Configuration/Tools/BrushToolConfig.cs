using UnityEngine;

namespace HairSystem.Configuration.Tools
{
    [System.Serializable]
    public sealed class BrushToolConfig
    {
        [SerializeField]
        private HairToolAreaConfig _area = new();

        public HairToolAreaConfig Area
        {
            get
            {
                return _area;
            }
        }
    }
}