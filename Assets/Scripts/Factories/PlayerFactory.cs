using UnityEngine;

namespace EndlessFaller.Factories
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerFactory")]
    public class PlayerFactory : AbstractFactory<Player>
    {
    }
}