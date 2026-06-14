namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootToolbarState
    {
        public HairRootToolType ActiveTool
        {
            get;
            set;
        }

        public HairRootToolbarState()
        {
            ActiveTool =
                HairRootToolType.Select;
        }
    }
}