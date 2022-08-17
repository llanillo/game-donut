using Templates.State_Machine;

namespace Player.Controllers.Others
{
    public class PlayerStateMachine : StateMachine
    {
        public override void ChangeState(State newState)
        {
            base.ChangeState(newState);
        }

        public override void Initialize(State newState)
        {
            base.Initialize(newState);
        }
    }
}