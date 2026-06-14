using UnityEngine;

namespace HairSystem.Configuration.Patches
{
    [CreateAssetMenu(
        fileName = "HairPatchConfig",
        menuName = "Hair System/Patch Config")]
    public sealed class HairPatchConfig
        : ScriptableObject
    {
        [SerializeField]
        private HairRegionPatchConfig _head = new();

        [SerializeField]
        private HairRegionPatchConfig _beard = new();

        [SerializeField]
        private HairRegionPatchConfig _mustache = new();

        [SerializeField]
        private HairRegionPatchConfig _eyebrow = new();

        public HairRegionPatchConfig Head
        {
            get
            {
                return _head;
            }
        }

        public HairRegionPatchConfig Beard
        {
            get
            {
                return _beard;
            }
        }

        public HairRegionPatchConfig Mustache
        {
            get
            {
                return _mustache;
            }
        }

        public HairRegionPatchConfig Eyebrow
        {
            get
            {
                return _eyebrow;
            }
        }
    }
}