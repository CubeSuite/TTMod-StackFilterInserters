using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using StackFilterInserters.Patches;
using UnityEngine;

namespace StackFilterInserters
{
    // TODO Review this file and update to your own requirements.

    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class StackFilterInsertersPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.equinox.StackFilterInserters";
        private const string PluginName = "StackFilterInserters";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake() {
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
            Log = Logger;

            Harmony.CreateAndPatchAll(typeof(InserterDefinitionPatch));
        }
    }
}
