using System;
using System.Diagnostics;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace SciencePostfixes20;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.sciencepostfixes20")]
public partial class SciencePostfixes20Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        DoPatching();
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    public void DoPatching()
    {
        var harmony = new Harmony("Science20Postfixes");
        var sw = Stopwatch.StartNew();
        Logger.LogInfo($"Making 20 postfixes at {sw.Elapsed.TotalMilliseconds} ms");
        harmony.PatchAll();
        sw.Stop();
        Logger.LogInfo($"Finished making 20 postfixes at {sw.Elapsed.TotalMilliseconds} ms");
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
    [HarmonyPostfix]
    [HarmonyPatch("ActivateTestingCheats")]
    public static void PostfixThirteen() { }
    [HarmonyPostfix]
    [HarmonyPatch("MapperLeaveAll")]
    public static void PostfixSeventeen() { }
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
    [HarmonyPostfix]
    [HarmonyPatch("SilkChargeEnd")]
    public static void PostfixFourteen() { }
    [HarmonyPostfix]
    [HarmonyPatch("IsSwimming")]
    public static void PostfixEighteen() { }
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

    [HarmonyPostfix]
    [HarmonyPatch("SendDeathEvent")]
    public static void PostfixTwelve() { }

    [HarmonyPostfix]
    [HarmonyPatch("GetIsDead")]
    public static void PostfixFifteen() { }

    [HarmonyPostfix]
    [HarmonyPatch("GetAttackDirection")]
    public static void PostfixNineteen() { }
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
[HarmonyPatch(typeof(HeroSlabCapture))]
public class HeroSlabCapturePostfix
{
    [HarmonyPostfix]
    [HarmonyPatch("ApplyCaptured")]
    public static void PostfixTwelve() { }
}
[HarmonyPatch(typeof(SilkGrubCocoon))]
public class SilkGrubCocoonPostfix
{
    [HarmonyPostfix]
    [HarmonyPatch("WasHit")]
    public static void PostfixSixteen() { }
}
[HarmonyPatch(typeof(HeroWispLantern))]
public class HeroWispLanternPostfix
{
    [HarmonyPostfix]
    [HarmonyPatch("EffectsCleared")]
    public static void PostfixTwenty() { }
}
#endregion
