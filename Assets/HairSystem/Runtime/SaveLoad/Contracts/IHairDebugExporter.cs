namespace HairSystem.SaveLoad.Contracts
{
    public interface IHairDebugExporter
    {
        string Export<T>(T value);
    }
}