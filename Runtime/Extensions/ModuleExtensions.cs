using System.Collections.Generic;

namespace UScreens.Modules
{
    public static class ModuleExtensions
    {
        private static readonly Dictionary<UPanel, ModuleRepo> _catchecRepo = new();

        public static T GetModule<T>(this UPanel panel) where T : BaseModule
        {
            if (!_catchecRepo.ContainsKey(panel))
            {
                var repo = panel.GetComponent<ModuleRepo>();
                _catchecRepo.Add(panel, repo);
            }
            return _catchecRepo[panel].GetModule<T>();
        }
    }
}
