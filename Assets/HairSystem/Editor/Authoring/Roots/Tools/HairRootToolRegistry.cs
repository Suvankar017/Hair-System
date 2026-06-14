using System.Collections.Generic;

namespace HairSystem.Editor.Authoring.Roots.Tools
{
    public sealed class HairRootToolRegistry
    {
        private readonly Dictionary<
            HairRootToolType,
            IHairRootTool> _tools;

        public HairRootToolRegistry()
        {
            _tools =
                new Dictionary<
                    HairRootToolType,
                    IHairRootTool>();
        }

        public void Register(
            HairRootToolType type,
            IHairRootTool tool)
        {
            _tools[type] =
                tool;
        }

        public IHairRootTool GetTool(
            HairRootToolType type)
        {
            return _tools[type];
        }
    }
}