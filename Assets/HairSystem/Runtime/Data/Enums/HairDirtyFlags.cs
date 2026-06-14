using System;

namespace HairSystem.Data.Enums
{
    [Flags]
    public enum HairDirtyFlags
    {
        None = 0,

        Physics = 1 << 0,

        Mesh = 1 << 1,

        Color = 1 << 2,

        Patch = 1 << 3,

        Save = 1 << 4,

        Style = 1 << 5,

        All = ~0
    }
}