using UnityEngine;
using HairSystem.Data.Roots;

namespace HairSystem.Authoring.Roots
{
    [CreateAssetMenu(
        fileName = "HairRootRegionAsset",
        menuName = "Hair System/Roots/Root Region Asset")]
    public sealed class HairRootRegionAsset
        : ScriptableObject
    {
        [SerializeField]
        private HairRootData[] _roots =
            System.Array.Empty<HairRootData>();

        public HairRootData[] Roots
        {
            get
            {
                return _roots;
            }
        }

#if UNITY_EDITOR

        public void SetRoots(
            HairRootData[] roots)
        {
            _roots =
                roots;
        }

#endif
    }
}