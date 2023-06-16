using Framework.EffectSystem;
using UnityEngine;

namespace Framework.UI.Shop.Items
{
    [CreateAssetMenu(fileName = "new  EffectItem", menuName = "Circle/Shop/Create Effect Item")]
    class EffectItemSO : ShopItemSO
    {
        [SerializeField] private string m_name;
        [SerializeField] private Sprite m_preview;
        [SerializeField] private AvalibleEffects m_effect;
        [SerializeField] private int m_price;

        public override string GetName() => m_name;

        public override Sprite GetPreviewImage() => m_preview;
        public override int GetPrice() => m_price;
        public override string GetTypeLiteral() => "Effect";

        public override void AppedContent()
        {
            throw new System.NotImplementedException();
        }
    }
}
