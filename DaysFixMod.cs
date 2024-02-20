using Assets.Scripts.Objects;
using HarmonyLib;
using BepInEx;


namespace DaysFixMod
{
    [BepInPlugin(PluginInfo., "Days & Storms Fix", "0.0.2.0")]
    class DaysFixMod : BaseUnityPlugin
    {
        private void Awake()
        {
            //READ THE README FIRST! 
            
            Harmony harmony = new Harmony("DaysFixMod");
            harmony.PatchAll();
            UnityEngine.Debug.Log("DaysFixMod Loaded");
        }


    }
}