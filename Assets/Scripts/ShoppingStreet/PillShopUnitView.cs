using System;
using Jing.Feature.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Jing.Feature.ShoppingStreet
{
    public class PillShopUnitView : BaseView
    {
        #region ::: GetUI :::
        private Button btn_buy => GetUI<Button>("Btn_Buy");
        private Image icon => GetUI<Image>("Icon");
        private TMP_Text pill_name => GetUI<TMP_Text>("Name");
        private TMP_Text introduce => GetUI<TMP_Text>("Introduce");
        private TMP_Text effect => GetUI<TMP_Text>("Effect");

        private TMP_Text price => GetUI<TMP_Text>("MoneyAmount");
        private TMP_Text owned => GetUI<TMP_Text>("OwnAmount ");

        private Image unitLock => GetUI<Image>("UnitLock");
        #endregion


        public int id = 0;
        private int nowOwnedMoney = 0;
        private Action<int> onBuy;


        public void Show(PillShop_BtnInfo info, Action<int> action_buy, int nowOwnedMoney)
        {
            this.id = info.Id;
            this.nowOwnedMoney = nowOwnedMoney;

            icon.sprite = info.Icon;
            pill_name.text = info.Name;
            introduce.text = info.Content;
            effect.text = info.Effect;
            price.text = info.Price.ToString();
            price.color = (info.Price < nowOwnedMoney) ? Color.white : new Color32(0x96, 0x00, 0x00, 255);
            owned.text = info.Owned.ToString();
            unitLock.gameObject.SetActive(info.isLock);

            btn_buy.interactable = (info.Price < nowOwnedMoney) ? true : false;

            onBuy = action_buy;

            AddListener();
        }

        public override void Show()
        {

        }

        public override void Close()
        {
            RemoveListener();
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

        #region ::: Button :::
        public void BtnBuy()
        {
            onBuy?.Invoke(id);
        }
        #endregion
    }
}