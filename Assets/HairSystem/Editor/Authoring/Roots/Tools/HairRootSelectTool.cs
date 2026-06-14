using UnityEngine;
using HairSystem.Data.Roots;
using HairSystem.EditorTools.Authoring.Roots.Utilities;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootSelectTool
        : IHairRootTool
    {
        private const float PickDistance =
            0.15f;

        public void OnSceneGUI(
            HairRootToolContext context)
        {
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

            Vector3 mouseWorld =
                HairRootHandleUtility
                    .GetMouseWorldPosition();

            HairRootData[] roots =
                context.Component.Roots;

            int selectedIndex =
                HairRootPickingUtility
                    .FindNearestRoot(
                        context.Component.transform,
                        roots,
                        mouseWorld,
                        PickDistance);

            if (selectedIndex >= 0)
            {
                context.Selection.SelectSingle(selectedIndex);
            }
            else
            {
                context.Selection.Clear();
            }

            currentEvent.Use();

            UnityEditor.SceneView.RepaintAll();
        }
    }
}