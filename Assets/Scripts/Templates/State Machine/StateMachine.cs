namespace Templates.State_Machine
{
    public abstract class StateMachine
    {
        public State CurrentState { get; private set; }

        public virtual void Initialize(State newState)
        {
            CurrentState = newState;
            CurrentState.Enter();
        }

        public virtual void ChangeState(State newState)
        {
            CurrentState.Exit();

            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}