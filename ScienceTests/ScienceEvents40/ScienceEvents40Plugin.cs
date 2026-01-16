using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ScienceEvents40;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.scienceevents40")]
public partial class ScienceEvents40Plugin : BaseUnityPlugin
{
    #region delegates
    public delegate void CacheSavedFleas_Original(PlayerData self);
    public delegate void TempStoreCurrency_Original(HeroController self);
    public delegate void ClearItemDropsBattleScene_Original(HealthManager self);
    public delegate void OpenBoard_Original(QuestBoardInteractable self);
    public delegate void GetAllPowerups_Original(PlayerData self);
    public delegate void SetStartWithAttack_Original(HeroController self);
    public delegate void SetDead_Original(HealthManager self);
    public delegate bool ShouldBeVisible_Original(HeroTriggerFader self);
    public delegate void MaxHealth_Original(PlayerData self);
    public delegate void SetStartWithBackflipJump_Original(HeroController self);
    public delegate void SendDeathEvent_Original(HealthManager self);
    public delegate void ApplyCaptured_Original();
    public delegate void ActivateTestingCheats_Original(PlayerData self);
    public delegate void SilkChargeEnd_Original(HeroController self);
    public delegate bool GetIsDead_Original(HealthManager self);
    public delegate void WasHit_Original(SilkGrubCocoon self);
    public delegate void MapperLeaveAll_Original(PlayerData self);
    public delegate void IsSwimming_Original(HeroController self);
    public delegate int GetAttackDirection_Original(HealthManager self);
    public delegate void EffectsCleard_Original(HeroWispLantern self);
    public delegate int GetNextSilkGrubValue_Original(PlayerData self);
    public delegate void FaceRight_Original(HeroController self);
    public delegate bool CheckInvincible_Original(HealthManager self);
    public delegate void OnDeath_Original(LifebloodState self);
    public delegate void CountGameCompletion_Original(PlayerData self);
    public delegate void FaceLeft_Original(HeroController self);
    public delegate void HealToMax_Original(HealthManager self);
    public delegate void LowHealthCheck_Original(ClockworkHatchling self);
    public delegate void SetupExistingPlayerData_Original(PlayerData self);
    public delegate void NotSwimming_Original(HeroController self);
    public delegate void AddPhysicalPusher(HealthManager self);
    public delegate void Burrow_Original(BigCentipede self);
    public delegate void ResetCutsceneBools_Original(PlayerData self);
    public delegate void CharmUpdate_Original(HeroController self);
    public delegate void DoStealHit_Original(HealthManager self);
    public delegate void OnDamaged_Original(DamageHero self);
    public delegate int GetNextMossberryValue_Original(PlayerData self);
    public delegate void UpdateGeo_Original(HeroController self);
    public delegate void CancelAllLagHits_Original(HealthManager self);
    public delegate string GetCollectionDesc_Original(MateriumItem self);

    #endregion



    private void Awake()
    {

        var BindingFlagsAll = new BindingFlags();
        BindingFlagsAll = BindingFlags.Public;
        BindingFlagsAll |= BindingFlags.NonPublic;
        BindingFlagsAll |= BindingFlags.Static;
        BindingFlagsAll |= BindingFlags.Instance;

        
        var sw = Stopwatch.StartNew();
        
        // Initialization logic here
        Logger.LogInfo($"Subscribing to 40 events at {sw.Elapsed.TotalMilliseconds} ms" );

        var HookOne = new Hook(typeof(PlayerData).GetMethod("CacheSavedFleas", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookOne", BindingFlags.Public | BindingFlags.Static));
        var HookTwo = new Hook(typeof(HeroController).GetMethod("TempStoreCurrency", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwo", BindingFlags.Public | BindingFlags.Static));
        var HookThree = new Hook(typeof(HealthManager).GetMethod("ClearItemDropsBattleScene", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThree", BindingFlags.Public | BindingFlags.Static));
        var HookFour = new Hook(typeof(QuestBoardInteractable).GetMethod("OpenBoard", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookFour", BindingFlags.Public | BindingFlags.Static));
        var HookFive = new Hook(typeof(PlayerData).GetMethod("GetAllPowerups", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookFive", BindingFlags.Public | BindingFlags.Static));
        var HookSix = new Hook(typeof(HeroController).GetMethod("SetStartWithAttack", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookSix", BindingFlags.Public | BindingFlags.Static ));
        var HookSeven = new Hook(typeof(HealthManager).GetMethod("SetDead", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookSeven", BindingFlags.Public | BindingFlags.Static));
        var HookEight = new Hook(typeof(HeroTriggerFader).GetMethod("ShouldBeVisible", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookEight", BindingFlags.Public | BindingFlags.Static));
        var HookNine = new Hook(typeof(PlayerData).GetMethod("MaxHealth", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookNine", BindingFlags.Public | BindingFlags.Static));
        var HookTen = new Hook(typeof(HeroController).GetMethod("SetStartWithBackflipJump", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTen", BindingFlags.Public | BindingFlags.Static));
        var HookEleven = new Hook(typeof(HealthManager).GetMethod("SendDeathEvent", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookEleven", BindingFlags.Public | BindingFlags.Static));
        var HookTwelve = new Hook(typeof(HeroSlabCapture).GetMethod("ApplyCaptured", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwelve", BindingFlags.Public | BindingFlags.Static));
        var HookThirteen = new Hook(typeof(PlayerData).GetMethod("ActivateTestingCheats", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirteen", BindingFlags.Public | BindingFlags.Static));
        var HookFourteen = new Hook(typeof(HeroController).GetMethod("SilkChargeEnd", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookFourteen", BindingFlags.Public | BindingFlags.Static));
        var HookFifteen = new Hook(typeof(HealthManager).GetMethod("GetIsDead", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookFifteen", BindingFlags.Public | BindingFlags.Static));
        var HookSixteen = new Hook(typeof(SilkGrubCocoon).GetMethod("WasHit", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookSixteen", BindingFlags.Public | BindingFlags.Static));
        var HookSeventeen = new Hook(typeof(PlayerData).GetMethod("MapperLeaveAll", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookSeventeen", BindingFlags.Public | BindingFlags.Static));
        var HookEighteen = new Hook(typeof(HeroController).GetMethod("IsSwimming", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookEighteen", BindingFlags.Public | BindingFlags.Static));
        var HookNineteen = new Hook(typeof(HealthManager).GetMethod("GetAttackDirection", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookNineteen", BindingFlags.Public | BindingFlags.Static));
        var HookTwenty = new Hook(typeof(HeroWispLantern).GetMethod("EffectsCleared", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwenty", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyOne = new Hook(typeof(PlayerData).GetMethod("GetNextSilkGrubValue", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentyOne", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyTwo = new Hook(typeof(HeroController).GetMethod("FaceRight", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentyTwo", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyThree = new Hook(typeof(HealthManager).GetMethod("CheckInvincible", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentyThree", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyFour = new Hook(typeof(LifebloodState).GetMethod("OnDeath", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentyFour", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyFive = new Hook(typeof(PlayerData).GetMethod("CountGameCompletion", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentyFive", BindingFlags.Public | BindingFlags.Static));
        var HookTwentySix = new Hook(typeof(HeroController).GetMethod("FaceLeft", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentySix", BindingFlags.Public | BindingFlags.Static));
        var HookTwentySeven = new Hook(typeof(HealthManager).GetMethod("HealToMax", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentySeven", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyEight = new Hook(typeof(ClockworkHatchling).GetMethod("LowHealthCheck", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentyEight", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyNine = new Hook(typeof(PlayerData).GetMethod("SetupExistingPlayerData", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookTwentyNine", BindingFlags.Public | BindingFlags.Static));
        var HookThirty = new Hook(typeof(HeroController).GetMethod("NotSwimming", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirty", BindingFlags.Public | BindingFlags.Static));
        var HookThirtyOne = new Hook(typeof(HealthManager).GetMethod("AddPhysicalPusher", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtyOne", BindingFlags.Public | BindingFlags.Static));
        var HookThirtyTwo = new Hook(typeof(BigCentipede).GetMethod("Burrow", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtyTwo", BindingFlags.Public | BindingFlags.Static));
        var HookThirtyThree = new Hook(typeof(PlayerData).GetMethod("ResetCutsceneBools", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtyThree", BindingFlags.Public | BindingFlags.Static));
        var HookThirtyFour = new Hook(typeof(HeroController).GetMethod("CharmUpdate", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtyFour", BindingFlags.Public | BindingFlags.Static));
        var HookThirtyFive = new Hook(typeof(HealthManager).GetMethod("DoStealHit", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtyFive", BindingFlags.Public | BindingFlags.Static));
        var HookThirtySix = new Hook(typeof(DamageHero).GetMethod("OnDamaged", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtySix", BindingFlags.Public | BindingFlags.Static));
        var HookThirtySeven = new Hook(typeof(PlayerData).GetMethod("GetNextMossberryValue", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtySeven", BindingFlags.Public | BindingFlags.Static));
        var HookThirtyEight = new Hook(typeof(HeroController).GetMethod("UpdateGeo", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtyEight", BindingFlags.Public | BindingFlags.Static));
        var HookThirtyNine = new Hook(typeof(HealthManager).GetMethod("CancelAllLagHits", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookThirtyNine", BindingFlags.Public | BindingFlags.Static));
        var HookForty = new Hook(typeof(MateriumItem).GetMethod("GetCollectionDesc", BindingFlagsAll), typeof(ScienceEvents40Plugin).GetMethod("HookForty", BindingFlags.Public | BindingFlags.Static));

        sw.Stop();
        Logger.LogInfo($"Finished subscribing to 40 events at {sw.Elapsed.TotalMilliseconds} ms" );
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }
    public static void HookOne(Action<PlayerData> orig, PlayerData self) { orig(self); }
    public static void HookTwo(TempStoreCurrency_Original orig, HeroController self) { orig(self); }
    public static void HookThree(Action<HealthManager> orig, HealthManager self) { orig(self); }
    public static void HookFour(Action<QuestBoardInteractable> orig, QuestBoardInteractable self) { orig(self); }
    public static void HookFive(Action<PlayerData> orig, PlayerData self) { orig(self); }
    public static void HookSix(SetStartWithAttack_Original orig, HeroController self) { orig(self); }
    public static void HookSeven(Action<HealthManager> orig, HealthManager self) { orig(self); }
    public static bool HookEight(ShouldBeVisible_Original orig, HeroTriggerFader self) { return orig(self); }
    public static void HookNine(Action<PlayerData> orig, PlayerData self) { orig(self); }
    public static void HookTen(SetStartWithBackflipJump_Original orig, HeroController self) { orig(self); }
    public static void HookEleven(Action<HealthManager> orig, HealthManager self) { orig(self); }
    public static void HookTwelve(ApplyCaptured_Original orig) { orig(); }
    public static void HookThirteen(Action<PlayerData> orig, PlayerData self) { orig(self); }
    public static void HookFourteen(SilkChargeEnd_Original orig, HeroController self) { orig(self); }
    public static bool HookFifteen(GetIsDead_Original orig, HealthManager self) { return orig(self); }
    public static void HookSixteen(Action<SilkGrubCocoon> orig, SilkGrubCocoon self) { orig(self); }
    public static void HookSeventeen(Action<PlayerData> orig, PlayerData self) { orig(self); }
    public static void HookEighteen(IsSwimming_Original orig, HeroController self) { orig(self); }
    public static int HookNineteen(GetAttackDirection_Original orig, HealthManager self) { return orig(self); }
    public static void HookTwenty(Action<HeroWispLantern> orig, HeroWispLantern self) { orig(self); }
    public static int HookTwentyOne(GetNextSilkGrubValue_Original orig, PlayerData self) { return orig(self); }
    public static void HookTwentyTwo(FaceRight_Original orig, HeroController self) { orig(self); }
    public static bool HookTwentyThree(CheckInvincible_Original orig, HealthManager self) { return orig(self); }
    public static void HookTwentyFour(Action<LifebloodState> orig, LifebloodState self) { orig(self); }
    public static void HookTwentyFive(Action<PlayerData> orig, PlayerData self) { orig(self); }
    public static void HookTwentySix(FaceLeft_Original orig, HeroController self) { orig(self); }
    public static void HookTwentySeven(Action<HealthManager> orig, HealthManager self) { orig(self); }
    public static void HookTwentyEight(Action<ClockworkHatchling> orig, ClockworkHatchling self) { orig(self); }
    public static void HookTwentyNine(Action<PlayerData> orig, PlayerData self) { orig(self); }
    public static void HookThirty(NotSwimming_Original orig, HeroController self) { orig(self); }
    public static void HookThirtyOne(Action<HealthManager> orig, HealthManager self) { orig(self); }
    public static void HookThirtyTwo(Action<BigCentipede> orig, BigCentipede self) { orig(self); }
    public static void HookThirtyThree(Action<PlayerData> orig, PlayerData self) { orig(self); }
    public static void HookThirtyFour(CharmUpdate_Original orig, HeroController self) { orig(self); }
    public static void HookThirtyFive(Action<HealthManager> orig, HealthManager self) { orig(self); }
    public static void HookThirtySix(Action<DamageHero> orig, DamageHero self) { orig(self); }
    public static int HookThirtySeven(GetNextMossberryValue_Original orig, PlayerData self) { return orig(self); }
    public static void HookThirtyEight(UpdateGeo_Original orig, HeroController self) { orig(self); }
    public static void HookThirtyNine(Action<HealthManager> orig, HealthManager self) { orig(self); }
    public static string HookForty(GetCollectionDesc_Original orig, MateriumItem self) { return orig(self); }
}