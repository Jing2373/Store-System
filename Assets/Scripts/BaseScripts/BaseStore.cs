using System;
using VContainer;

using Jing.Feature.GameItemSystem;
using Jing.Feature.InfomationManager;
using System.Collections.Generic;
using UnityEngine;

namespace Jing.Feature.ShoppingStreet
{
    public class BaseStore
    {

        protected Dictionary<int, ItemShowData> dict = new Dictionary<int, ItemShowData>();

        public Action<BaseStore_BtnInfo[]> Action_UpdateList;


        #region ::: Inject :::
        protected IItemSystem itemSystem;
        protected IPlayerInfoManager playerInfoManager;

        [Inject]
        public void Construct(IItemSystem itemSystem, IPlayerInfoManager playerInfoManager)
        {
            this.itemSystem = itemSystem;
            this.playerInfoManager = playerInfoManager;
        }

        #endregion

        public void Start()
        {
            AddListener();
        }

        public void Dispose()
        {
            RemoveListener();
        }

        /// <summary>
        ///  Get Products
        /// </summary>
        public virtual void Get() { }


        /// <summary>
        /// Purchase Product or Upgrade Item (after purchase confirmation)
        /// </summary>
        public virtual void Buy(int id)
        {
        }

        /// <summary>
        /// For Pop-Windows Display Only
        /// </summary>
        public string GetItemNameById(int id)
        {
            if (dict.TryGetValue(id, out var value))
            {
                return value.ItemSetting.PreviewName;
            }
            return string.Empty;
        }

        #region ::: Listener :::

        protected virtual void AddListener() { }

        protected virtual void RemoveListener() { }

        #endregion



    }

    public class BaseStore_BtnInfo
    {
        public int Id;
        public Sprite Icon;
        public string Name;
        public string Content;
        public bool isLock;

    }
}