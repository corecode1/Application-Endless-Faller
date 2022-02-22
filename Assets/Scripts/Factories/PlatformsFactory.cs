using UnityEngine;

namespace EndlessFaller.Factories
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlatformsFactory")]
    public class PlatformsFactory : AbstractPoolingFactory<Platform>
    {
        private ScreenAffiliationChecker _screenAffiliationChecker;

        public void Initialize(Transform origin, ScreenAffiliationChecker screenAffiliationChecker)
        {
            base.Initialize(origin);
            _screenAffiliationChecker = screenAffiliationChecker;
        }

        public override Platform Get()
        {
            Platform platform = base.Get();
            platform.Initialize(_screenAffiliationChecker);
            return platform;
        }
    }
}