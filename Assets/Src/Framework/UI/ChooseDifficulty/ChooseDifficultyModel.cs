using Framework.FSM.MainMenu;


namespace Framework.UI.ChooseDifficulty
{
    using Collections;

    public class ChooseDifficultyModel : Model
    {
        private MainMenuFSM m_fsm;
        public ChooseDifficultyModel(MainMenuFSM fsm)
        {
            m_fsm = fsm;
        }

        public void BackCallBack() => m_fsm.Back();
    }
}
