using HairSystem.Data.Enums;

namespace HairSystem.SaveLoad.Data
{
    [System.Serializable]
    public sealed class HairRegionSaveData
    {
        public HairRegionType RegionType;

        public HairPatchSaveData Patch;

        public HairStrandSaveData[] Strands;
    }
}