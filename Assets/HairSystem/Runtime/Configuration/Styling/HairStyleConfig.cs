using UnityEngine;

namespace HairSystem.Configuration.Styling
{
    [CreateAssetMenu(
        fileName = "HairStyleConfig",
        menuName = "Hair System/Style Config")]
    public sealed class HairStyleConfig : ScriptableObject
    {
        [Header("Curls")]
        [SerializeField]
        private CurlStylePreset _smallCurl = new();

        [SerializeField]
        private CurlStylePreset _largeCurl = new();

        [Header("Braids")]
        [SerializeField]
        private BraidStylePreset _smallBraid = new();

        [SerializeField]
        private BraidStylePreset _largeBraid = new();

        [SerializeField]
        private BraidStylePreset _bubbleBraid = new();

        public CurlStylePreset SmallCurl
        {
            get
            {
                return _smallCurl;
            }
        }

        public CurlStylePreset LargeCurl
        {
            get
            {
                return _largeCurl;
            }
        }

        public BraidStylePreset SmallBraid
        {
            get
            {
                return _smallBraid;
            }
        }

        public BraidStylePreset LargeBraid
        {
            get
            {
                return _largeBraid;
            }
        }

        public BraidStylePreset BubbleBraid
        {
            get
            {
                return _bubbleBraid;
            }
        }
    }
}