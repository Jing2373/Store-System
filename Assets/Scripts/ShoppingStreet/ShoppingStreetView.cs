using UnityEngine.UI;

using Jing.Feature.UI;
using VContainer;

namespace Jing.Feature.ShoppingStreet
{

    public class ShoppingStreetView : BaseView
    {

        #region ::: GetUI :::
        private Button btn_Back => GetUI<Button>("Btn_Back");
        private Button btn_ClothingStore => GetUI<Button>("Btn_ClothingStore");
        private Button btn_SkillShop => GetUI<Button>("Btn_SkillShop");
        private Button btn_PillShop => GetUI<Button>("Btn_PillShop");


        #endregion

        #region ::: Inject :::
        private IUIManager uiManager;

        [Inject]
        public void Construct(IUIManager uiManager)
        {
            this.uiManager = uiManager;
        }

        #endregion

        #region ::: Override :::

        public override void Show()
        {
            AddListener();
        }

        public override void Close()
        {
            RemoveListener();
        }

        #endregion

        #region ::: Listener 監聽 :::

        protected override void AddListener()
        {
            btn_Back.onClick.AddListener(BtnBack);
            btn_ClothingStore.onClick.AddListener(BtnClothingStore);
            btn_SkillShop.onClick.AddListener(BtnSkillShop);
            btn_PillShop.onClick.AddListener(BtnPillShop);
        }

        protected override void RemoveListener()
        {
            btn_Back.onClick.RemoveListener(BtnBack);
            btn_ClothingStore.onClick.RemoveListener(BtnClothingStore);
            btn_SkillShop.onClick.RemoveListener(BtnSkillShop);
            btn_PillShop.onClick.RemoveListener(BtnPillShop);
        }

        #endregion

        #region ::: Button :::

        private void BtnBack()
        {
            uiManager.Back();
        }

        private void BtnClothingStore()
        {
            uiManager.ShowPage("ClothingStore");
        }

        private void BtnSkillShop()
        {
            uiManager.ShowPage("SkillShop");
        }

        private void BtnPillShop()
        {
            uiManager.ShowPage("PillShop");
        }
        #endregion

    }
}