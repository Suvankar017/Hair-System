using HairSystem.Data.Roots;

namespace HairSystem.EditorTools.Authoring.Roots.Utilities
{
    public static class HairRootArrayUtility
    {
        public static HairRootData[] Add(
            HairRootData[] roots,
            HairRootData root)
        {
            HairRootData[] result =
                new HairRootData[
                    roots.Length + 1];

            System.Array.Copy(
                roots,
                result,
                roots.Length);

            result[
                result.Length - 1] =
                root;

            return result;
        }

        public static HairRootData[] RemoveAt(
            HairRootData[] roots,
            int index)
        {
            HairRootData[] result =
                new HairRootData[
                    roots.Length - 1];

            int destination = 0;

            for (int i = 0;
                 i < roots.Length;
                 i++)
            {
                if (i == index)
                {
                    continue;
                }

                result[destination] =
                    roots[i];

                destination++;
            }

            return result;
        }
    }
}