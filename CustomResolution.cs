using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using CustomResolution.Patches;
using HarmonyLib;
using Microsoft.VisualBasic;
using UnityEngine;
using System.Reflection;
namespace CustomResolution
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class CustomRes : BaseUnityPlugin
    {
        private const string modGUID = "WhaleToast.CustomResolution";
        private const string modName = "CustomResolution";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static CustomRes Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Mod loaded");
            Debug.Log("Debug mod loaded");
            harmony.PatchAll();
        }
    }
}