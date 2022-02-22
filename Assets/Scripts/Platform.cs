using System;
using EndlessFaller.Factories;
using UnityEngine;

namespace EndlessFaller
{
    public class Platform : MonoBehaviour, IResettable, IBoundsItem
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MeshRenderer _part1;
        [SerializeField] private MeshRenderer _part2;
        [SerializeField] private Collider _trigger;

        private Vector3 _currentPosition;
        private Vector3 _initialPosition;
        private bool _isScoreCounted;

        public ScreenObjectLifetimeController LifetimeController { get; private set; }
        Bounds IBoundsItem.Bounds => _trigger.bounds;

        public event Action OnScoringAction;

        public void Initialize(ScreenAffiliationChecker screenAffiliationChecker)
        {
            _currentPosition = _initialPosition = transform.position;
            LifetimeController = new ScreenObjectLifetimeController(this, screenAffiliationChecker);
        }

        public void SetGap(float relativePosition, float size)
        {
            float halfSize = 0.5f;
            float halfGap = size / 2;

            relativePosition = Mathf.Clamp(relativePosition, halfGap, 1 - halfGap);
            // We assume parts are standard 1x1 unity cubes,
            // So no need to calculate bounding boxes
            float part1Size = relativePosition - halfGap;
            SetSizeToPart(-halfSize + part1Size / 2, part1Size, _part1.transform);
            float part2Size = 1 - relativePosition - halfGap;
            SetSizeToPart(halfSize - (part2Size / 2), part2Size, _part2.transform);
        }

        public void UpdateBehaviour(Vector3 moveVector)
        {
            _currentPosition += moveVector;
            _rigidbody.MovePosition(_currentPosition);
            LifetimeController.Update();
        }

        public void Reset()
        {
            transform.position = _initialPosition;
            LifetimeController.Reset();
            _isScoreCounted = false;
        }

        private void SetSizeToPart(float positionX, float sizeX, Transform part)
        {
            if (sizeX <= 0)
            {
                part.gameObject.SetActive(false);
                return;
            }

            Vector3 scale = part.localScale;
            Vector3 position = part.localPosition;
            scale.x = sizeX;
            position.x = positionX;
            part.localScale = scale;
            part.localPosition = position;
            part.gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isScoreCounted)
            {
                return;
            }

            _isScoreCounted = true;
            OnScoringAction?.Invoke();
        }
    }
}