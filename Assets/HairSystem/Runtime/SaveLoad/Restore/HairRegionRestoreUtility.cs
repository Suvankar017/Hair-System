using HairSystem.Data.Regions;
using HairSystem.Data.Strands;
using HairSystem.Runtime.Lookup;
using HairSystem.SaveLoad.Data;

namespace HairSystem.SaveLoad.Restore
{
    public static class HairRegionRestoreUtility
    {
        public static void Restore(
            HairRegionData region,
            HairRegionSaveData saveData,
            HairStrandLookupCache lookup)
        {
            RestorePatch(region, saveData);

            RestoreStrands(saveData, lookup);
        }

        private static void RestorePatch(
            HairRegionData region,
            HairRegionSaveData saveData)
        {
            int width = region.Patch.Width;

            int height = region.Patch.Height;

            int saveWidth = saveData.Patch.Width;

            int saveHeight = saveData.Patch.Height;

            int copyWidth = (width < saveWidth) ? width : saveWidth;

            int copyHeight = (height < saveHeight) ? height : saveHeight;

            for (int y = 0; y < copyHeight; y++)
            {
                for (int x = 0; x < copyWidth; x++)
                {
                    region.Patch.SetPixel(
                        x,
                        y,
                        saveData.Patch.Pixels[y * saveWidth + x]);
                }
            }
        }

        private static void RestoreStrands(
            HairRegionSaveData saveData,
            HairStrandLookupCache lookup)
        {
            int strandCount = saveData.Strands.Length;

            for (int i = 0; i < strandCount; i++)
            {
                HairStrandSaveData strandSave = saveData.Strands[i];

                if (!lookup.TryGetStrand(
                    strandSave.StrandId,
                    out HairStrandData strand))
                {
                    continue;
                }

                HairStrandRestoreUtility.Restore(strand, strandSave);
            }
        }
    }
}