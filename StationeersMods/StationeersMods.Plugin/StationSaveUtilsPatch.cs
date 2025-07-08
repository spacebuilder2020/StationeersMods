using System;
using System.IO;
using HarmonyLib;

namespace StationeersMods.Plugin;

[HarmonyPatch]
public class StationSaveUtilsPatch
{
    //TODO: Replace with config
    private const string SavePathOverride = "Stationeers-modded";
    
    [HarmonyPatch(typeof(StationSaveUtils), nameof(StationSaveUtils.DefaultPath), MethodType.Getter), HarmonyPrefix]
    static bool DefaultPath(ref string __result)
    {
        if (SavePathOverride == null)
        {
            return true;
        }

        __result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games",
            SavePathOverride);
        return false;
    }
}