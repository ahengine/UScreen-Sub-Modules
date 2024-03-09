using UnityEngine;

namespace UScreens.Modules
{
    [AddComponentMenu("UScreen/Panel Module/Delayed Activate Module")]
    public class DelayedActivateModule : ActivateModule
    {
        [SerializeField, Min(0)] private float _showDelay;
        [SerializeField, Min(0)] private float _hideDelay;

        internal override void Hide() => 
            Hide(_hideDelay);

        public void Hide(float delay) =>
            Invoke(nameof(baseHide), delay);
        
        private void baseHide()
        {
            base.Hide();
        }

        internal override void Show() => 
            Show(_showDelay);

        public void Show(float delay) => 
            Invoke(nameof(baseShow), _showDelay);

        private void baseShow()
        {
            base.Show();
        }
    }
}
