using UnityEngine;

namespace UScreens.Modules
{
    [DisallowMultipleComponent]
    [AddComponentMenu("UScreen/Panel Module/Animator Module")]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(DelayedActivateModule))]
    internal class AnimatorModule : BaseModule
    {
        private Animator _animator;
        private DelayedActivateModule _activateModule;

        [Header("Trigger Parameter")]
        [SerializeField] private string _hideParameter = "Hide";
        [SerializeField] private string _showParameter = "Show";

        [Header("Duration")]
        [Tooltip("Set true If you want the panel to hide after the hide animation is finished. (Use the duration of the hide animation.)")]
        [SerializeField] private bool _useHideDuration;

        protected override void Initialize()
        {
            _animator = GetComponent<Animator>();
            _activateModule = GetComponent<DelayedActivateModule>();
        }

        internal override void Hide()
        {
            _animator.SetTrigger(_hideParameter);

            if (_useHideDuration)
                _activateModule.Hide(_animator.GetCurrentAnimatorStateInfo(0).length);
            else
                _activateModule.Hide();
        }

        internal override void Show()
        {
            _activateModule.Show();
            _animator.SetTrigger(_showParameter);
        }
    }
}
