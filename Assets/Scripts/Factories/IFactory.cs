using UnityEngine;

namespace EndlessFaller.Factories
{
    public interface IFactory<T> where T : MonoBehaviour
    {
        T Get();
        void Reclaim(T factoryObject);
    }
}