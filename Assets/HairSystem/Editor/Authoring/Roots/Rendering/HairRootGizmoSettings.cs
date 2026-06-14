using UnityEngine;

namespace HairSystem.EditorTools.Authoring.Roots.Rendering
{
    public sealed class HairRootGizmoSettings
    {
        public float RootHandleSize
        {
            get;
        }

        public float DirectionLength
        {
            get;
        }

        public float SelectionScale
        {
            get;
        }

        public HairRootGizmoSettings()
        {
            RootHandleSize = 0.05f;

            DirectionLength = 0.2f;

            SelectionScale = 1.35f;
        }
    }
}