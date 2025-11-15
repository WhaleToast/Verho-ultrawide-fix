using HarmonyLib;
using UnityEngine;

namespace CustomResolution.Patches
{
    [HarmonyPatch(typeof(SettingsMenager))]
    public static class SettingsMenager_ApplyPatch
    {
        [HarmonyPatch("SetResotution")]
        [HarmonyPrefix]
        public static bool Prefix(int resolutionIndex)
        {
            // Detect monitor resolution
            int w = Display.main.systemWidth;
            int h = Display.main.systemHeight;

            // Apply fullscreen flag if needed
            bool fullscreen = Screen.fullScreen;

            // Override game's resolution logic
            Screen.SetResolution(w, h, fullscreen);

            // Still store chosen index (harmless)
            PlayerPrefs.SetInt("v_resotulution", resolutionIndex);

            Debug.Log($"[CustomRes] Forced dynamic resolution {w}x{h}");
            BepInEx.Logging.Logger.CreateLogSource("CustomRes").LogInfo("Forced resolution patch executed");

            return false; // Skip original game code
        }
    }
}

