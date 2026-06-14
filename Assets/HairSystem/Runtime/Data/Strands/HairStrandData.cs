using HairSystem.Data.Enums;
using HairSystem.Data.Points;
using HairSystem.Data.Styles;
using HairSystem.Optimization.Dirty;
using UnityEngine;

namespace HairSystem.Data.Strands
{
    [System.Serializable]
    public sealed class HairStrandData
    {
        private readonly int _strandId;

        private readonly int _rootIndex;

        private float _currentLength;

        private readonly float _maximumLength;

        private float _motionEnergy;

        private HairSimulationState _simulationState;

        private HairStyleData _styleData;

        private HairDirtyState _dirtyState;

        private readonly HairPointData[] _points;


        public int StrandId
        {
            get
            {
                return _strandId;
            }
        }

        public int RootIndex
        {
            get
            {
                return _rootIndex;
            }
        }

        public float CurrentLength
        {
            get
            {
                return _currentLength;
            }
        }

        public float MaximumLength
        {
            get
            {
                return _maximumLength;
            }
        }

        public float MotionEnergy
        {
            get
            {
                return _motionEnergy;
            }
        }

        public HairSimulationState SimulationState
        {
            get
            {
                return _simulationState;
            }
        }

        public HairStyleData StyleData
        {
            get
            {
                return _styleData;
            }
        }

        public HairDirtyState DirtyState
        {
            get
            {
                return _dirtyState;
            }
        }


        public HairStrandData(
            int strandId,
            int rootIndex,
            float maximumLength,
            HairPointData[] points)
        {
            _strandId = strandId;

            _rootIndex = rootIndex;

            _currentLength = maximumLength;

            _maximumLength = maximumLength;

            _motionEnergy = 0f;

            _simulationState = HairSimulationState.Active;

            _styleData = new HairStyleData(HairStyleType.None);

            _dirtyState = new HairDirtyState();

            _points = points;
        }

        public void SetCurrentLength(float length)
        {
            _currentLength = Mathf.Clamp(length, 0f, _maximumLength);
        }

        public void SetSimulationState(HairSimulationState state)
        {
            _simulationState = state;
        }

        public void SetMotionEnergy(float energy)
        {
            _motionEnergy = energy;
        }

        public void SetStyle(HairStyleData styleData)
        {
            _styleData = styleData;
        }

        public HairPointData[] GetPoints()
        {
            return _points;
        }
    }
}