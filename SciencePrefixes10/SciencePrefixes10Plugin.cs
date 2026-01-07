using System;
using System.Diagnostics;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace SciencePrefixes10;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.scienceprefixes10")]
public partial class SciencePrefixes10Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        DoPatching();
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    public void DoPatching()
    {
        var harmony = new Harmony("Science10Prefixes");
        var sw = Stopwatch.StartNew();
        Logger.LogInfo($"Making 10 prefixes at {sw.ElapsedMilliseconds} ms");
        harmony.PatchAll();
        sw.Stop();
        Logger.LogInfo($"Finished making 10 prefixes at {sw.ElapsedMilliseconds} ms");
    }

}
[HarmonyPatch(typeof(PlayerData))]
public class PlayerDataPrefixes
{
    [HarmonyPrefix]
    [HarmonyPatch("CacheSavedFleas")]
    public static void PrefixOne() { }
    [HarmonyPrefix]
    [HarmonyPatch("GetAllPowerups")]
    public static void PrefixFive() { }
    [HarmonyPrefix]
    [HarmonyPatch("MaxHealth")]
    public static void PrefixNine() { }
}
[HarmonyPatch(typeof(HeroController))]
public class HeroControllerPrefixes
{
    [HarmonyPrefix]
    [HarmonyPatch("TempStoreCurrency")]
    public static void PrefixTwo() { }
    [HarmonyPrefix]
    [HarmonyPatch("SetStartWithAttack")]
    public static void PrefixSix() { }
    [HarmonyPrefix]
    [HarmonyPatch("SetStartWithBackflipJump")]
    public static void PrefixTen() { }
}
[HarmonyPatch(typeof(HealthManager))]
public class HealthManagerPrefixes
{
    [HarmonyPrefix]
    [HarmonyPatch("ClearItemDropsBattleScene")]
    public static void PrefixThree() { }

    [HarmonyPrefix]
    [HarmonyPatch("SetDead")]
    public static void PrefixSeven() { }
}

#region other prefixes
[HarmonyPatch(typeof(QuestBoardInteractable))]
public class QuestBoardInteractablePrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("OpenBoard")]
    public static void PrefixFour() { }
}
[HarmonyPatch(typeof(HeroTriggerFader))]
public class HeroTriggerFaderPrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("ShouldBeVisible")]
    public static void PrefixEight() { }
}
#endregion
