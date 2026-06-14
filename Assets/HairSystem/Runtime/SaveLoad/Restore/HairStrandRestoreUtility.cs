using HairSystem.Data.Points;
using HairSystem.Data.Strands;
using HairSystem.Data.Styles;
using HairSystem.SaveLoad.Data;

namespace HairSystem.SaveLoad.Restore
{
    public static class HairStrandRestoreUtility
    {
        public static void Restore(
            HairStrandData strand,
            HairStrandSaveData saveData)
        {
            strand.SetCurrentLength(saveData.CurrentLength);

            strand.SetStyle(new HairStyleData(saveData.StyleType));

            HairPointData[] points = strand.GetPoints();

            int count = points.Length;

            if (saveData.Points.Length < count)
            {
                count = saveData.Points.Length;
            }

            for (int i = 0; i < count; i++)
            {
                HairPointData point = points[i];

                point.RestPosition = saveData.Points[i].RestPosition;

                point.Width = saveData.Points[i].Width;

                point.Color = saveData.Points[i].Color;

                points[i] = point;
            }
        }
    }
}