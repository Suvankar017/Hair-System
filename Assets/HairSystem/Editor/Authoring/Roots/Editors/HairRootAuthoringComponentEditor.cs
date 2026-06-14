using HairSystem.Editor.Authoring.Roots.Components;
using HairSystem.Editor.Authoring.Roots.Utilities;
using UnityEditor;
using UnityEngine;

namespace HairSystem.Editor.Authoring.Roots.Editors
{
    [CustomEditor(
        typeof(
            HairRootAuthoringComponent))]
    public sealed class HairRootAuthoringComponentEditor
        : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            HairRootAuthoringComponent component =
                (HairRootAuthoringComponent)
                target;

            EditorGUILayout.Space();

            if (GUILayout.Button(
                "Load From Asset"))
            {
                HairRootAuthoringUtility
                    .LoadFromAsset(
                        component);
            }

            if (GUILayout.Button(
                "Save To Asset"))
            {
                HairRootAuthoringUtility
                    .SaveToAsset(
                        component);
            }
        }
    }
}