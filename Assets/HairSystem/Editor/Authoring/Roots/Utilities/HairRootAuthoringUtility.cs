using HairSystem.Authoring.Roots;
using HairSystem.Data.Roots;

namespace HairSystem.EditorTools.Authoring.Roots.Utilities
{
    public static class HairRootAuthoringUtility
    {
        public static void LoadFromAsset(
            HairRootAuthoringBehaviour component)
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
            HairRootAuthoringBehaviour component)
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