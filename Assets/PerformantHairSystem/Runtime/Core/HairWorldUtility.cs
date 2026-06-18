namespace PerformantHairSystem.Core
{
    public static class HairWorldUtility
    {
        public static int GetParticleStart(
            HairWorld world,
            int strand)
        {
            return world.StrandStart[strand];
        }

        public static int GetParticleCount(
            HairWorld world,
            int strand)
        {
            return world.StrandLength[strand];
        }

        public static int GetParticleIndex(
            HairWorld world,
            int strand,
            int particle)
        {
            return
                world.StrandStart[strand]
                + particle;
        }
    }
}