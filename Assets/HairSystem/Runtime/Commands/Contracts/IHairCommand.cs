namespace HairSystem.Commands.Contracts
{
    public interface IHairCommand
    {
        void Execute();

        void Undo();
    }
}