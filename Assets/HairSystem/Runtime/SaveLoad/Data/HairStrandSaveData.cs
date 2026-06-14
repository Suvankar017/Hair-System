using HairSystem.Data.Enums;

namespace HairSystem.SaveLoad.Data
{
    [System.Serializable]
    public sealed class HairStrandSaveData
    {
        public int StrandId;

        public int RootIndex;

        public float CurrentLength;

        public HairStyleType StyleType;

        public HairPointSaveData[] Points;
    }
}