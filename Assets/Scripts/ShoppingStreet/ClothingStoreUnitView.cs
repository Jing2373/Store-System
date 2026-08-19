using System;
using Jing.Feature.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jing.Feature.ShoppingStreet
{
    public class ClothingStoreUnitView : BaseView
    {

        #region ::: GetUI :::
        private Button btn_buy => GetUI<Button>("Btn_Buy");
        private Button clothing => GetUI<Button>("ClothingStore_Unit");
        private TMP_Text clothing_name => GetUI<TMP_Text>("ClothesName");

        private TMP_Text price => GetUI<TMP_Text>("Price");
        private Transform owned => GetUI<Transform>("Owned");

        #endregion

        private int id;
        private Action<int> onBuy;

        private Transform name_parent = null;
        private Transform price_parent = null;


        /// <summary>
        /// 顯示
        /// </summary>
        public void Show(ClothingStore_BtnInfo info, Action<int> onBuy)
        {

            InitGetSomething();
            id = info.Id;
            if (info.Owned)
            {
                clothing.image.sprite = info.Icon;
                Purchased(info.PurchasedImage);
            }
            else
            {
                this.onBuy = onBuy;
                clothing.image.sprite = info.Icon;
                clothing_name.text = info.Name;
                price.text = info.Price.ToString();
                owned.gameObject.SetActive(false);
                AddListener();
            }
        }

        public override void Show() { }
        /// <summary>
        /// 關閉
        /// </summary>
        public override void Close()
        {
            RemoveListener();
            Reset();
        }

        public void Purchased(Sprite bg)
        {
            name_parent.gameObject.SetActive(false);
            price_parent.gameObject.SetActive(false);
            owned.gameObject.SetActive(true);
            clothing.image.sprite = bg;

        }

        #region ::: Listener 監聽 :::

        private void AddListener()
        {
            btn_buy.onClick.AddListener(BtnBuy);
        }

        private void RemoveListener()
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

        #region ::: Private Methods :::

        private void InitGetSomething()
        {
            if (name_parent == null)
            {
                name_parent = clothing_name.transform.parent;
            }

            if (price_parent == null)
            {
                price_parent = price.transform.parent;
            }

        }
        private void Reset()
        {
            InitGetSomething();
            if (!price_parent.gameObject.activeSelf)
            {
                price_parent.gameObject.SetActive(true);
            }
            if (!name_parent.gameObject.activeSelf)
            {
                name_parent.gameObject.SetActive(true);
            }
            if (!owned.gameObject.activeSelf)
            {
                owned.gameObject.SetActive(false);
            }

        }

        #endregion
    }
}
