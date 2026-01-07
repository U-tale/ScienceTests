using System;
using System.Diagnostics;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace SciencePrefixes20;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.scienceprefixes20")]
public partial class SciencePrefixes20Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        DoPatching();
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    public void DoPatching()
    {
        var harmony = new Harmony("Science20Prefixes");
        var sw = Stopwatch.StartNew();
        Logger.LogInfo($"Making 20 prefixes at {sw.ElapsedMilliseconds} ms");
        harmony.PatchAll();
        sw.Stop();
        Logger.LogInfo($"Finished making 20 prefixes at {sw.ElapsedMilliseconds} ms");
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
    [HarmonyPrefix]
    [HarmonyPatch("ActivateTestingCheats")]
    public static void PrefixThirteen() { }
    [HarmonyPrefix]
    [HarmonyPatch("MapperLeaveAll")]
    public static void PrefixSeventeen() { }
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
    [HarmonyPrefix]
    [HarmonyPatch("SilkChargeEnd")]
    public static void PrefixFourteen() { }
    [HarmonyPrefix]
    [HarmonyPatch("IsSwimming")]
    public static void PrefixEighteen() { }
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

    [HarmonyPrefix]
    [HarmonyPatch("SendDeathEvent")]
    public static void PrefixTwelve() { }

    [HarmonyPrefix]
    [HarmonyPatch("GetIsDead")]
    public static void PrefixFifteen() { }

    [HarmonyPrefix]
    [HarmonyPatch("GetAttackDirection")]
    public static void PrefixNineteen() { }
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
[HarmonyPatch(typeof(HeroSlabCapture))]
public class HeroSlabCapturePrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("ApplyCaptured")]
    public static void PrefixTwelve() { }
}
[HarmonyPatch(typeof(SilkGrubCocoon))]
public class SilkGrubCocoonPrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("WasHit")]
    public static void PrefixSixteen() { }
}
[HarmonyPatch(typeof(HeroWispLantern))]
public class HeroWispLanternPrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("EffectsCleared")]
    public static void PrefixTwenty() { }
}
#endregion
