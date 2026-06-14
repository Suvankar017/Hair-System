using HairSystem.Data.Roots;

namespace HairSystem.Authoring.Roots
{
    public sealed class HairRootCollection
    {
        private readonly HairRootData[] _roots;

        public int Count
        {
            get
            {
                return _roots.Length;
            }
        }

        public HairRootData this[int index]
        {
            get
            {
                return _roots[index];
            }
        }

        public HairRootCollection(
            HairRootData[] roots)
        {
            _roots =
                roots;
        }
    }
}