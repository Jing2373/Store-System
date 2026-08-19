using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Jing.Tools
{
    //物件池
    public class PoolManager
    {

        private List<GameObject> usingList = new List<GameObject>();  //正在使用中
        private ObjectPool<GameObject> poolsList;  //回歸池

        private GameObject unit;

        /// <summary> 初始化 </summary>
        public void Init(GameObject unit)
        {
            this.unit = unit;
            poolsList = new ObjectPool<GameObject>(
                createFunc: () => Object.Instantiate(unit),
                actionOnGet: obj =>
                {
                    obj.SetActive(true);
                    usingList.Add(obj);
                },
                actionOnRelease: obj =>
                {
                    obj.SetActive(false);
                    usingList.Remove(obj);
                },
                actionOnDestroy: obj => Object.Destroy(obj),
                collectionCheck: false,
                defaultCapacity: 5,
                maxSize: 20
            );
        }

        public GameObject Get()
        {
            return poolsList.Get();
        }

        public List<GameObject> GetUsingList()
        {
            return usingList;
        }

        ///<summary> 全部回歸池 </summary>
        public void GoToPool(GameObject obj)
        {
            poolsList.Release(obj);
        }

        ///<summary> 全部回歸池 </summary>
        public void AllGoToPool()
        {
            foreach (var obj in new List<GameObject>(usingList))
            {
                poolsList.Release(obj);
            }
            usingList.Clear();
        }
    }

}
