using HairSystem.Data.Roots;
using HairSystem.Authoring.Roots;
using HairSystem.EditorTools.Authoring.Roots.Rendering;
using HairSystem.EditorTools.Authoring.Roots.Tools;
using UnityEditor;
using UnityEngine;

namespace HairSystem.EditorTools.Authoring.Roots.Editors
{
    public sealed class HairRootSceneEditor
    {
        private readonly HairRootSelection _selection;

        private readonly HairRootToolbarState _toolbarState;

        private readonly HairRootToolRegistry _toolRegistry;

        private readonly HairRootGizmoRenderer _renderer;

        private readonly HairRootToolbarRenderer _toolbar;

        public HairRootSceneEditor()
        {
            _selection =
                new HairRootSelection();

            _toolbarState =
                new HairRootToolbarState();

            _toolRegistry =
                new HairRootToolRegistry();

            _renderer =
                new HairRootGizmoRenderer(
                    new HairRootGizmoSettings());

            _toolbar =
                new HairRootToolbarRenderer();

            RegisterTools();
        }

        private void RegisterTools()
        {
            _toolRegistry.Register(
                HairRootToolType.Select,
                new HairRootSelectTool());

            _toolRegistry.Register(
                HairRootToolType.Place,
                new HairRootPlaceTool());
        }

        public void Draw(HairRootAuthoringBehaviour behaviour)
        {
            DrawToolbar();

            DrawRoots(
                behaviour);

            ExecuteTool(
                behaviour);
        }

        private void DrawToolbar()
        {
            Handles.BeginGUI();

            GUILayout.BeginArea(
                new Rect(
                    10,
                    10,
                    500,
                    30));

            _toolbar.Draw(
                _toolbarState);

            GUILayout.EndArea();

            Handles.EndGUI();
        }

        private void DrawRoots(
            HairRootAuthoringBehaviour component)
        {
            HairRootData[] roots =
                component.Roots;

            for (int i = 0;
                 i < roots.Length;
                 i++)
            {
                _renderer.DrawRoot(
                    component.transform,
                    roots[i],
                    _selection.Contains(i));
            }
        }

        private void ExecuteTool(
            HairRootAuthoringBehaviour component)
        {
            HairRootToolContext context =
                new HairRootToolContext(
                    SceneView.currentDrawingSceneView,
                    Event.current,
                    component,
                    _selection);

            _toolRegistry
                .GetTool(
                    _toolbarState.ActiveTool)
                .OnSceneGUI(
                    context);
        }
    }
}