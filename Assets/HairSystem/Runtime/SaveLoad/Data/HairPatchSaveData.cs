using UnityEngine;

namespace HairSystem.SaveLoad.Data
{
    [System.Serializable]
    public sealed class HairPatchSaveData
    {
        public int Width;

        public int Height;

        public Color32[] Pixels;
    }
}