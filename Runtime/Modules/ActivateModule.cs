using System;
using UnityEngine;

namespace UScreens.Modules
{
    [DisallowMultipleComponent]
    [AddComponentMenu("UScreen/Panel Module/Activate Module")]
    public class ActivateModule : BaseModule
    {
        internal event Action OnShow;
        internal event Action OnHide;

        internal override void Hide()
        {
            OnHide?.Invoke();
            gameObject.SetActive(false);
        }

        internal override void Show()
        {
            gameObject.SetActive(true);
            OnShow?.Invoke();
        }
    }
}
