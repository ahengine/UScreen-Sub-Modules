using System.Collections.Generic;
using UnityEngine;

namespace UScreens.Modules
{
    internal class ModuleRepo : MonoBehaviour
    {
        private readonly List<BaseModule> _Modules = new();

        public void Active(BaseModule module) =>
            _Modules.Add(module);

        public void Inactivate(BaseModule module) =>
            _Modules.Remove(module);

        public T GetModule<T>() where T : BaseModule
        {
            for (int i = 0; i < _Modules.Count; i++)
                if (_Modules[i] is T t)
                    return t;
            return null;
        }
    }
}
