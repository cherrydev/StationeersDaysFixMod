using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Util;
using BepInEx.Configuration;
using HarmonyLib;
using JetBrains.Annotations;

namespace DaysFixMod
{
    [HarmonyPatch(typeof(CelestialBody))]
    public static class DaysFixModPatch
    {
        static Dictionary<string, int> ScenarioOffsets = new Dictionary<string, int>()
        {
            { "Vulcan", 266 },
            { "Moon", 71 },
            { "Mars", 0 },
            { "Europa", 0 },
            { "Mimas", 0 },
            { "Space", 0 },
            { "Venus", 2 }
        };

        [HarmonyPatch("GetOrbitProgressionCount")]
        [HarmonyPrefix]
        [UsedImplicitly]
        public static bool Prefix(CelestialBody __instance, ref uint __result)
        {
            if (__instance is RotatingCelestialBody)
            {
                var rawDays = (int) Math.Abs(Math.Floor((__instance as RotatingCelestialBody).AccumulatedAngle / 360.0));
                int daysOffset;
                var worldId = WorldSetting.Current.Id;
                if (! ScenarioOffsets.TryGetValue(worldId, out daysOffset))
                {
                    UnityEngine.Debug.Log($"Loading day offset for world {worldId}");
                    ConfigDefinition configDefinition = new ConfigDefinition("DayOffsets", worldId);
                    var offsetConfig = DaysFixMod.Instance.Config.Bind<int>(configDefinition, 0 , new ConfigDescription($"Day offset for {worldId}"));
                    daysOffset = offsetConfig.Value;
                    ScenarioOffsets[worldId] = daysOffset;
                    UnityEngine.Debug.Log($"Loaded offset of {daysOffset}");
                }
                __result =  (uint) (rawDays - daysOffset);
                return false;
            }
            
            return true;
        }
    }
}
