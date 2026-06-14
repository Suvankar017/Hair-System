using UnityEngine;
using HairSystem.Authoring.Roots;

namespace HairSystem.Authoring.Definitions
{
    [CreateAssetMenu(
        fileName = "HairCharacterDefinition",
        menuName = "Hair System/Character Definition")]
    public sealed class HairCharacterDefinition
        : ScriptableObject
    {
        [Header("Roots")]
        [SerializeField]
        private HairRootRegionAsset _headRoots;

        [SerializeField]
        private HairRootRegionAsset _beardRoots;

        [SerializeField]
        private HairRootRegionAsset _mustacheRoots;

        [Header("Patch Regions")]
        [SerializeField]
        private bool _enableEyebrowPatch = true;

        public HairRootRegionAsset HeadRoots
        {
            get
            {
                return _headRoots;
            }
        }

        public HairRootRegionAsset BeardRoots
        {
            get
            {
                return _beardRoots;
            }
        }

        public HairRootRegionAsset MustacheRoots
        {
            get
            {
                return _mustacheRoots;
            }
        }

        public bool EnableEyebrowPatch
        {
            get
            {
                return _enableEyebrowPatch;
            }
        }
    }
}