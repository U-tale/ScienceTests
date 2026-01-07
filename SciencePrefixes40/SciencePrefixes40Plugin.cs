using System;
using System.Diagnostics;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace SciencePrefixes40;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.scienceprefixes40")]
public partial class SciencePrefixes40Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        DoPatching();
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    public void DoPatching()
    {
        var harmony = new Harmony("Science40Prefixes");
        var sw = Stopwatch.StartNew();
        Logger.LogInfo($"Making 40 prefixes at {sw.ElapsedMilliseconds} ms");
        harmony.PatchAll();
        sw.Stop(); 
        Logger.LogInfo($"Finished making 40 prefixes at {sw.ElapsedMilliseconds} ms");
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
    [HarmonyPrefix]
    [HarmonyPatch("GetNextSilkGrubValue")]
    public static void PrefixTwentyOne() { }
    [HarmonyPrefix]
    [HarmonyPatch("CountGameCompletion")]
    public static void PrefixTwentyFive() { }
    [HarmonyPrefix]
    [HarmonyPatch("SetupExistingPlayerData")]
    public static void PrefixTwentyNine() { }
    [HarmonyPrefix]
    [HarmonyPatch("ResetCutsceneBools")]
    public static void PrefixThirtyThree() { }
    [HarmonyPrefix]
    [HarmonyPatch("GetNextMossberryValue")]
    public static void PrefixThirtySeven() { }
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
    [HarmonyPrefix]
    [HarmonyPatch("FaceRight")]
    public static void PrefixTwentyTwo() { }
    [HarmonyPrefix]
    [HarmonyPatch("FaceLeft")]
    public static void PrefixTwentySix() { }
    [HarmonyPrefix]
    [HarmonyPatch("NotSwimming")]
    public static void PrefixThirty() { }
    [HarmonyPrefix]
    [HarmonyPatch("CharmUpdate")]
    public static void PrefixThirtyFour() { }
    [HarmonyPrefix]
    [HarmonyPatch("UpdateGeo")]
    public static void PrefixThirtyEight() { }
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

    [HarmonyPrefix]
    [HarmonyPatch("CheckInvincible")]
    public static void PrefixTwentyThree() { }

    [HarmonyPrefix]
    [HarmonyPatch("HealToMax")]
    public static void PrefixTwentySeven() { }

    [HarmonyPrefix]
    [HarmonyPatch("AddPhysicalPusher")]
    public static void PrefixThirtyOne() { }

    [HarmonyPrefix]
    [HarmonyPatch("DoStealHit")]
    public static void PrefixThirtyFive() { }

    [HarmonyPrefix]
    [HarmonyPatch("CancelAllLagHits")]
    public static void PrefixThirtyNine() { }

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
[HarmonyPatch(typeof(LifebloodState))]
public class LifebloodStatePrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("OnDeath")]
    public static void PrefixTwentyFour() { }
}
[HarmonyPatch(typeof(ClockworkHatchling))]
public class ClockworkHatchlingPrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("LowHealthCheck")]
    public static void PrefixTwentyEight() { }
}
[HarmonyPatch(typeof(BigCentipede))]
public class BigCentipedePrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("Burrow")]
    public static void PrefixThirtyTwo() { }
}
[HarmonyPatch(typeof(DamageHero))]
public class DamageHeroPrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("OnDamaged")]
    public static void PrefixThirtySix() { }
}
[HarmonyPatch(typeof(MateriumItem))]
public class MateriumItemPrefix
{
    [HarmonyPrefix]
    [HarmonyPatch("GetCollectionDesc")]
    public static void PrefixForty() { }
}
#endregion
