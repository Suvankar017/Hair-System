using UnityEngine;

namespace HairSystem.Configuration.Rendering
{
    [CreateAssetMenu(
        fileName = "HairRenderingConfig",
        menuName = "Hair System/Rendering Config")]
    public sealed class HairRenderingConfig : ScriptableObject
    {
        [Header("Material")]
        [SerializeField]
        private Material _sharedMaterial;

        [Header("Width")]
        [SerializeField]
        [Min(0f)]
        private float _widthMultiplier = 1f;

        [SerializeField]
        [Min(0f)]
        private float _minimumVisibleWidth = 0.001f;

        [Header("Mesh Updates")]
        [SerializeField]
        [Min(1)]
        private int _maxDirtyStrandsPerFrame = 50;

        [Header("Sorting")]
        [SerializeField]
        private int _headSortingOrder = 0;

        [SerializeField]
        private int _beardSortingOrder = 1;

        [SerializeField]
        private int _mustacheSortingOrder = 2;

        [SerializeField]
        private int _patchSortingOrder = -1;

        public Material SharedMaterial
        {
            get
            {
                return _sharedMaterial;
            }
        }

        public float WidthMultiplier
        {
            get
            {
                return _widthMultiplier;
            }
        }

        public float MinimumVisibleWidth
        {
            get
            {
                return _minimumVisibleWidth;
            }
        }

        public int MaxDirtyStrandsPerFrame
        {
            get
            {
                return _maxDirtyStrandsPerFrame;
            }
        }

        public int HeadSortingOrder
        {
            get
            {
                return _headSortingOrder;
            }
        }

        public int BeardSortingOrder
        {
            get
            {
                return _beardSortingOrder;
            }
        }

        public int MustacheSortingOrder
        {
            get
            {
                return _mustacheSortingOrder;
            }
        }

        public int PatchSortingOrder
        {
            get
            {
                return _patchSortingOrder;
            }
        }
    }
}