using UnityEngine;

namespace Framework.UI.Shop.Items
{
    [CreateAssetMenu(fileName = "new  ShapeItem", menuName = "Circle/Shop/Create Shape Item")]
    public class ShapeItemSO : ShopItemSO
    {

        [SerializeField] private string m_name;

        [SerializeField] private Sprite m_shape;
        [SerializeField] private int m_price;

        public override string GetName() => m_name;
        public override string GetTypeLiteral() => "Shape";
        public override int GetPrice() => m_price;
        public override Sprite GetPreviewImage() => m_shape;

        public override void AppedContent()
        {
            throw new System.NotImplementedException();
        }
    }
}
