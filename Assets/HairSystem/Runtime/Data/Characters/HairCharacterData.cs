using System.Collections.Generic;
using HairSystem.Data.Enums;
using HairSystem.Data.Regions;

namespace HairSystem.Data.Characters
{
    [System.Serializable]
    public sealed class HairCharacterData
    {
        private readonly Dictionary<HairRegionType, HairRegionData> _regions;

        public IReadOnlyDictionary<HairRegionType, HairRegionData> Regions
        {
            get
            {
                return _regions;
            }
        }

        public HairCharacterData()
        {
            _regions = new Dictionary<HairRegionType, HairRegionData>();
        }

        public void AddRegion(HairRegionData region)
        {
            _regions[region.RegionType] = region;
        }

        public HairRegionData GetRegion(HairRegionType regionType)
        {
            return _regions[regionType];
        }

        public bool TryGetRegion(HairRegionType regionType, out HairRegionData region)
        {
            return _regions.TryGetValue(regionType, out region);
        }
    }
}