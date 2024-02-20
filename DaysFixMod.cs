using Assets.Scripts.Objects;
using HarmonyLib;
using BepInEx;


namespace DaysFixMod
{
    [BepInPlugin("FriendlyFrames", "Friendly Frames", "0.0.1.0")]
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