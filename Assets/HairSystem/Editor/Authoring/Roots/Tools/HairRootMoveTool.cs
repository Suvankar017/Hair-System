using UnityEditor;
using UnityEngine;
using HairSystem.Data.Roots;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootMoveTool
        : IHairRootTool
    {
        public void OnSceneGUI(
            HairRootToolContext context)
        {
            if (!context.Selection.HasSelection)
            {
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

            EditorGUI.BeginChangeCheck();

            //Vector3 newWorldPosition =
            //    Handles.PositionHandle(
            //        worldPosition,
            //        Quaternion.identity);

            Vector3 newWorldPosition = Handles.Slider2D(
                worldPosition,
                Vector3.forward,
                Vector3.right,
                Vector3.up,
                HandleUtility.GetHandleSize(worldPosition) * 0.1f,
                Handles.CircleHandleCap,
                Vector2.zero);

            if (!EditorGUI.EndChangeCheck())
            {
                return;
            }

            behaviour.RecordUndo(
                "Move Hair Root");

            root.LocalPosition =
                behaviour.transform
                    .InverseTransformPoint(
                        newWorldPosition);

            roots[selectedIndex] =
                root;

            behaviour.SetRoots(
                roots);

            EditorUtility.SetDirty(behaviour);

            UnityEditor.SceneView
                .RepaintAll();
        }
    }
}