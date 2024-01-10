using UnityEngine;
using UnityEngine.Events;

namespace UScreens.Modules
{
    [DisallowMultipleComponent]
    [AddComponentMenu("UScreen/Panel Module/Inspectator Event Module")]
    internal class InspectatorEventModule : BaseModule
    {
        [SerializeField] private UnityEvent _OnShow;
        [SerializeField] private UnityEvent _OnHide;

        private ActivateModule _activateModule;

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (!gameObject.TryGetComponent(out _activateModule))
                Debug.LogWarning("Pleas add an \"ActivateModule\"", gameObject);
#endif
        }

        protected override void Initialize()
        {
            _activateModule = GetComponent<ActivateModule>();

            _activateModule.OnShow += InvokeShow;
            _activateModule.OnHide += InvokeHide;
        }

        protected override void OnDestroy()
        {
            _activateModule.OnShow -= InvokeShow;
            _activateModule.OnHide -= InvokeHide;
        }

        private void InvokeShow() =>
            _OnShow?.Invoke();

        private void InvokeHide() =>
            _OnHide?.Invoke();

        internal override void Hide() =>
            _activateModule.Hide();

        internal override void Show() =>
            _activateModule.Show();
    }
}
