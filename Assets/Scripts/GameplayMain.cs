using EndlessFaller.Factories;
using EndlessFaller.Input;
using EndlessFaller.Scoring;
using UnityEngine;

namespace EndlessFaller
{
    public class GameplayMain : MonoBehaviour
    {
        [SerializeField] private PlatformsController _platformsController;
        [SerializeField] private Config _config;
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private Camera _mainCamera;

        private Player _player;
        private UserInputRaiser _inputSystem;
        private GameState _state;

        private void Start()
        {
            _scoringController = new ScoringController();
            _screenAffiliationChecker = new ScreenAffiliationChecker(_mainCamera);
            _inputSystem = new UserInputRaiser();
            _player = _playerFactory.Get();
            _player.Initialize(_inputSystem, _screenAffiliationChecker, _config);
            _platformsController.Initialize(_config, _screenAffiliationChecker, _scoringController);
            _state = GameState.Progress;
        }

        private ScreenAffiliationChecker _screenAffiliationChecker;
        private ScoringController _scoringController;

        private void Update()
        {
            if (_state != GameState.Progress)
            {
                return;
            }

            _platformsController.UpdateBehaviour();
            _inputSystem.Update();
            _player.UpdateBehaviour();

            if (_player.LifetimeController.IsDead)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            _state = GameState.GameOver;
        }
    }
}