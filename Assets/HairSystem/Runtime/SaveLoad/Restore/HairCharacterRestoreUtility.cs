using HairSystem.Data.Characters;
using HairSystem.Data.Regions;
using HairSystem.Runtime.Lookup;
using HairSystem.SaveLoad.Data;

namespace HairSystem.SaveLoad.Restore
{
    public static class HairCharacterRestoreUtility
    {
        public static void Restore(
            HairCharacterData character,
            HairCharacterSaveData saveData)
        {
            HairStrandLookupCache lookup = new();

            lookup.Rebuild(character);

            int regionCount = saveData.Regions.Length;

            for (int i = 0; i < regionCount; i++)
            {
                HairRegionSaveData regionSave = saveData.Regions[i];

                if (!character.TryGetRegion(
                    regionSave.RegionType,
                    out HairRegionData region))
                {
                    continue;
                }

                HairRegionRestoreUtility.Restore(region, regionSave, lookup);
            }
        }
    }
}