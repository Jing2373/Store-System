using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Jing.Setting;

//Clothing Store
namespace Jing.Feature.ShoppingStreet
{
    public class ClothingStore : BaseStore
    {

        /// <summary>
        /// Get clothes sold in the store (determined by whether they have a price).
        /// </summary>
        public override void Get()
        {
            var items = itemSystem.GetSellingClothes();
            foreach (var i in items)
            {
                Debug.Log("id=" + i.ItemSetting.Id + "," + ((ItemDetail_Clothes)i.OwnedData).Owned);
            }
            dict = items.ToDictionary(item => item.ItemSetting.Id);

            Action_UpdateList?.Invoke(GetItemUnitList());

        }

        public override void Buy(int id)
        {
            var item = dict.GetValueOrDefault(id);
            if (item == null) { return; }

            itemSystem.IncreaseOwnedPills(id);
            playerInfoManager.UpdateMoney(((Setting_Item_Clothes)item.ItemSetting).Price * -1);

            itemSystem.UnlockOwnedClothes(id);
            playerInfoManager.UpdateMoney(itemSystem.GetClothesByID(id).Price * -1);

        }

        #region ::: Listener :::
        protected override void AddListener()
        {
            itemSystem.Action_UpdateClothes += UpdateClothes;
        }

        protected override void RemoveListener()
        {
            itemSystem.Action_UpdateClothes -= UpdateClothes;
        }
        #endregion

        #region :::  Event :::

        private void UpdateClothes(ItemDetail_Clothes items)
        {
            Debug.Log("UpdateClothes");
            var data = dict.GetValueOrDefault(items.Id);
            data.OwnedData = items;

            Action_UpdateList?.Invoke(GetItemUnitList());
        }
        #endregion



        #region :::  Private Methods :::
        private ClothingStore_BtnInfo[] GetItemUnitList()
        {
            return dict.OrderBy(id => id.Key)
                        .Select(data => new ClothingStore_BtnInfo
                        {
                            Id = data.Key,
                            Icon = data.Value.ItemSetting.Icon,
                            Name = data.Value.ItemSetting.PreviewName,
                            Price = ((Setting_Item_Clothes)data.Value.ItemSetting).Price,
                            Owned = ((ItemDetail_Clothes)data.Value.OwnedData).Owned,
                            PurchasedImage = ((Setting_Item_Clothes)data.Value.ItemSetting).PurchasedImage
                        })
            .ToArray();
        }
        #endregion
    }

    public class ClothingStore_BtnInfo : BaseStore_BtnInfo
    {
        public bool Owned;
        public int Price;

        public Sprite PurchasedImage;
    }
}