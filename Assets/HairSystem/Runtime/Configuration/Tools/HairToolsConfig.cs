using UnityEngine;

namespace HairSystem.Configuration.Tools
{
    [CreateAssetMenu(
        fileName = "HairToolsConfig",
        menuName = "Hair System/Tools Config")]
    public sealed class HairToolsConfig
        : ScriptableObject
    {
        [SerializeField]
        private BrushToolConfig _brush = new();

        [SerializeField]
        private CombToolConfig _comb = new();

        [SerializeField]
        private GrowthToolConfig _growth = new();

        [SerializeField]
        private ScissorToolConfig _scissor = new();

        [SerializeField]
        private TrimmerToolConfig _trimmer = new();

        [SerializeField]
        private ShaverToolConfig _shaver = new();

        [SerializeField]
        private DyeToolConfig _dye = new();

        [SerializeField]
        private CurlToolConfig _curl = new();

        [SerializeField]
        private BraidToolConfig _braid = new();

        [SerializeField]
        private ShowerToolConfig _shower = new();

        [SerializeField]
        private DryerToolConfig _dryer = new();

        public BrushToolConfig Brush
        {
            get
            {
                return _brush;
            }
        }

        public CombToolConfig Comb
        {
            get
            {
                return _comb;
            }
        }

        public GrowthToolConfig Growth
        {
            get
            {
                return _growth;
            }
        }

        public ScissorToolConfig Scissor
        {
            get
            {
                return _scissor;
            }
        }

        public TrimmerToolConfig Trimmer
        {
            get
            {
                return _trimmer;
            }
        }

        public ShaverToolConfig Shaver
        {
            get
            {
                return _shaver;
            }
        }

        public DyeToolConfig Dye
        {
            get
            {
                return _dye;
            }
        }

        public CurlToolConfig Curl
        {
            get
            {
                return _curl;
            }
        }

        public BraidToolConfig Braid
        {
            get
            {
                return _braid;
            }
        }

        public ShowerToolConfig Shower
        {
            get
            {
                return _shower;
            }
        }

        public DryerToolConfig Dryer
        {
            get
            {
                return _dryer;
            }
        }
    }
}