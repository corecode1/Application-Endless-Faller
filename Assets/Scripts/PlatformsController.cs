using System.Collections.Generic;
using EndlessFaller.Factories;
using EndlessFaller.Scoring;
using UnityEngine;

namespace EndlessFaller
{
    public class PlatformsController : MonoBehaviour
    {
        [SerializeField] private Transform _spawnOrigin;
        [SerializeField] private PlatformsFactory _factory;
        [SerializeField] private Vector3 _moveVector = Vector3.up;

        private Config _config;
        private List<Platform> _activePlatforms;
        private ScoringController _scoringController;
        private RatesController _ratesController;

        private const int EstimatedPlatformsOnScreen = 10;

        public void Initialize(
            Config config,
            ScreenAffiliationChecker screenAffiliationChecker,
            ScoringController scoringController)
        {
            _config = config;
            _scoringController = scoringController;
            _factory.Initialize(_spawnOrigin, screenAffiliationChecker);
            _ratesController = new RatesController(_config);
            _activePlatforms = new List<Platform>(EstimatedPlatformsOnScreen);
            _moveVector.Normalize();
        }

        public void UpdateBehaviour()
        {
            _ratesController.Update();

            if (_ratesController.CanSpawn)
            {
                SpawnPlatform();
                _ratesController.HandleSpawn();
            }

            for (int i = _activePlatforms.Count - 1; i >= 0; i--)
            {
                Platform platform = _activePlatforms[i];

                if (platform.LifetimeController.IsDead)
                {
                    DestroyPlatform(platform);
                    _activePlatforms.Remove(platform);
                }
                
                platform.UpdateBehaviour(_moveVector * (_ratesController.PlatformSpeed * Time.deltaTime));
            }
        }

        private void SpawnPlatform()
        {
            Platform platform = _factory.Get();
            
            float gapPosition = _config.PlatformsGapPositionsRange.RandomValueInRange;
            float gapSize = _config.PlatformsGapRelativeSize;
            platform.SetGap(gapPosition, gapSize);
            platform.OnScoringAction += _scoringController.HandleScoringAction;
            _activePlatforms.Add(platform);
        }

        private void DestroyPlatform(Platform platform)
        {
            platform.OnScoringAction -= _scoringController.HandleScoringAction;
            _factory.Reclaim(platform);
        }
    }
}