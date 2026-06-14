using HairSystem.Data.Enums;
using HairSystem.Data.Points;
using HairSystem.Data.Styles;
using HairSystem.Optimization.Dirty;

namespace HairSystem.Data.Strands
{
    [System.Serializable]
    public sealed class HairStrandData
    {
        public int StrandId;

        public int RootIndex;

        public float CurrentLength;

        public float MaximumLength;

        public float MotionEnergy;

        public HairSimulationState SimulationState;

        public HairStyleData StyleData;

        public HairDirtyState DirtyState;

        public HairPointData[] Points;

        public HairStrandData(
            int strandId,
            int rootIndex,
            float maximumLength,
            HairPointData[] points)
        {
            StrandId =
                strandId;

            RootIndex =
                rootIndex;

            CurrentLength =
                maximumLength;

            MaximumLength =
                maximumLength;

            MotionEnergy =
                0f;

            SimulationState =
                HairSimulationState.Active;

            StyleData =
                new HairStyleData(
                    HairStyleType.None);

            DirtyState =
                new HairDirtyState();

            Points =
                points;
        }
    }
}