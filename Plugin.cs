using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace HitMarks
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    public class Plugin : BaseUnityPlugin
    {
        private const string MyGuid = "Ccode.HitMarks";
        private const string PluginName = "HitMarks";
        private const string VersionString = "1.0";

        private static readonly Harmony Harmony = new Harmony(MyGuid);

        public static ManualLogSource Log;

        public static GameObject newUI;
        public void Awake()
        {
            string location = ((BaseUnityPlugin)this).Info.Location;
            string text = "HitMarks.dll";
            string text2 = location.TrimEnd(text.ToCharArray());
            string text3 = text2 + "hitmarker";
            AssetBundle val = AssetBundle.LoadFromFile(text3);
            newUI = val.LoadAsset<GameObject>("Hitmarker Container");
            Harmony.PatchAll();
            Logger.LogInfo(PluginName + " " + VersionString + " " + "loaded.");
            Log = Logger;
        }
    }
}
