using HairSystem.Data.Points;
using HairSystem.SaveLoad.Data;

namespace HairSystem.SaveLoad.Conversion
{
    public static class HairPointSaveConverter
    {
        public static HairPointSaveData ToSaveData(HairPointData point)
        {
            HairPointSaveData saveData = new()
            {
                RestPosition = point.RestPosition,
                Width = point.Width,
                Color = point.Color
            };

            return saveData;
        }

        public static HairPointData ToRuntimeData(HairPointSaveData saveData)
        {
            return new HairPointData(
                saveData.RestPosition,
                saveData.Width,
                saveData.Color);
        }
    }
}