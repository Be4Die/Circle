using UnityEngine;
using UnityEngine.UIElements;
using System;

namespace Framework.FSM.MainMenu
{
    using Base;

    [Serializable]
    public class SwitchUIState : FSMState
    {
        [SerializeField] private UIDocument m_ui;
        public SwitchUIState(FSM fsm) : base(fsm) { }

        public override void Enter()
        {
            if (m_ui.enabled == false)
                m_ui.enabled = true;

            m_ui.rootVisualElement.style.display = DisplayStyle.Flex;
        }

        public override void Exit()
        {
            m_ui.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}
