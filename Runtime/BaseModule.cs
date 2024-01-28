using UnityEngine;

namespace UScreens.Modules
{
    [RequireComponent(typeof(UPanel))]
    [RequireComponent(typeof(ModuleRepo))]
    public abstract class BaseModule : MonoBehaviour
    {
        protected UPanel owner;
        private ModuleRepo _repo;

        private void Awake()
        {
            owner = GetComponent<UPanel>();
            _repo = GetComponent<ModuleRepo>();

            owner.OnShow += Show;
            owner.OnHide += Hide;

            Initialize();
        }

        protected virtual void Initialize() { }

        protected virtual void OnDestroy()
        {
            owner.OnShow -= Show;
            owner.OnHide -= Hide;
        }

        private void OnEnable() => 
            _repo.Active(this);

        private void OnDisable() => 
            _repo.Inactivate(this);

        internal virtual void Show() { }
        internal virtual void Hide() { }
    }
}
