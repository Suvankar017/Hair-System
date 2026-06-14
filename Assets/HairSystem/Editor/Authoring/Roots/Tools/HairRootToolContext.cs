using HairSystem.Editor.Authoring.Roots.Components;
using UnityEditor;
using UnityEngine;

namespace HairSystem.Editor.Authoring.Roots.Tools
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

        public HairRootAuthoringComponent Component
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
            HairRootAuthoringComponent component,
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