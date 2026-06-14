using UnityEngine;

namespace HairSystem.SaveLoad.Data
{
    [System.Serializable]
    public struct HairPointSaveData
    {
        public Vector2 RestPosition;

        public float Width;

        public Color32 Color;
    }
}