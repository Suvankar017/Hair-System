using HairSystem.Authoring.Roots;
using HairSystem.Data.Roots;
using HairSystem.EditorTools.Authoring.Roots.Rendering;
using HairSystem.EditorTools.Authoring.Roots.Tools;
using HairSystem.EditorTools.Authoring.Roots.Utilities;
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

        private HairRootAuthoringBehaviour _currentBehaviour;

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

            _toolRegistry.Register(
                HairRootToolType.Move,
                new HairRootMoveTool());

            _toolRegistry.Register(
                HairRootToolType.Rotate,
                new HairRootRotateTool());

            _toolRegistry.Register(
                HairRootToolType.Delete,
                new HairRootDeleteTool());
        }

        public void Draw(HairRootAuthoringBehaviour behaviour)
        {
            _currentBehaviour = behaviour;

            DrawToolbar();

            DrawRoots(
                behaviour);

            HandleKeyboardShortcuts();

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

        private void HandleKeyboardShortcuts()
        {
            Event currentEvent =
                Event.current;

            if (currentEvent.type !=
                EventType.KeyDown)
            {
                return;
            }

            switch (currentEvent.keyCode)
            {
                case KeyCode.Delete:
                case KeyCode.Backspace:

                    DeleteSelection();

                    currentEvent.Use();

                    break;
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

        private void DeleteSelection()
        {
            if (!_selection.HasSelection)
            {
                return;
            }

            int selectedIndex =
                _selection.PrimarySelection;

            _currentBehaviour.RecordUndo(
                "Delete Hair Root");

            var roots =
                HairRootArrayUtility.RemoveAt(
                    _currentBehaviour.Roots,
                    selectedIndex);

            _currentBehaviour.SetRoots(
                roots);

            EditorUtility.SetDirty(
                _currentBehaviour);

            _selection.Clear();

            SceneView.RepaintAll();
        }
    }
}