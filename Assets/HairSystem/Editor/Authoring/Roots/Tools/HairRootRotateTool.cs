using HairSystem.Data.Roots;
using UnityEditor;
using UnityEngine;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootRotateTool
        : IHairRootTool
    {
        public void OnSceneGUI(
            HairRootToolContext context)
        {
            if (!context.Selection.HasSelection)
            {
                if (context.Event.type ==
                    EventType.MouseDown)
                {
                    if (HairRootSelectionUtility
                        .TrySelectRootUnderMouse(
                            context))
                    {
                        SceneView.RepaintAll();
                        context.Event.Use();
                        return;
                    }
                }

                return;
            }

            int selectedIndex =
                context.Selection
                    .PrimarySelection;

            if (selectedIndex < 0)
            {
                return;
            }

            var behaviour =
                context.Component;

            HairRootData[] roots =
                behaviour.Roots;

            HairRootData root =
                roots[selectedIndex];

            Vector3 worldPosition =
                behaviour.transform
                    .TransformPoint(
                        root.LocalPosition);

            Vector3 worldDirection =
                behaviour.transform
                    .TransformDirection(
                        root.Direction);

            float handleDistance =
                0.4f;

            Vector3 handlePosition =
                worldPosition +
                worldDirection.normalized *
                handleDistance;

            EditorGUI.BeginChangeCheck();

            //Vector3 newHandlePosition = Handles.FreeMoveHandle(
            //    handlePosition,
            //    HandleUtility.GetHandleSize(handlePosition) * 0.08f,
            //    Vector3.zero,
            //    Handles.CircleHandleCap);

            Vector3 newHandlePosition = Handles.Slider2D(
                handlePosition,
                Vector3.forward,
                Vector3.right,
                Vector3.up,
                HandleUtility.GetHandleSize(handlePosition) * 0.08f,
                CustomHandleCap,
                Vector2.zero);

            if (!EditorGUI.EndChangeCheck())
            {
                return;
            }

            behaviour.RecordUndo(
                "Rotate Hair Root");

            Vector3 localHandlePosition =
                behaviour.transform
                    .InverseTransformPoint(
                        newHandlePosition);

            //Vector2 newDirection =
            //    (
            //        (Vector2)localHandlePosition -
            //        root.LocalPosition
            //    ).normalized;

            Vector2 delta = (Vector2)localHandlePosition - root.LocalPosition;

            if (delta.sqrMagnitude < 0.0001f)
            {
                return;
            }

            root.Direction = delta.normalized;

            roots[selectedIndex] = root;

            behaviour.SetRoots(roots);

            EditorUtility.SetDirty(
                behaviour);

            SceneView.RepaintAll();
        }

        private static void CustomHandleCap(int controlID, Vector3 position, Quaternion rotation, float size, EventType eventType)
        {
            Debug.Log(eventType);
            Handles.CircleHandleCap(controlID, position, rotation, size, eventType);
        }
    }
}