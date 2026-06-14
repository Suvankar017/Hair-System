using System.Collections.Generic;
using HairSystem.Data.Enums;
using HairSystem.Data.Patches;
using HairSystem.Data.Roots;
using HairSystem.Data.Strands;

namespace HairSystem.Data.Regions
{
    [System.Serializable]
    public sealed class HairRegionData
    {
        public HairRegionType RegionType;

        public HairRootData[] Roots;

        public HairPatchData Patch;

        public List<HairStrandData> Strands;

        public HairRegionData(
            HairRegionType regionType,
            HairRootData[] roots,
            HairPatchData patch,
            List<HairStrandData> strands)
        {
            RegionType = regionType;

            Roots = roots;

            Patch = patch;

            Strands = strands;
        }
    }
}