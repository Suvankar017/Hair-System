using PerformantHairSystem.Data;

namespace PerformantHairSystem.Core
{
    public static class HairSleepUtility
    {
        public static bool IsSleeping(
            HairWorld world,
            int strand)
        {
            return (world.Flags[strand] & StrandFlags.Sleeping) != 0;
        }

        public static void Sleep(
            HairWorld world,
            int strand)
        {
            world.Flags[strand] |= StrandFlags.Sleeping;
        }

        public static void Wake(
            HairWorld world,
            int strand)
        {
            world.Flags[strand] &= unchecked(~StrandFlags.Sleeping);

            world.SleepTimer[strand] = 0f;

            HairWorldDirtyUtility.MarkDirty(
                world,
                strand);
        }
    }
}