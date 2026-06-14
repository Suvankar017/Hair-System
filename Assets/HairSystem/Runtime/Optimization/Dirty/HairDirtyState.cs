using HairSystem.Data.Enums;

namespace HairSystem.Optimization.Dirty
{
    [System.Serializable]
    public struct HairDirtyState
    {
        public HairDirtyFlags Flags;

        public readonly bool HasFlag(HairDirtyFlags flag)
        {
            return (Flags & flag) != 0;
        }

        public void Set(HairDirtyFlags flag)
        {
            Flags |= flag;
        }

        public void Clear(HairDirtyFlags flag)
        {
            Flags &= ~flag;
        }

        public void ClearAll()
        {
            Flags = HairDirtyFlags.None;
        }
    }

}