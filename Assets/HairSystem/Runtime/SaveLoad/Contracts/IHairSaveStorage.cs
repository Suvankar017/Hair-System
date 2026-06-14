namespace HairSystem.SaveLoad.Contracts
{
    public interface IHairSaveStorage
    {
        void Write(string path, byte[] data);

        byte[] Read(string path);

        bool Exists(string path);

        void Delete(string path);

        void Replace(string sourcePath, string destinationPath);
    }
}
