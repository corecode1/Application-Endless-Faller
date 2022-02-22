using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessFaller.Factories
{
    public abstract class GameObjectFactory : ScriptableObject
    {
        private Scene _scene;

        protected T CreateGameObjectInstance<T>(T prefab) where T : MonoBehaviour
        {
            T instance = Instantiate(prefab);
            return instance;
        }

        protected T CreateGameObjectInstance<T>(
            T prefab,
            Transform origin,
            bool worldPositionStays)
            where T : MonoBehaviour
        {
            T instance = Instantiate(prefab, origin, worldPositionStays);
            return instance;
        }
        
        protected T CreateGameObjectInstance<T>(
            T prefab,
            Transform origin,
            Vector3 position,
            Quaternion orientation)
            where T : MonoBehaviour
        {
            T instance = Instantiate(prefab, position, orientation, origin);
            return instance;
        }

        protected T CreateGameObjectInstanceInFactoryScene<T>(T prefab) where T : MonoBehaviour
        {
            if (!_scene.isLoaded)
            {
                if (Application.isEditor)
                {
                    _scene = SceneManager.GetSceneByName(name);

                    if (!_scene.isLoaded)
                    {
                        _scene = SceneManager.CreateScene(name);
                    }
                }
                else
                {
                    _scene = SceneManager.CreateScene(name);
                }
            }

            T instance = Instantiate(prefab);
            SceneManager.MoveGameObjectToScene(instance.gameObject, _scene);
            return instance;
        }
    }
}