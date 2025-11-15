using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace CustomResolution.Patches
{
    [HarmonyPatch(typeof(CanvasScaler))]
    public static class CanvasScalerPatch
    {
        [HarmonyPatch("OnEnable")]
        [HarmonyPostfix]
        public static void FixUltrawide(CanvasScaler __instance)
        {
            Canvas canvas = __instance.GetComponent<Canvas>();
            if (canvas == null || !canvas.isRootCanvas)
                return;

            // Always use the user's actual resolution
            float w = Screen.width;
            float h = Screen.height;

            __instance.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            __instance.referenceResolution = new Vector2(w, h);

            // For ultrawide we match width to avoid horizontal stretching
            __instance.matchWidthOrHeight = 0f;

            Debug.Log($"[CustomRes] Dynamic UI scaling applied: {w}x{h} on canvas {canvas.gameObject.name}");
        }
    }
}