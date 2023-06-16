using UnityEngine;

namespace Framework.FSM.MainMenu
{
    using Base;

    public class MainMenuFSM : MonoBehaviour
    {
        private readonly string m_mainMenuStateName = "EnterMainMenu";
        private readonly string m_easyModeStateName = "ChooseEasyMode";
        private readonly string m_mediumModeStateName = "ChooseMediumMode";
        private readonly string m_hardModeStateName = "ChooseHardMode";
        private readonly string m_shopStateName = "EnterShop";
        private readonly string m_chooseDifficultyStateName = "EnterChooseDifficulty";

        public FSM m_fsm;

        [Header("States")]
        [Space(10)]
        [Header("UI States")]
        [SerializeField] private SwitchUIState m_mainMenuState;
        [SerializeField] private SwitchUIState m_chooseDifficultyState;
        [SerializeField] private SwitchUIState m_shopState;
        [Space(5)]
        [Header("Difficulty Modes")]
        [SerializeField] private ModeState m_easyModeState;
        [SerializeField] private ModeState m_mediumModeState;
        [SerializeField] private ModeState m_hardModeState;

        private void Awake()
        {
            m_fsm = new FSM();

            m_fsm.AddState(m_mainMenuState, m_mainMenuStateName);
            m_fsm.AddState(m_chooseDifficultyState, m_chooseDifficultyStateName);
            m_fsm.AddState(m_easyModeState, m_easyModeStateName);
            m_fsm.AddState(m_shopState, m_shopStateName);
            m_fsm.AddState(m_mediumModeState, m_mediumModeStateName);
            m_fsm.AddState(m_hardModeState, m_hardModeStateName);
        }

        private void Start()
        {
            m_fsm.SetState(m_mainMenuStateName);
        }

        private void Update()
        {
            m_fsm.Update();
        }

        public void EnterShop() => m_fsm.SetState(m_shopStateName);
        public void Back() => m_fsm.SetState(m_mainMenuStateName);
        public void EnterChooseDifficulty() => m_fsm.SetState(m_chooseDifficultyStateName);
        public void PlayEasyMode() => m_fsm.SetState(m_easyModeStateName);
        public void PlayMediumMode() => m_fsm.SetState(m_mediumModeStateName);
        public void PlayHardMode() => m_fsm.SetState(m_hardModeStateName);

    }
}