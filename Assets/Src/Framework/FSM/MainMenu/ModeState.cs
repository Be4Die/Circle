using UnityEngine;
using Framework.PlayMode;
using System;

namespace Framework.FSM.MainMenu
{
    using Base;

    [Serializable]
    public class ModeState : FSMState
    {
        [SerializeField] private PlayModeDifficilty m_difficilty;
        public ModeState(FSM fsm) : base(fsm) { }

        public override void Enter()
        {
            PlayModeManagment.EntryPlayMode(m_difficilty);
        }
    }
}