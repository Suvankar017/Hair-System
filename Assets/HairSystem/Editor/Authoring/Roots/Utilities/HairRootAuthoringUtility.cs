using HairSystem.Authoring.Roots;
using HairSystem.Data.Roots;
using HairSystem.Editor.Authoring.Roots.Components;

namespace HairSystem.Editor.Authoring.Roots.Utilities
{
    public static class HairRootAuthoringUtility
    {
        public static void LoadFromAsset(
            HairRootAuthoringComponent component)
        {
            HairRootRegionAsset asset =
                component.Asset;

            if (asset == null)
            {
                return;
            }

            HairRootData[] copy =
                new HairRootData[
                    asset.Roots.Length];

            System.Array.Copy(
                asset.Roots,
                copy,
                copy.Length);

            component.SetRoots(
                copy);
        }

        public static void SaveToAsset(
            HairRootAuthoringComponent component)
        {
            HairRootRegionAsset asset =
                component.Asset;

            if (asset == null)
            {
                return;
            }

            HairRootData[] copy =
                new HairRootData[
                    component.Roots.Length];

            System.Array.Copy(
                component.Roots,
                copy,
                copy.Length);

            asset.SetRoots(
                copy);

            UnityEditor.EditorUtility
                .SetDirty(
                    asset);

            UnityEditor.AssetDatabase
                .SaveAssets();
        }
    }
}