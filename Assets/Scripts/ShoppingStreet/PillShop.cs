using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Jing.Setting;
using Jing.Tools.Localization;


namespace Jing.Feature.ShoppingStreet
{
    public class PillShop : BaseStore
    {
        public override void Get()
        {
            var items = itemSystem.GetSellingPills();
            dict = items.ToDictionary(item => item.ItemSetting.Id);

            Action_UpdateList?.Invoke(GetItemUnitList());
        }

        public override void Buy(int id)
        {

            var item = dict.GetValueOrDefault(id);
            if (item == null) { return; }

            itemSystem.IncreaseOwnedPills(id);
            playerInfoManager.UpdateMoney(((Setting_Item_Pill)item.ItemSetting).Price * -1);
        }


        #region ::: Listener :::
        protected override void AddListener()
        {
            itemSystem.Action_UpdatePill += UpdatePill;
        }

        protected override void RemoveListener()
        {
            itemSystem.Action_UpdatePill -= UpdatePill;
        }
        #endregion


        #region ::: Event :::

        private void UpdatePill(ItemDetail_Pills items)
        {
            var data = dict.GetValueOrDefault(items.Id);
            data.OwnedData = items;

            Action_UpdateList?.Invoke(GetItemUnitList());
        }
        #endregion

        #region :::  Private Methods :::
        private PillShop_BtnInfo[] GetItemUnitList()
        {
            return dict.OrderBy(id => id.Key)
                        .Select(data => new PillShop_BtnInfo
                        {
                            Id = data.Key,
                            Icon = data.Value.ItemSetting?.Icon,
                            Name = data.Value.ItemSetting?.PreviewName,
                            Content = data.Value.ItemSetting?.PreviewIntroduce,
                            Price = ((Setting_Item_Pill)data.Value.ItemSetting)?.Price ?? 0,
                            Owned = ((ItemDetail_Pills)data.Value.OwnedData)?.Count ?? 0,
                            Effect = GetEffectString(((Setting_Item_Pill)data.Value.ItemSetting).Reward),
                            isLock = false
                        })
            .ToArray();
        }

        private string GetEffectString(Setting_SomethingChange parameter)
        {

            //Do Something
            return string.Empty;
        }

        #endregion



    }

    public class PillShop_BtnInfo : BaseStore_BtnInfo
    {
        public int Price;
        public string Effect;
        public int Owned;

    }

}