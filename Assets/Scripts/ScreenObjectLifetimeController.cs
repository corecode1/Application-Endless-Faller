namespace EndlessFaller
{
    public class ScreenObjectLifetimeController
    {
        private readonly IBoundsItem _target;
        private readonly ScreenAffiliationChecker _checker;

        public bool IsDead => !IsVisible && _wasVisible;
        private bool IsVisible => _checker.IsInsideScreen(_target.Bounds);
        private bool _wasVisible;

        public ScreenObjectLifetimeController(IBoundsItem target, ScreenAffiliationChecker checker)
        {
            _checker = checker;
            _target = target;
        }

        public void Update()
        {
            if (IsVisible && !_wasVisible)
            {
                _wasVisible = true;
            }
        }

        public void Reset()
        {
            _wasVisible = false;
        }
    }
}