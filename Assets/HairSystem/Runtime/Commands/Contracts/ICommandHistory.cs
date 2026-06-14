namespace HairSystem.Commands.Contracts
{
    public interface ICommandHistory
    {
        void Execute(IHairCommand command);

        bool CanUndo();

        bool CanRedo();

        void Undo();

        void Redo();

        void Clear();
    }
}