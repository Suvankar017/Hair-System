namespace HairSystem.SaveLoad.Data
{
    public readonly struct HairSaveSlot
    {
        public int Index
        {
            get;
        }

        public HairSaveSlot(int index)
        {
            Index = index;
        }

        public override string ToString()
        {
            return $"slot_{Index}";
        }
    }
}