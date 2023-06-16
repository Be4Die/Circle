using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Framework.UI.Shop.Items
{
    public abstract class ShopItemSO : ScriptableObject
    {
        public abstract string GetName();
        public abstract string GetTypeLiteral();
        public abstract int GetPrice();
        public abstract Sprite GetPreviewImage();
        public virtual Color GetPreviwTint() => Color.white;

        public abstract void AppedContent();
    }
}
