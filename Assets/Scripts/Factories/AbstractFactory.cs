using System.Collections.Generic;
using UnityEngine;

namespace EndlessFaller.Factories
{
    public class AbstractFactory<T> : GameObjectFactory, IFactory<T> where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;

        private Transform _objectsOrigin;

        public virtual void Initialize(Transform origin)
        {
            _objectsOrigin = origin;
        }

        public virtual T Get()
        {
            return CreateGameObjectInstance(_prefab, _objectsOrigin, true);
        }

        public virtual void Reclaim(T factoryObject)
        {
            Destroy(factoryObject.gameObject);
        }
    }
}