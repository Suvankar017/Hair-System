using HairSystem.Data.Enums;

namespace HairSystem.Data.Styles
{
    [System.Serializable]
    public struct HairStyleData
    {
        public HairStyleType StyleType;

        public HairStyleData(
            HairStyleType styleType)
        {
            StyleType =
                styleType;
        }
    }
}