using System;
using Jing.Feature.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Jing.Feature.ShoppingStreet
{
    public class SkillShopUnitView : BaseView
    {
        #region ::: GetUI :::
        private Button btn_buy => GetUI<Button>("Btn_LevelUp");
        private Image icon => GetUI<Image>("Icon");
        private TMP_Text skill_name => GetUI<TMP_Text>("Name");
        private TMP_Text introduce => GetUI<TMP_Text>("Introduce");
        private TMP_Text effect => GetUI<TMP_Text>("Effect");

        private TMP_Text price => GetUI<TMP_Text>("MoneyAmount");
        private TMP_Text owned => GetUI<TMP_Text>("OwnedLevel");

        #endregion

        private int id;
        private int nowOwnedMoney = 0;
        private Action<int> onBuy;


        public void Show(SkillShop_BtnInfo info, Action<int> action_buy, int nowOwnedMoney)
        {
            this.id = info.Id;
            this.nowOwnedMoney = nowOwnedMoney;

            icon.sprite = info.Icon;
            skill_name.text = info.Name;
            introduce.text = info.Content;
            effect.text = info.Effect;

            price.text = info.Price.ToString();
            price.color = (info.Price < nowOwnedMoney) ? Color.white : new Color32(0x96, 0x00, 0x00, 255);
            owned.text = info.Level.ToString();

            btn_buy.interactable = (info.Price < nowOwnedMoney) ? true : false;

            onBuy = action_buy;

            AddListener();
        }


        #region ::: Listener :::

        protected override void AddListener()
        {
            btn_buy.onClick.AddListener(BtnBuy);
        }

        protected override void RemoveListener()
        {
            btn_buy.onClick.RemoveListener(BtnBuy);
        }

        #endregion

        #region ::: 按鈕 :::
        public void BtnBuy()
        {
            onBuy?.Invoke(id);
        }
        #endregion
    }
}