namespace HairSystem.Tools.Contracts
{
    public interface IHairTool
    {
        string Name { get; }

        void Begin();

        void Update();

        void End();
    }
}