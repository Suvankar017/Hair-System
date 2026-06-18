using UnityEngine;
using HairSystem.EditorTools.Authoring.Roots.Utilities;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public static class HairRootSelectionUtility
    {
        private const float PickDistance =
            0.15f;

        public static bool TrySelectRootUnderMouse(
            HairRootToolContext context)
        {
            Vector3 mouseWorld =
                HairRootHandleUtility
                    .GetMouseWorldPosition();

            int selectedIndex =
                HairRootPickingUtility
                    .FindNearestRoot(
                        context.Component.transform,
                        context.Component.Roots,
                        mouseWorld,
                        PickDistance);

            if (selectedIndex < 0)
            {
                return false;
            }

            context.Selection.SelectSingle(
                selectedIndex);

            return true;
        }
    }
}