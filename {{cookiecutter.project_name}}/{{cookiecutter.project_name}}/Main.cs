using HarmonyLib;
using System.Reflection;
using UnityModManagerNet;

namespace {{ cookiecutter.project_name }}
{
#if DEBUG
    [EnableReloading]
#endif
    static class Main
    {
        public static bool Enabled;
        private static Harmony Harmony;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            Settings.Instance = UnityModManager.ModSettings.Load<Settings>(modEntry);
            Settings.ModEntry = modEntry;

            modEntry.OnToggle = OnToggle;
#if DEBUG
            modEntry.OnUnload = Unload;
#endif

            return true;
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (Enabled == value) return true;
            Enabled = value;

            if (Enabled)
            {
                Harmony = new Harmony(modEntry.Info.Id);
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            else
            {
                Harmony.UnpatchAll(Harmony.Id);
            }

            return true;
        }

#if DEBUG
        static bool Unload(UnityModManager.ModEntry modEntry)
        {
            Harmony?.UnpatchAll();
            return true;
        }
#endif
    }
}
