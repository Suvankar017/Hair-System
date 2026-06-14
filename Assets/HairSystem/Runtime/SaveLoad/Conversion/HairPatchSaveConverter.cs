using UnityEngine;
using HairSystem.Data.Patches;
using HairSystem.SaveLoad.Data;

namespace HairSystem.SaveLoad.Conversion
{
    public static class HairPatchSaveConverter
    {
        public static HairPatchSaveData ToSaveData(HairPatchData patch)
        {
            HairPatchSaveData saveData = new()
            {
                Width = patch.Width,
                Height = patch.Height
            };

            Color32[] pixels = patch.GetPixels();

            saveData.Pixels = new Color32[pixels.Length];

            System.Array.Copy(pixels, saveData.Pixels, pixels.Length);

            return saveData;
        }

        public static HairPatchData ToRuntimeData(HairPatchSaveData saveData)
        {
            HairPatchData patch = new(saveData.Width, saveData.Height, default);

            Color32[] pixels = saveData.Pixels;

            int width = saveData.Width;

            int height = saveData.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;

                    patch.SetPixel(x, y, pixels[index]);
                }
            }

            return patch;
        }
    }
}