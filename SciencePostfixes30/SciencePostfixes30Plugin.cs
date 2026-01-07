using System;
using System.Diagnostics;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace SciencePostfixes30;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.sciencepostfixes30")]
public partial class SciencePostfixes30Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        DoPatching();
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    public void DoPatching()
    {
        var harmony = new Harmony("Science30Postfixes");
        var sw = Stopwatch.StartNew();
        Logger.LogInfo($"Making 30 postfixes at {sw.ElapsedMilliseconds} ms");
        harmony.PatchAll();
        sw.Stop();
        Logger.LogInfo($"Finished making 30 postfixes at {sw.ElapsedMilliseconds} ms");
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
    [HarmonyPostfix]
    [HarmonyPatch("GetNextSilkGrubValue")]
    public static void PostfixTwentyOne() { }
    [HarmonyPostfix]
    [HarmonyPatch("CountGameCompletion")]
    public static void PostfixTwentyFive() { }
    [HarmonyPostfix]
    [HarmonyPatch("SetupExistingPlayerData")]
    public static void PostfixTwentyNine() { }
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
    [HarmonyPostfix]
    [HarmonyPatch("FaceRight")]
    public static void PostfixTwentyTwo() { }
    [HarmonyPostfix]
    [HarmonyPatch("FaceLeft")]
    public static void PostfixTwentySix() { }
    [HarmonyPostfix]
    [HarmonyPatch("NotSwimming")]
    public static void PostfixThirty() { }
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

    [HarmonyPostfix]
    [HarmonyPatch("CheckInvincible")]
    public static void PostfixTwentyThree() { }

    [HarmonyPostfix]
    [HarmonyPatch("HealToMax")]
    public static void PostfixTwentySeven() { }
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
[HarmonyPatch(typeof(LifebloodState))]
public class LifebloodStatePostfix
{
    [HarmonyPostfix]
    [HarmonyPatch("OnDeath")]
    public static void PostfixTwentyFour() { }
}
[HarmonyPatch(typeof(ClockworkHatchling))]
public class ClockworkHatchlingPostfix
{
    [HarmonyPostfix]
    [HarmonyPatch("LowHealthCheck")]
    public static void PostfixTwentyEight() { }
}

#endregion
