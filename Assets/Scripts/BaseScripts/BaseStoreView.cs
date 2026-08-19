using UnityEngine;
using UnityEngine.UI;
using VContainer;

using Jing.Feature.UI;
using Jing.Tools;
using Cysharp.Threading.Tasks;
using Jing.Feature.InfomationManager;
using Jing.Tools.Extensions;

namespace Jing.Feature.ShoppingStreet
{
    public class BaseStoreView<T> : BaseView where T : BaseStore
    {

        #region ::: GetUI :::
        protected Button btn_Back => GetUI<Button>("Btn_Back");
        protected Transform list_parent => GetUI<Transform>("Content");
        #endregion
        protected string unit_path = string.Empty;  //商品的Unit
        protected PoolManager pool;
        protected int nowChooseId = -1;
        protected string nowChooseName = string.Empty;
        private InjectChildrenGameObject inject = new();

        #region ::: Inject :::
        private IObjectResolver resolver;
        private IUIManager uiManager;
        protected T vm;
        protected IPlayerInfoManager playerInfoManager;
        private IAddressableTools addressableTools;

        [Inject]
        public virtual void Construct(IObjectResolver resolver, IUIManager uiManager, T vm,
        IPlayerInfoManager playerInfoManager, IAddressableTools addressableTools)
        {
            this.resolver = resolver;
            this.uiManager = uiManager;
            this.vm = vm;
            this.playerInfoManager = playerInfoManager;
            this.addressableTools = addressableTools;
        }

        #endregion

        #region ::: Override :::

        public override void Show()
        {
            inject.InjectChildren(resolver, transform);
            vm.Start();
            base.Show();
            AddListener();
            InitShow().Forget();
        }

        public override void Close()
        {
            vm.Dispose();
            base.Close();
            RemoveListener();
            inject.CloseChildren();
        }

        protected override void AddListener()
        {
            btn_Back?.onClick.AddListener(BtnBack);
            vm.Action_UpdateList += UpdateList;
        }

        protected override void RemoveListener()
        {
            btn_Back?.onClick.RemoveListener(BtnBack);
            vm.Action_UpdateList -= UpdateList;
        }

        #endregion

        #region :::  Event  :::

        //更新最新清單
        protected void UpdateList(BaseStore_BtnInfo[] list)
        {
            GoBackToPool();
            SetItemUnit(list);
        }

        #endregion

        #region :::  Button  :::
        protected virtual void BtnBack()
        {
            uiManager.Back();
        }

        protected virtual void BtnEnter() { }

        protected virtual void BtnBuy()
        {
            if (nowChooseId == -1) { return; }
            ConfirmPurchase(nowChooseId);
        }
        #endregion
        #region ::: Purchase confirmation popup :::

        protected void ConfirmPurchase(int id)
        {
            // Do Something
        }

        #endregion


        #region :::  Protected Methods  :::
        /// <summary>
        /// Display When Initially Opened
        /// </summary>
        protected virtual async UniTask InitShow()
        {
            InitUISet();
            if (unit_path == string.Empty)
            {
                Debug.LogError("lose the path");
                return;
            }
            GameObject prefab = await addressableTools.AddressableGetGameObject(unit_path);
            pool = new PoolManager();
            pool.Init(prefab);

            vm.Get();

        }

        protected virtual void InitUISet() { }

        /// <summary>
        /// Set up product buttons.
        /// </summary>
        protected virtual void SetItemUnit(BaseStore_BtnInfo[] list) { }


        /// <summary>
        /// Return all units to the item pool before the next use.
        /// </summary>
        protected virtual void GoBackToPool()
        {
            pool.AllGoToPool();
        }
        #endregion
    }
}