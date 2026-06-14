namespace HairSystem.Editor.Authoring.Roots.Tools
{
    public sealed class HairRootToolState
    {
        public HairRootToolType ActiveTool
        {
            get;
            set;
        }

        public HairRootToolState()
        {
            ActiveTool =
                HairRootToolType.Select;
        }
    }
}