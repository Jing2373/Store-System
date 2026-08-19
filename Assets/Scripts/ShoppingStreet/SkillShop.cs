using System.Collections.Generic;
using System.Linq;
using Jing.Setting;

namespace Jing.Feature.ShoppingStreet
{
    public class SkillShop : BaseStore
    {
        public override void Get()
        {
            var items = itemSystem.GetSellingSkills();
            dict = items.ToDictionary(item => item.ItemSetting.Id);

            Action_UpdateList?.Invoke(GetItemUnitList());
        }

        public override void Buy(int id)
        {
            var item = dict.GetValueOrDefault(id);
            if (item == null) { return; }

            itemSystem.AddOwnedSkillsLevel(id);

            Setting_Item_Skill skill = (Setting_Item_Skill)item.ItemSetting;
            ItemDetail_Skills detail = (ItemDetail_Skills)item.OwnedData;
            playerInfoManager.UpdateMoney(skill.LevelData[detail.Level].Price * -1);
        }


        #region ::: Listener :::
        protected override void AddListener()
        {
            itemSystem.Action_UpdateSkill += UpdateSkill;
        }

        protected override void RemoveListener()
        {
            itemSystem.Action_UpdateSkill -= UpdateSkill;
        }
        #endregion


        #region :::  Event :::

        private void UpdateSkill(ItemDetail_Skills items)
        {
            var data = dict.GetValueOrDefault(items.Id);
            data.OwnedData = items;

            Action_UpdateList?.Invoke(GetItemUnitList());
        }
        #endregion

        #region :::  Private Methods :::
        private SkillShop_BtnInfo[] GetItemUnitList()
        {

            return dict.OrderBy(id => id.Key)
                .Select(data =>
                {

                    var skillData = data.Value.OwnedData as ItemDetail_Skills;
                    var lv = skillData?.Level ?? 0;

                    var skillSetting = data.Value.ItemSetting as Setting_Item_Skill;
                    UpgradeableLevelData upgradeable = skillSetting?.LevelData?.FirstOrDefault(x => x.Level == lv + 1);

                    return new SkillShop_BtnInfo
                    {
                        Id = data.Key,
                        Icon = data.Value.ItemSetting?.Icon,
                        Name = data.Value.ItemSetting?.PreviewName,
                        Content = data.Value.ItemSetting?.PreviewIntroduce,

                        Price = upgradeable?.Price ?? 0,
                        Level = lv,

                        Effect = GetEffectString(upgradeable?.Bonus),

                    };
                })
                .ToArray();
        }


        private string GetEffectString(Setting_SomethingChange reward)
        {
            //Do Something
            return string.Empty;
        }


        #endregion
    }



    public class SkillShop_BtnInfo : BaseStore_BtnInfo
    {
        public int Price;
        public int Level;
        public string Effect;
        public bool Lock;
    }
}