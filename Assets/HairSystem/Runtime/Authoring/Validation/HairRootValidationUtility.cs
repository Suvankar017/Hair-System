using HairSystem.Data.Roots;

namespace HairSystem.Authoring.Validation
{
    public static class HairRootValidationUtility
    {
        public static bool IsValid(
            HairRootData root)
        {
            return root.Direction.sqrMagnitude >
                   0.0001f;
        }

        public static bool IsValid(
            HairRootData[] roots)
        {
            if (roots == null)
            {
                return false;
            }

            if (roots.Length == 0)
            {
                return false;
            }

            for (int i = 0;
                 i < roots.Length;
                 i++)
            {
                if (!IsValid(
                    roots[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}