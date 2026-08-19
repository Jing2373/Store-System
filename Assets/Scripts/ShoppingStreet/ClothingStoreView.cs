using UnityEngine;
using UnityEngine.UI;


namespace Jing.Feature.ShoppingStreet
{
    public class ClothingStoreView : BaseStoreView<ClothingStore>
    {

        protected override void InitUISet()
        {
            unit_path = "ClothingStore_Unit";
            base.InitUISet();
        }

        protected override void SetItemUnit(BaseStore_BtnInfo[] list)
        {
            ClothingStoreUnitView item;
            for (var i = 0; i < list.Length; i++)
            {
                ClothingStore_BtnInfo info = (ClothingStore_BtnInfo)list[i];
                item = pool.Get().GetComponent<ClothingStoreUnitView>();
                item.Show(info, ConfirmPurchase);

                item.gameObject.transform.SetParent(list_parent);
                item.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
                item.gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
            }
        }
        protected override void GoBackToPool()
        {
            var list = pool.GetUsingList();
            foreach (var i in list)
            {
                i.GetComponent<ClothingStoreUnitView>().Close();
            }

            base.GoBackToPool();
        }

    }
}