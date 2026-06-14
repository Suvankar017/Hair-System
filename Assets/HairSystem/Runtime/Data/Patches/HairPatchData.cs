using UnityEngine;

namespace HairSystem.Data.Patches
{
    [System.Serializable]
    public sealed class HairPatchData
    {
        private readonly int _width;

        private readonly int _height;

        private readonly Color32[] _pixels;

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
        }

        public HairPatchData(int width, int height, Color32 defaultColor)
        {
            _width = Mathf.Max(1, width);

            _height = Mathf.Max(1, height);

            _pixels = new Color32[_width * _height];

            for (int i = 0; i < _pixels.Length; i++)
            {
                _pixels[i] = defaultColor;
            }
        }

        public int GetIndex(int x, int y)
        {
            return y * _width + x;
        }

        public Color32 GetPixel(int x, int y)
        {
            return _pixels[GetIndex(x, y)];
        }

        public void SetPixel(int x, int y, Color32 color)
        {
            _pixels[GetIndex(x, y)] = color;
        }

        public Color32[] GetPixels()
        {
            return _pixels;
        }
    }
}