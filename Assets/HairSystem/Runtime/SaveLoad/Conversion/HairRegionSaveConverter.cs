using HairSystem.Data.Regions;
using HairSystem.Data.Strands;
using HairSystem.SaveLoad.Data;

namespace HairSystem.SaveLoad.Conversion
{
    public static class HairRegionSaveConverter
    {
        public static HairRegionSaveData ToSaveData(HairRegionData region)
        {
            HairRegionSaveData saveData = new()
            {
                RegionType = region.RegionType,
                Patch = HairPatchSaveConverter.ToSaveData(region.Patch)
            };

            int strandCount = region.Strands.Count;

            saveData.Strands = new HairStrandSaveData[strandCount];

            for (int i = 0; i < strandCount; i++)
            {
                HairStrandData strand = region.Strands[i];

                saveData.Strands[i] = HairStrandSaveConverter.ToSaveData(strand);
            }

            return saveData;
        }
    }
}