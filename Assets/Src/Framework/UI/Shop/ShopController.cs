using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using Framework.UI.Collections;
using Framework.FSM.MainMenu;
using Framework.UI.Shop;
using Framework.UI.Shop.Items;
using static UnityEngine.Rendering.DebugUI.MessageBox;

namespace Framework.UI.MainMenu
{
    public class ShopController : MonoController<ShopModel>
    {
        private readonly string m_backButtonLiteral = "Back";
        private readonly string m_shopItemsListLiteral = "ShopItems";

        [Inject] private MainMenuFSM m_fsm;

        [SerializeField] private VisualTreeAsset m_shopItemTemplate;

        protected override void BindElements()
        {
            m_root.Q<Button>(m_backButtonLiteral).clicked += m_model.BackCallBack;
        }

        protected override void RegistrDynamicUI()
        {
            var itemsContainer = m_root.Q<ScrollView>(m_shopItemsListLiteral);
            foreach (var item in m_model.Items)
            {
                var (element, shopItem) = CreateShopItem(item);
                itemsContainer.Add(element);
                m_model.AddItem(item.GetName(), shopItem);
            }
        }

        protected override ShopModel RegisterModel() => new ShopModel(m_fsm);

        private (VisualElement, ShopItem) CreateShopItem(ShopItemSO item)
        {
            TemplateContainer container = m_shopItemTemplate.Instantiate();
            var shopItem = new ShopItem(container, item);
            return (container, shopItem);
        }
    }
}