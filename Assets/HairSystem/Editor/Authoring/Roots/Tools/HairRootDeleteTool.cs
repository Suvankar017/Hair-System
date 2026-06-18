using HairSystem.Data.Roots;
using HairSystem.EditorTools.Authoring.Roots.Utilities;
using UnityEditor;
using UnityEngine;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootDeleteTool
        : IHairRootTool
    {
        public void OnSceneGUI(
            HairRootToolContext context)
        {
            if (!context.Selection.HasSelection)
            {
                return;
            }

            Event currentEvent =
                context.Event;

            if (currentEvent.type !=
                EventType.MouseDown)
            {
                return;
            }

            if (currentEvent.button != 0)
            {
                return;
            }

            DeleteSelection(
                context);

            currentEvent.Use();

            SceneView.RepaintAll();
        }

        private static void DeleteSelection(
            HairRootToolContext context)
        {
            int selectedIndex =
                context.Selection
                    .PrimarySelection;

            if (selectedIndex < 0)
            {
                return;
            }

            var behaviour =
                context.Component;

            behaviour.RecordUndo(
                "Delete Hair Root");

            HairRootData[] roots =
                HairRootArrayUtility.RemoveAt(
                    behaviour.Roots,
                    selectedIndex);

            behaviour.SetRoots(
                roots);

            EditorUtility.SetDirty(
                behaviour);

            context.Selection.Clear();
        }
    }
}