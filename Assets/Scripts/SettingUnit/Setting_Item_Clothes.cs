using UnityEngine;

using Jing.Tools.Localization;


namespace Jing.Setting
{
    [CreateAssetMenu(fileName = "Clothes", menuName = "Setting/Item/Unit/Clothes")]
    public class Setting_Item_Clothes : Setting_ItemBase, ISetting_Item_Sellable
    {
        [SerializeField] private Sprite purchasedImage;  //購買後的Icon
        [SerializeField] private Sprite characterPicture;  //換裝
        [SerializeField] private int price;
        [SerializeField] private string spine_name;

        public int Price => price;
        public Sprite PurchasedImage => purchasedImage;
        public Sprite CharacterPicture => characterPicture;
        public string Spine_Name => spine_name;


        public override string PreviewName => LocalizationManager.Get("Clothes", $"Clothes_Name_{Id}");

        public override string PreviewIntroduce => "目前衣服不知道有沒有資料";

    }
}
