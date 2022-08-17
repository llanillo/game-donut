namespace Templates.Managers
{
    public interface IGameManager
    {
        ManagerStatus Status { get; }

        void Startup();
    }
}