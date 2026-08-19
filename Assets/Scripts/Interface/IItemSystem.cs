using System;
using Jing.Setting;
using UnityEngine;

namespace Jing.Feature.GameItemSystem
{
    public interface IItemSystem
    {
        #region ::: Action :::
        Action<ItemDetail_Pills> Action_UpdatePill { get; set; }
        Action<ItemDetail_Skills> Action_UpdateSkill { get; set; }
        Action<ItemDetail_Clothes> Action_UpdateClothes { get; set; }
        Action<ItemType, int, string, Sprite, string, int> Action_ItemDetail { get; set; }

        #endregion

        #region ::: Skill :::
        void AddOwnedSkillsLevel(int id);
        int CheckSkillPrice(int id);
        int GetOwnedSkillLevel(int id);
        ItemShowData[] GetOwnedSkills();
        string GetPillEffectById(int id);
        ItemShowData[] GetSellingSkills();
        #endregion

        #region ::: Pill :::
        void DecreaseOwnedPills(int id, int count = 1);
        int GetOwnedPillCount(int id);
        ItemShowData[] GetOwnedPills();
        Setting_Item_Pill GetPillById(int id);
        ItemShowData[] GetSellingPills();
        void IncreaseOwnedPills(int id, int count = 1);
        #endregion

        #region ::: Clothes :::
        ItemShowData[] GetClothes();
        Setting_Item_Clothes GetClothesByID(int id);
        ItemShowData[] GetSellingClothes();
        bool IsClothingUnlocked(int id);
        void UnlockOwnedClothes(int id);
        #endregion


    }
    public class ItemShowData
    {
        public ItemDetailBase OwnedData;
        public Setting_ItemBase ItemSetting;

    }

    public enum ItemType
    {
        Pill,
        Skill,
        Clothes,
    }

}