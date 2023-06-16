using Framework.UI.Shop.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

namespace Framework.UI.Shop
{
    public enum ShopItemState
    {
        Active,
        Unactive,
        Notbuyed
    }

    public class ShopItem
    {
        private readonly string m_itemTypeLiteral = "ProductType";
        private readonly string m_itemNameLiteral = "ProductName";
        private readonly string m_itemPriceLiteral = "ProductPrice";
        private readonly string m_itemPreviewLiteral = "Item";
        private readonly string m_buyButtonLiteral = "Buy";
        private readonly string m_interactionButtonLiteral = "Interaction";

        private readonly string m_activeStyleLiteral = ".active";
        private readonly string m_unactiveStyleLiteral = ".unactive";

        private VisualElement m_element;
        private ShopItemSO m_itemData;
        private ShopItemState m_state;

        // cached
        private Button m_buyButton;
        private Button m_interactionButton;
        private Label m_priceLabel;

        public ShopItem(VisualElement element, ShopItemSO shopItem, ShopItemState state = ShopItemState.Notbuyed)
        {
            m_element = element;
            m_itemData = shopItem;

            RegisterUI();

            SetState(state);
            m_buyButton = m_element.Q<Button>(m_buyButtonLiteral);
            m_interactionButton = m_element.Q<Button>(m_interactionButtonLiteral);
        }


        public void SetState(ShopItemState state)
        {
            m_state = state;

            switch (m_state)
            {
                case ShopItemState.Notbuyed:
                    m_buyButton.style.display = DisplayStyle.Flex;
                    m_interactionButton.style.display = DisplayStyle.None;
                    m_priceLabel.style.display = DisplayStyle.Flex;
                    break;

                case ShopItemState.Active:
                    m_buyButton.style.display = DisplayStyle.None;
                    m_interactionButton.style.display = DisplayStyle.Flex;
                    m_interactionButton.AddToClassList(m_activeStyleLiteral);
                    m_interactionButton.RemoveFromClassList(m_unactiveStyleLiteral);
                    m_priceLabel.style.display = DisplayStyle.None;
                    break;

                case ShopItemState.Unactive:
                    m_buyButton.style.display = DisplayStyle.None;
                    m_interactionButton.style.display = DisplayStyle.Flex;
                    m_interactionButton.AddToClassList(m_unactiveStyleLiteral);
                    m_interactionButton.RemoveFromClassList(m_activeStyleLiteral);
                    m_priceLabel.style.display = DisplayStyle.None;
                    break;

                default: throw new NotImplementedException();
            }
        }

        private void RegisterUI()
        {
            m_element.Q<Label>(m_itemNameLiteral).text = m_itemData.GetName();
            m_element.Q<Label>(m_itemTypeLiteral).text = m_itemData.GetTypeLiteral();
            m_priceLabel = m_element.Q<Label>(m_itemPriceLiteral);
            m_priceLabel.text = m_itemData.GetPrice().ToString() + "*";
            var preview = m_element.Q<VisualElement>(m_itemPreviewLiteral);
            preview.style.backgroundImage = new StyleBackground(m_itemData.GetPreviewImage());
            preview.style.unityBackgroundImageTintColor = m_itemData.GetPreviwTint();
        }
    }

}
