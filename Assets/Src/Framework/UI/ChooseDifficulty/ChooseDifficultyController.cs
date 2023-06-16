using Framework.FSM.MainMenu;
using Framework.UI.Shop;
using UnityEngine.UIElements;
using Zenject;


namespace Framework.UI.ChooseDifficulty
{
    using Collections;

    public class ChooseDifficultyController : MonoController<ChooseDifficultyModel>
    {
        private readonly string m_backButtonLiteral = "Back";

        [Inject] private MainMenuFSM m_fsm;

        protected override void BindElements()
        {
            m_root.Q<Button>(m_backButtonLiteral).clicked += m_model.BackCallBack;
        }

        protected override ChooseDifficultyModel RegisterModel() => new ChooseDifficultyModel(m_fsm);
    }
}
