using HairSystem.Data.Characters;
using HairSystem.SaveLoad.Binary;
using HairSystem.SaveLoad.Contracts;
using HairSystem.SaveLoad.Conversion;
using HairSystem.SaveLoad.Data;
using HairSystem.SaveLoad.Restore;
using HairSystem.SaveLoad.Storage;

namespace HairSystem.SaveLoad.Services
{
    public sealed class HairSaveService
    {
        private readonly IHairSerializer _serializer;

        private readonly IHairSaveStorage _storage;

        private readonly HairSavePathProvider _pathProvider;

        public HairSaveService(
            IHairSerializer serializer,
            IHairSaveStorage storage,
            HairSavePathProvider pathProvider)
        {
            _serializer =
                serializer;

            _storage =
                storage;

            _pathProvider =
                pathProvider;
        }

        public void Save(
            HairCharacterData character,
            HairSaveSlot slot)
        {
            HairCharacterSaveData saveData =
                HairCharacterSaveConverter
                    .ToSaveData(
                        character);

            byte[] bytes =
                _serializer.Serialize(
                    saveData);

            string path =
                _pathProvider.GetPath(
                    slot);

            string tempPath =
                path + ".tmp";

            _storage.Write(
                tempPath,
                bytes);

            _storage.Replace(
                tempPath,
                path);
        }

        public bool Load(
            HairCharacterData character,
            HairSaveSlot slot)
        {
            string path =
                _pathProvider.GetPath(
                    slot);

            if (!_storage.Exists(
                path))
            {
                return false;
            }

            byte[] bytes =
                _storage.Read(
                    path);

            HairCharacterSaveData saveData =
                _serializer.Deserialize<
                    HairCharacterSaveData>(
                        bytes);

            HairCharacterRestoreUtility
                .Restore(
                    character,
                    saveData);

            return true;
        }

        public bool Exists(
            HairSaveSlot slot)
        {
            return _storage.Exists(
                _pathProvider.GetPath(
                    slot));
        }

        public void Delete(
            HairSaveSlot slot)
        {
            _storage.Delete(
                _pathProvider.GetPath(
                    slot));
        }
    }
}