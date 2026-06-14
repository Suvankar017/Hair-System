using HairSystem.Authoring.Roots;
using HairSystem.EditorTools.Authoring.Roots.Utilities;
using UnityEditor;
using UnityEngine;

namespace HairSystem.EditorTools.Authoring.Roots.Editors
{
    [CustomEditor(
        typeof(
            HairRootAuthoringBehaviour))]
    public sealed class HairRootAuthoringBehaviourEditor
        : UnityEditor.Editor
    {
        private HairRootSceneEditor _sceneEditor;

        private void OnEnable()
        {
            _sceneEditor =
                new HairRootSceneEditor();
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            HairRootAuthoringBehaviour component =
                (HairRootAuthoringBehaviour)
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

        private void OnSceneGUI()
        {
            HairRootAuthoringBehaviour component =
                (HairRootAuthoringBehaviour)
                target;

            _sceneEditor.Draw(
                component);
        }
    }
}