using UnityEngine;
using Framework.UI.Collections;
using Framework.FSM.MainMenu;


namespace Framework.UI.MainMenu
{
    public class MainMenuModel : Model
    {
        private MainMenuFSM m_fsm;
        public MainMenuModel(MainMenuFSM fsm)
        {
            m_fsm = fsm;
        }

        public void PlayButtonCallback() => m_fsm.EnterChooseDifficulty();
        public void ShopButtonCallback() => m_fsm.EnterShop();
        public void TelegramButtonCallback() { Debug.Log("TELEGRAM CLICKED"); }
        public void GithubButtonCallback() { Debug.Log("GITHUB CLICKED"); }
    }
}
