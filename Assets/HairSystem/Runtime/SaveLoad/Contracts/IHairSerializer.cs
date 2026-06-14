namespace HairSystem.SaveLoad.Contracts
{
    public interface IHairSerializer
    {
        byte[] Serialize<T>(T value);

        T Deserialize<T>(byte[] data);
    }
}