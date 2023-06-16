using UnityEngine;

namespace Framework.UI.Shop.Items
{
    [CreateAssetMenu(fileName = "new  ColorItem", menuName = "Circle/Shop/Create Color Item")]
    public class ColorItemSO : ShopItemSO
    {
        [SerializeField] private string m_name;
        [SerializeField] private Sprite m_preview;
        [SerializeField] private Color m_color;
        [SerializeField] private int m_price;

        public override string GetName() => m_name;

        public override Sprite GetPreviewImage() => m_preview;
        public override Color GetPreviwTint() => m_color;
        public override int GetPrice() => m_price;
        public override string GetTypeLiteral() => "Color";

        public override void AppedContent()
        {
            throw new System.NotImplementedException();
        }
    }
}
