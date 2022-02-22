using UnityEngine;

namespace EndlessFaller
{
    public class RatesController
    {
        private readonly Config _config;
        private float _timeToSpawn;
        private float _spawnRate;

        public bool CanSpawn => _timeToSpawn <= 0f;
        public float PlatformSpeed { get; set; }

        public RatesController(Config config)
        {
            _config = config;
            _timeToSpawn = config.PlatformsSpawnDelay;
            _spawnRate = _config.PlatformsSpawnRate;
            PlatformSpeed = _config.PlatformsSpeed;
        }

        public void Update()
        {
            float dt = Time.deltaTime;
            
            _timeToSpawn -= dt;
            _spawnRate -= _config.PlatformsSpawnProgressionFactor * dt;
            PlatformSpeed += _config.PlatformsSpeedProgressionFactor * dt;
        }

        public void HandleSpawn()
        {
            _timeToSpawn += _spawnRate;
        }
    }
}