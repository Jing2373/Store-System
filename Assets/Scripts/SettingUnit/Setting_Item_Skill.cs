using UnityEngine;

using Jing.Tools.Localization;


namespace Jing.Setting
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Setting/Item/Unit/Skill")]
    public class Setting_Item_Skill : Setting_ItemBase, ISetting_Item_Upgradeable
    {
        [SerializeField] private UpgradeableLevelData[] levelData;

        public override string PreviewName => LocalizationManager.Get("Skills", $"Skills_Name_{Id}");

        public override string PreviewIntroduce => LocalizationManager.Get("Skills", $"Skills_Introduce_{Id}");

        public UpgradeableLevelData[] LevelData => levelData;
    }

}
