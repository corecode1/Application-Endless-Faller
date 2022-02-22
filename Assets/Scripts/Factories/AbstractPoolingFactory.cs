using System.Collections.Generic;
using UnityEngine;

namespace EndlessFaller.Factories
{
    public class AbstractPoolingFactory<T> : AbstractFactory<T> where T : MonoBehaviour, IResettable
    {
        private List<T> _pooledItems;

        public override void Initialize(Transform origin)
        {
            base.Initialize(origin);
            _pooledItems = new List<T>(10);
        }

        public override T Get()
        {
            int pooledCount = _pooledItems.Count;

            if (pooledCount <= 0)
            {
                return base.Get();
            }

            T item = _pooledItems[pooledCount - 1];
            _pooledItems.RemoveAt(pooledCount - 1);
            item.Reset();
            item.gameObject.SetActive(true);
            return item;
        }

        public override void Reclaim(T factoryObject)
        {
            factoryObject.gameObject.SetActive(false);
            _pooledItems.Add(factoryObject);
        }
    }
}