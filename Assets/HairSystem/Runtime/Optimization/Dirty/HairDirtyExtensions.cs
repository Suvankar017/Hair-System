using HairSystem.Data.Enums;

namespace HairSystem.Optimization.Dirty
{
    public static class HairDirtyExtensions
    {
        public static bool IsDirty(this HairDirtyState state)
        {
            return state.Flags != HairDirtyFlags.None;
        }
    }
}