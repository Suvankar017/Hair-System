using HairSystem.Data.Enums;
using HairSystem.Data.Points;
using HairSystem.Data.Strands;
using HairSystem.Data.Styles;
using HairSystem.SaveLoad.Data;

namespace HairSystem.SaveLoad.Conversion
{
    public static class HairStrandSaveConverter
    {
        public static HairStrandSaveData ToSaveData(HairStrandData strand)
        {
            HairStrandSaveData saveData = new()
            {
                StrandId = strand.StrandId,
                RootIndex = strand.RootIndex,
                CurrentLength = strand.CurrentLength,
                StyleType = strand.StyleData.StyleType
            };

            HairPointData[] points = strand.GetPoints();

            saveData.Points = new HairPointSaveData[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                saveData.Points[i] = HairPointSaveConverter.ToSaveData(points[i]);
            }

            return saveData;
        }

        public static HairStrandData ToRuntimeData(HairStrandSaveData saveData)
        {
            HairPointData[] points = new HairPointData[saveData.Points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = HairPointSaveConverter.ToRuntimeData(saveData.Points[i]);
            }

            HairStrandData strand = new(
                saveData.StrandId,
                saveData.RootIndex,
                saveData.CurrentLength,
                points);

            strand.SetStyle(new HairStyleData(saveData.StyleType));

            return strand;
        }
    }
}