using UnityEditor;
using UnityEngine;
using HairSystem.EditorTools.Authoring.Roots.Tools;

namespace HairSystem.EditorTools.Authoring.Roots.Rendering
{
    public sealed class HairRootToolbarRenderer
    {
        public void Draw(
            HairRootToolbarState state)
        {
            GUILayout.BeginHorizontal(
                EditorStyles.toolbar);

            DrawButton(
                state,
                HairRootToolType.Select);

            DrawButton(
                state,
                HairRootToolType.Place);

            DrawButton(
                state,
                HairRootToolType.Move);

            DrawButton(
                state,
                HairRootToolType.Rotate);

            DrawButton(
                state,
                HairRootToolType.Delete);

            //GUILayout.FlexibleSpace();

            GUILayout.EndHorizontal();
        }

        private static void DrawButton(
            HairRootToolbarState state,
            HairRootToolType tool)
        {
            bool selected = state.ActiveTool == tool;

            if (GUILayout.Toggle(
                selected,
                tool.ToString(),
                EditorStyles.toolbarButton,
                GUILayout.Width(70f)))
            {
                state.ActiveTool = tool;
            }
        }
    }
}