namespace HairSystem.Editor.Authoring.Roots.Tools
{
    public sealed class HairRootSelection
    {
        public int SelectedIndex
        {
            get;
            private set;
        }

        public bool HasSelection
        {
            get;
            private set;
        }

        public void Select(
            int index)
        {
            SelectedIndex =
                index;

            HasSelection =
                true;
        }

        public void Clear()
        {
            SelectedIndex =
                -1;

            HasSelection =
                false;
        }
    }
}