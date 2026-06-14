using HairSystem.Data.Enums;

namespace HairSystem.Data.Styles
{
    [System.Serializable]
    public struct HairStyleData
    {
        private HairStyleType _styleType;

        public HairStyleType StyleType
        {
            get
            {
                return _styleType;
            }
        }

        public HairStyleData(HairStyleType styleType)
        {
            _styleType = styleType;
        }

        public void SetStyle(HairStyleType styleType)
        {
            _styleType = styleType;
        }
    }
}