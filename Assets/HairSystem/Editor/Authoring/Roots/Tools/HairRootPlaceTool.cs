using UnityEngine;
using HairSystem.Data.Roots;
using HairSystem.EditorTools.Authoring.Roots.Utilities;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootPlaceTool
        : IHairRootTool
    {
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

            Vector3 worldPosition =
                HairRootHandleUtility
                    .GetMouseWorldPosition();

            CreateRoot(
                context,
                worldPosition);

            currentEvent.Use();

            UnityEditor.SceneView
                .RepaintAll();
        }

        private static void CreateRoot(
            HairRootToolContext context,
            Vector3 worldPosition)
        {
            var behaviour =
                context.Component;

            behaviour.RecordUndo(
                "Create Hair Root");

            Vector2 localPosition =
                behaviour.transform
                    .InverseTransformPoint(
                        worldPosition);

            Vector2 localDirection =
                Vector2.up;

            HairRootData root =
                new HairRootData(
                    localPosition,
                    localDirection);

            HairRootData[] roots =
                HairRootArrayUtility.Add(
                    behaviour.Roots,
                    root);

            behaviour.SetRoots(
                roots);

            context.Selection
                .SelectSingle(
                    roots.Length - 1);
        }
    }
}