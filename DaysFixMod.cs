using Assets.Scripts.Objects;
using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;
using System.Collections.Generic;


namespace DaysFixMod
{
    [BepInPlugin("DaysFix", "Days & Storms Fix", "0.0.3.0")]
    class DaysFixMod : BaseUnityPlugin
    {

        public static DaysFixMod Instance;
        private void Awake()
        {
            //READ THE README FIRST! 
            Instance = this;
            Harmony harmony = new Harmony("DaysFixMod");
            harmony.PatchAll();
            UnityEngine.Debug.Log("DaysFixMod Loaded");
        }


    }
}