using System.Collections.Generic;

namespace Framework.FSM.Base
{
    public class FSM
    {
        public FSMState CurrentState { get; private set; }
        public string CurrentStateName { get; private set; }

        private Dictionary<string, FSMState> m_states = new Dictionary<string, FSMState>();

        public virtual void AddState(FSMState state, string name)
        {
            m_states.Add(name, state);
        }

        public virtual void SetState(string name)
        {
            if (CurrentStateName == name)
                return;
            if (m_states.TryGetValue(name, out var newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
                CurrentStateName = name;

            }
        }

        public virtual void Update() => CurrentState?.Update();
    }
}
