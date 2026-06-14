using HairSystem.Authoring.Roots;
using UnityEditor;
using UnityEngine;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootToolContext
    {
        public SceneView SceneView
        {
            get;
        }

        public Event Event
        {
            get;
        }

        public HairRootAuthoringBehaviour Component
        {
            get;
        }

        public HairRootSelection Selection
        {
            get;
        }

        public HairRootToolContext(
            SceneView sceneView,
            Event currentEvent,
            HairRootAuthoringBehaviour component,
            HairRootSelection selection)
        {
            SceneView =
                sceneView;

            Event =
                currentEvent;

            Component =
                component;

            Selection =
                selection;
        }
    }
}