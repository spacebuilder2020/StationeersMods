using System;
using System.IO;
using HarmonyLib;

namespace StationeersMods.Plugin;

[HarmonyPatch]
public class StationSaveUtilsPatch
{
    public static string SavePathOverride = null;
    
    [HarmonyPatch(typeof(StationSaveUtils), nameof(StationSaveUtils.DefaultPath), MethodType.Getter), HarmonyPrefix]
    static bool DefaultPath(ref string __result)
    {
        if (SavePathOverride == null)
        {
            return true;
        }

        __result = SavePathOverride;
        return false;
    }
}