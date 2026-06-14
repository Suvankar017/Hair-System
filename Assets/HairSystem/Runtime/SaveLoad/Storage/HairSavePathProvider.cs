using System.IO;
using UnityEngine;
using HairSystem.SaveLoad.Data;

namespace HairSystem.SaveLoad.Storage
{
    public sealed class HairSavePathProvider
    {
        private const string FolderName = "HairSystem";

        private const string Extension = ".hsav";

        public string GetPath(HairSaveSlot slot)
        {
            string folder =
                Path.Combine(Application.persistentDataPath, FolderName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return Path.Combine(folder, $"slot_{slot.Index}{Extension}");
        }
    }
}