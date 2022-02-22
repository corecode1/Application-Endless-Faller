using FloatRangeSlider;
using UnityEngine;

namespace EndlessFaller
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Config")]
    public class Config : ScriptableObject
    {
        private void OnValidate()
        {
            PlatformsGapRelativeSize = Mathf.Clamp01(PlatformsGapRelativeSize);
        }

        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField] public float PlatformsSpawnDelay { get; private set; }
        [field: SerializeField] public float PlatformsSpawnRate { get; private set; }
        [field: SerializeField] public float PlatformsSpawnProgressionFactor { get; private set; }
        [field: SerializeField] public float PlatformsSpeedProgressionFactor { get; private set; }
        [field: SerializeField] public float PlatformsSpeed { get; private set; }
        [field: SerializeField] public float PlatformsGapRelativeSize { get; private set; }

        [SerializeField] [FloatRangeSlider(0.1f, 0.9f)]
        private FloatRange _platformsGapPositionsRange = new FloatRange(0.2f, 0.8f);

        public FloatRange PlatformsGapPositionsRange => _platformsGapPositionsRange;
    }
}