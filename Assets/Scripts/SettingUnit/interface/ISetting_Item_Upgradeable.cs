using UnityEngine;

namespace Jing.Setting
{
    public interface ISetting_Item_Upgradeable
    {
        UpgradeableLevelData[] LevelData { get; }

        bool IsMax(int level) { return level == LevelData.Length; }

    }

    [System.Serializable]
    public class UpgradeableLevelData : ISetting_Item_Reward
    {
        public int Level;
        public int Price;
        public Setting_SomethingChange Bonus;

        public Setting_SomethingChange Reward => Bonus;
    }

}