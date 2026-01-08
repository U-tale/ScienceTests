using System;
using System.Diagnostics;
using System.Reflection;
using BepInEx;
using HarmonyLib;


namespace SciencePostfixes10;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.sciencepostfixes10")]
public partial class SciencePostfixes10Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        DoPatching();
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    public void DoPatching()
    {
        var harmony = new Harmony("Science10Postfixes");
        var sw = Stopwatch.StartNew();
        Logger.LogInfo($"Making 10 postfixes at {sw.Elapsed.TotalMilliseconds} ms");
        harmony.PatchAll();
        sw.Stop();
        Logger.LogInfo($"Finished making 10 postfixes at {sw.Elapsed.TotalMilliseconds} ms");
    }

}
[HarmonyPatch(typeof(PlayerData))]
public class PlayerDataPostfixes
{
    [HarmonyPostfix]
    [HarmonyPatch("CacheSavedFleas")]
    public static void PostfixOne() { }
    [HarmonyPostfix]
    [HarmonyPatch("GetAllPowerups")]
    public static void PostfixFive() { }
    [HarmonyPostfix]
    [HarmonyPatch("MaxHealth")]
    public static void PostfixNine() { }
}
[HarmonyPatch(typeof(HeroController))]
public class HeroControllerPostfixes
{
    [HarmonyPostfix]
    [HarmonyPatch("TempStoreCurrency")]
    public static void PostfixTwo() { }
    [HarmonyPostfix]
    [HarmonyPatch("SetStartWithAttack")]
    public static void PostfixSix() { }
    [HarmonyPostfix]
    [HarmonyPatch("SetStartWithBackflipJump")]
    public static void PostfixTen() { }
}
[HarmonyPatch(typeof(HealthManager))]
public class HealthManagerPostfixes
{
    [HarmonyPostfix]
    [HarmonyPatch("ClearItemDropsBattleScene")]
    public static void PostfixThree() { }

    [HarmonyPostfix]
    [HarmonyPatch("SetDead")]
    public static void PostfixSeven() { }
}

#region other postfixes
[HarmonyPatch(typeof(QuestBoardInteractable))]
public class QuestBoardInteractablePostfix
{
    [HarmonyPostfix]
    [HarmonyPatch("OpenBoard")]
    public static void PostfixFour() { }
}
[HarmonyPatch(typeof(HeroTriggerFader))]
public class HeroTriggerFaderPostfix
{
    [HarmonyPostfix]
    [HarmonyPatch("ShouldBeVisible")]
    public static void PostfixEight() { }
}
#endregion
