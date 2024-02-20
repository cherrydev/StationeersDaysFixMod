using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Util;
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
                ScenarioOffsets.TryGetValue(WorldSetting.Current.Name, out daysOffset);
                __result =  (uint) (rawDays - daysOffset);
                return false;
            }
            
            return true;
        }
    }
}
