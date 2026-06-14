using UnityEngine;
using HairSystem.Data.Roots;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HairSystem.Authoring.Roots
{
    [ExecuteAlways]
    public sealed class HairRootAuthoringBehaviour : MonoBehaviour
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

        public void SetRoots(HairRootData[] roots)
        {
            _roots = roots;
        }

        public void SetAsset(HairRootRegionAsset asset)
        {
            _asset = asset;
        }

        public void RecordUndo(string operationName)
        {
#if UNITY_EDITOR
            Undo.RecordObject(this, operationName);
#endif
        }
    }
}