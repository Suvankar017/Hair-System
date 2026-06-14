using UnityEngine;

namespace HairSystem.Configuration.Generation
{
    [System.Serializable]
    public sealed class EyebrowGenerationConfig
    {
        [SerializeField]
        [Min(1)]
        private int _patchResolution = 128;

        [SerializeField]
        private Color _defaultPatchColor =
            Color.black;

        public int PatchResolution
        {
            get
            {
                return _patchResolution;
            }
        }

        public Color DefaultPatchColor
        {
            get
            {
                return _defaultPatchColor;
            }
        }
    }
}