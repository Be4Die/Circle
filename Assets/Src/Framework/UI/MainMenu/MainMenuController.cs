using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using Framework.UI.Collections;
using Framework.FSM.MainMenu;


namespace Framework.UI.MainMenu
{
    public class MainMenuController : MonoController<MainMenuModel>
    {
        private readonly string m_playButtonLiteral = "Play";
        private readonly string m_shopButtonLiteral = "Shop";
        private readonly string m_telegramButtonLiteral = "Telegram";
        private readonly string m_githubButtonLiteral = "Github";

        [Inject] private MainMenuFSM m_fsm;

        protected override void BindElements()
        {
            m_root.Q<Button>(m_playButtonLiteral).clicked += m_model.PlayButtonCallback;
            m_root.Q<Button>(m_shopButtonLiteral).clicked += m_model.ShopButtonCallback;
            m_root.Q<Button>(m_telegramButtonLiteral).clicked += m_model.TelegramButtonCallback;
            m_root.Q<Button>(m_githubButtonLiteral).clicked += m_model.GithubButtonCallback;
        }

        protected override MainMenuModel RegisterModel() => new MainMenuModel(m_fsm);
    }
}