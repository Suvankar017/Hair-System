using PerformantHairSystem.Core;

namespace PerformantHairSystem.Data
{
    public static class StrandFlagUtility
    {
        public static bool Has(
            byte flags,
            StrandFlags value)
        {
            return (flags & (byte)value) != 0;
        }

        public static void Add(
            HairWorld world,
            int strand,
            StrandFlags value)
        {
            world.Flags[strand] |= value;
        }

        public static void Remove(
            HairWorld world,
            int strand,
            StrandFlags value)
        {
            world.Flags[strand] &= ~value;
        }
    }
}