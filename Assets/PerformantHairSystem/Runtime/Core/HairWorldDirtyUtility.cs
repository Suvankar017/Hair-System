namespace PerformantHairSystem.Core
{
    public static class HairWorldDirtyUtility
    {
        public static void MarkDirty(
            HairWorld world,
            int strand)
        {
            world.StrandVersion[strand]++;

            world.SimulationVersion++;
        }
    }
}