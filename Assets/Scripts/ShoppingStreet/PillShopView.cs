using System.Collections.Generic;
using UnityEngine;

namespace Jing.Feature.ShoppingStreet
{
    public class PillShopView : BaseStoreView<PillShop>
    {
        protected override void InitUISet()
        {
            unit_path = "PillShop_Unit";
            base.InitUISet();
        }

        protected override void SetItemUnit(BaseStore_BtnInfo[] list)
        {
            PillShopUnitView item;
            for (var i = 0; i < list.Length; i++)
            {
                PillShop_BtnInfo info = (PillShop_BtnInfo)list[i];
                item = pool.Get().GetComponent<PillShopUnitView>();
                item.Show(info, ConfirmPurchase, playerInfoManager.Money);

                item.gameObject.transform.SetParent(list_parent);
                item.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
                item.gameObject.GetComponent<RectTransform>().localScale = Vector3.one;

                item.transform.SetSiblingIndex(i);
            }
        }

        protected override void GoBackToPool()
        {
            var list = pool.GetUsingList();

            foreach (var i in list)
            {
                i.GetComponent<PillShopUnitView>().Close();
            }

            base.GoBackToPool();
        }

    }
}