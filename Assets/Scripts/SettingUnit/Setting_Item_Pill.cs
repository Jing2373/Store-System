using UnityEngine;

using Jing.Tools.Localization;

namespace Jing.Setting
{
    [CreateAssetMenu(fileName = "Pill", menuName = "Setting/Item/Unit/Pill")]
    public class Setting_Item_Pill : Setting_ItemBase, ISetting_Item_Sellable, ISetting_Item_Reward
    {

        [SerializeField] private int price;
        public int Price => price;


        [SerializeField] private Setting_SomethingChange bonus;
        public Setting_SomethingChange Reward => bonus;

        public override string PreviewName => LocalizationManager.Get("Pills", $"Pills_Name_{Id}");

        public override string PreviewIntroduce => LocalizationManager.Get("Pills", $"Pills_Introduce_{Id}");


    }


}

