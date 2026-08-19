using System.Linq;
using UnityEngine;

namespace Jing.Feature.ShoppingStreet
{
    public class SkillShopView : BaseStoreView<SkillShop>
    {
        protected override void InitUISet()
        {
            unit_path = "SkillShop_Unit";
            base.InitUISet();
        }

        protected override void SetItemUnit(BaseStore_BtnInfo[] list)
        {
            SkillShopUnitView item;
            for (var i = 0; i < list.Length; i++)
            {
                SkillShop_BtnInfo info = (SkillShop_BtnInfo)list[i];
                item = pool.Get().GetComponent<SkillShopUnitView>();
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
                i.GetComponent<SkillShopUnitView>().Close();
            }
            base.GoBackToPool();
        }
    }
}