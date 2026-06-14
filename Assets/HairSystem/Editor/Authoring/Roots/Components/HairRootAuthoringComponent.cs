using UnityEngine;
using HairSystem.Authoring.Roots;
using HairSystem.Data.Roots;

namespace HairSystem.Editor.Authoring.Roots.Components
{
    [ExecuteAlways]
    public sealed class HairRootAuthoringComponent
        : MonoBehaviour
    {
        [SerializeField]
        private HairRootRegionAsset _asset;

        [SerializeField]
        private HairRootData[] _roots =
            System.Array.Empty<HairRootData>();

        public HairRootRegionAsset Asset
        {
            get
            {
                return _asset;
            }
        }

        public HairRootData[] Roots
        {
            get
            {
                return _roots;
            }
        }

        public void SetRoots(
            HairRootData[] roots)
        {
            _roots =
                roots;
        }

        public void SetAsset(
            HairRootRegionAsset asset)
        {
            _asset =
                asset;
        }
    }
}