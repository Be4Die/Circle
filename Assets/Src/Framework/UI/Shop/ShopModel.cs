using UnityEngine;
using Framework.UI.Collections;
using Framework.FSM.MainMenu;
using System.Collections.Generic;
using Framework.UI.Shop.Items;
using UnityEngine.UIElements;

namespace Framework.UI.Shop
{
    public class ShopModel : Model
    {
        private readonly string m_colorsResourcesPath = "Shop/Colors";
        private readonly string m_shapesResourcesPath = "Shop/Effects";
        private readonly string m_effectsResourcesPath = "Shop/Shapes";

        public List<ShopItemSO> Items { get; private set; }
        private Dictionary<string, ShopItem> m_storage = new Dictionary<string, ShopItem>();

        private MainMenuFSM m_fsm;

        public ShopModel(MainMenuFSM fsm)
        {
            m_fsm = fsm;
            Items = new List<ShopItemSO>();
            LoadItems(m_colorsResourcesPath);
            LoadItems(m_shapesResourcesPath);
            LoadItems(m_effectsResourcesPath);
        }

        public void AddItem(string name, ShopItem element)
        {
            m_storage[name] = element;
        }

        public void BackCallBack() => m_fsm.Back();

        private void LoadItems(string path)
        {
            foreach(var item in Resources.LoadAll<ShopItemSO>(path))
            {
                Items.Add(item);
            }
        }
    }
}
