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

            Initialize();
        }

        protected virtual void Initialize() { }

        protected virtual void OnDestroy() { }

        private void OnEnable()
        {
            owner.OnShow += Show;
            owner.OnHide += Hide;

            _repo.Active(this);
        }

        private void OnDisable()
        {
            owner.OnShow -= Show;
            owner.OnHide -= Hide;

            _repo.Inactivate(this);
        }

        internal virtual void Show() { }
        internal virtual void Hide() { }
    }
}
