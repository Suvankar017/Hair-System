using System.Collections.Generic;
using HairSystem.Data.Characters;
using HairSystem.Data.Regions;
using HairSystem.SaveLoad.Data;
using HairSystem.Data.Enums;

namespace HairSystem.SaveLoad.Conversion
{
    public static class HairCharacterSaveConverter
    {
        public static HairCharacterSaveData ToSaveData(HairCharacterData character)
        {
            HairCharacterSaveData saveData = new()
            {
                Version = HairSaveVersion.Current
            };

            int regionCount = character.Regions.Count;

            saveData.Regions = new HairRegionSaveData[regionCount];

            int index = 0;

            foreach (KeyValuePair<HairRegionType, HairRegionData> pair in character.Regions)
            {
                saveData.Regions[index] = HairRegionSaveConverter.ToSaveData(pair.Value);

                index++;
            }

            return saveData;
        }
    }
}