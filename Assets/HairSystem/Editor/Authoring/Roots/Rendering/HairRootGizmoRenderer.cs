using UnityEditor;
using UnityEngine;
using HairSystem.Data.Roots;

namespace HairSystem.Editor.Authoring.Roots.Rendering
{
    public sealed class HairRootGizmoRenderer
    {
        private readonly HairRootGizmoSettings _settings;

        public HairRootGizmoRenderer(
            HairRootGizmoSettings settings)
        {
            _settings =
                settings;
        }

        public void DrawRoot(
            Transform transform,
            HairRootData root,
            bool selected)
        {
            Vector3 worldPosition =
                transform.TransformPoint(
                    root.LocalPosition);

            Vector3 worldDirection =
                transform.TransformDirection(
                    root.Direction);

            DrawPosition(
                worldPosition,
                selected);

            DrawDirection(
                worldPosition,
                worldDirection);
        }

        private void DrawPosition(
            Vector3 position,
            bool selected)
        {
            float size =
                HandleUtility.GetHandleSize(
                    position) *
                _settings.RootHandleSize;

            if (selected)
            {
                size *=
                    _settings.SelectionScale;
            }

            Handles.DotHandleCap(
                0,
                position,
                Quaternion.identity,
                size,
                EventType.Repaint);
        }

        private void DrawDirection(
            Vector3 position,
            Vector3 direction)
        {
            Handles.DrawLine(
                position,
                position +
                direction.normalized *
                _settings.DirectionLength);
        }
    }
}