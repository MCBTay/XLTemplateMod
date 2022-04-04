using System;
using UnityModManagerNet;

namespace XLTemplateMod
{
    [Serializable]
    public class Settings : UnityModManager.ModSettings
    {
        public static Settings Instance { get; set; }
        public static UnityModManager.ModEntry ModEntry;

        public Settings() : base()
        {

        }

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        public void Save()
        {
            Save(ModEntry);
        }
    }
}
