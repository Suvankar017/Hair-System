namespace PerformantHairSystem.Data
{
    [System.Flags]
    public enum StrandFlags : byte
    {
        None = 0,

        Sleeping = 1 << 0,

        Dirty = 1 << 1,

        Selected = 1 << 2
    }
}
