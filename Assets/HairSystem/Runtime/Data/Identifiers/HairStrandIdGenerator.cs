namespace HairSystem.Data.Identifiers
{
    public sealed class HairStrandIdGenerator
    {
        private int _nextId;

        public HairStrandIdGenerator()
        {
            _nextId = 0;
        }

        public HairStrandIdGenerator(int nextId)
        {
            _nextId = nextId;
        }

        public int Generate()
        {
            int id = _nextId;

            _nextId++;

            return id;
        }

        public void Reset()
        {
            _nextId = 0;
        }

        public void SetNextId(int nextId)
        {
            if (nextId < 0)
            {
                nextId = 0;
            }

            _nextId = nextId;
        }

        public int PeekNextId()
        {
            return _nextId;
        }
    }
}