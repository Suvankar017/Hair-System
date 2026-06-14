using System.IO;
using UnityEngine;
using HairSystem.SaveLoad.Contracts;

namespace HairSystem.SaveLoad.Storage
{
    public sealed class HairFileSaveStorage : IHairSaveStorage
    {
        public void Write(string path, byte[] data)
        {
            File.WriteAllBytes(path, data);
        }

        public byte[] Read(string path)
        {
            return File.ReadAllBytes(path);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public void Delete(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            File.Delete(path);
        }

        public void Replace(string sourcePath, string destinationPath)
        {
            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }

            File.Move(sourcePath, destinationPath);
        }
    }
}