using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessFaller
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private string gameScene;

        public void Play()
        {
            Debug.Log("Loading game!");
            SceneManager.LoadScene(gameScene);
        }
    }
}