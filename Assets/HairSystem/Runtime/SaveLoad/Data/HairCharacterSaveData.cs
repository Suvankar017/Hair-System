namespace HairSystem.SaveLoad.Data
{
    [System.Serializable]
    public sealed class HairCharacterSaveData
    {
        public int Version;

        public HairRegionSaveData[] Regions;
    }
}