using Templates.State_Machine;

public abstract class State
{
    protected StateMachine stateMachine;

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {
    }
}