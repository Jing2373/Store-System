using UnityEngine;
using VContainer;
using VContainer.Unity;
using System.Collections.Generic;


using Jing.Feature.UI;

namespace Jing.Tools
{
    public class InjectChildrenGameObject
    {
        private List<IBaseView> childrenViews = new List<IBaseView>();
        /// <summary>
        /// 註冊子物件
        /// </summary>
        public void InjectChildren(IObjectResolver resolver, Transform transform)
        {
            if (childrenViews.Count != 0)
            {
                foreach (IBaseView i in childrenViews)
                {
                    i.Show();
                }
                return;
            }

            foreach (Transform i in transform)
            {
                resolver.InjectGameObject(i.gameObject);
                IBaseView[] views = i.gameObject.GetComponents<IBaseView>();
                foreach (IBaseView j in views)
                {
                    j.Show();
                    childrenViews.Add(j);
                }

            }
        }

        /// <summary>
        /// 關閉子物件
        /// </summary>
        public void CloseChildren()
        {
            foreach (IBaseView i in childrenViews)
            {
                i.Close();
            }
        }

    }
}
