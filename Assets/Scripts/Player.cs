using EndlessFaller.Input;
using UnityEngine;

namespace EndlessFaller
{
    public class Player : MonoBehaviour, IBoundsItem
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        private Config _config;
        public ScreenObjectLifetimeController LifetimeController { get; private set; }
        Bounds IBoundsItem.Bounds => _collider.bounds;

        public void Initialize(IInputRaiser inputRaiser, ScreenAffiliationChecker screenAffiliationChecker, Config config)
        {
            _config = config;
            LifetimeController = new ScreenObjectLifetimeController(this, screenAffiliationChecker);
            inputRaiser.OnMoveCommand += HandleMoveCommand;
        }

        public void UpdateBehaviour()
        {
            LifetimeController.Update();
        }

        private void HandleMoveCommand(Vector2 direction)
        {
            Vector3 positionChange = direction * (_config.PlayerSpeed * Time.deltaTime);
            _rigidbody.MovePosition(_rigidbody.position + positionChange);
        }
    }
}