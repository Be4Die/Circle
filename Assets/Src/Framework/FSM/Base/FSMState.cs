namespace Framework.FSM.Base
{
    public abstract class FSMState
    {
        protected readonly FSM m_fsm;

        public FSMState(FSM fsm)
        {
            m_fsm = fsm;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
