using System.Collections.Generic;
using UnityEngine;

namespace UScreens.Modules
{
    [DisallowMultipleComponent]
    [AddComponentMenu("UScreen/Panel Module/Sub-Panel Module")]
    public class SubPanelModule : BaseModule
    {
        [SerializeField] private Transform _container;
        private Transform _cavasTransform;

        private readonly List<UPanel> _subPanels = new();

        protected override void Initialize()
        {
            if (_container == null)
            {
                _container = new GameObject("Container").transform;
                _container.SetParent(transform);
            }

            _cavasTransform = GetComponentInParent<Canvas>().transform;
        }

        public void AddPanel<T>(T panel) where T : UPanel
        {
            panel.transform.SetParent(_container, true);
            _subPanels.Add(panel);
        }

        public void RemovePanel(UPanel panel)
        {
            if (_subPanels.Contains(panel))
            {
                panel.transform.SetParent(_cavasTransform);
                _subPanels.Remove(panel);
            }
        }
    }
}
