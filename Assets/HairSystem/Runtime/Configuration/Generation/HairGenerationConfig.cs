using UnityEngine;

namespace HairSystem.Configuration.Generation
{
    [CreateAssetMenu(
        fileName = "HairGenerationConfig",
        menuName = "Hair System/Generation Config")]
    public sealed class HairGenerationConfig : ScriptableObject
    {
        [Header("Head")]
        [SerializeField]
        private HairRegionGenerationConfig _head = new();

        [Header("Beard")]
        [SerializeField]
        private HairRegionGenerationConfig _beard = new();

        [Header("Mustache")]
        [SerializeField]
        private HairRegionGenerationConfig _mustache = new();

        [Header("Eyebrow")]
        [SerializeField]
        private EyebrowGenerationConfig _eyebrow = new();

        public HairRegionGenerationConfig Head
        {
            get
            {
                return _head;
            }
        }

        public HairRegionGenerationConfig Beard
        {
            get
            {
                return _beard;
            }
        }

        public HairRegionGenerationConfig Mustache
        {
            get
            {
                return _mustache;
            }
        }

        public EyebrowGenerationConfig Eyebrow
        {
            get
            {
                return _eyebrow;
            }
        }
    }
}