using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ScienceEvents30;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.scienceevents30")]
public partial class ScienceEvents30Plugin : BaseUnityPlugin
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
        Logger.LogInfo($"Subscribing to 30 events at {sw.Elapsed.TotalMilliseconds} ms");

        var HookOne = new Hook(typeof(PlayerData).GetMethod("CacheSavedFleas", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookOne", BindingFlags.Public | BindingFlags.Static));
        var HookTwo = new Hook(typeof(HeroController).GetMethod("TempStoreCurrency", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwo", BindingFlags.Public | BindingFlags.Static));
        var HookThree = new Hook(typeof(HealthManager).GetMethod("ClearItemDropsBattleScene", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookThree", BindingFlags.Public | BindingFlags.Static));
        var HookFour = new Hook(typeof(QuestBoardInteractable).GetMethod("OpenBoard", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookFour", BindingFlags.Public | BindingFlags.Static));
        var HookFive = new Hook(typeof(PlayerData).GetMethod("GetAllPowerups", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookFive", BindingFlags.Public | BindingFlags.Static));
        var HookSix = new Hook(typeof(HeroController).GetMethod("SetStartWithAttack", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookSix", BindingFlags.Public | BindingFlags.Static));
        var HookSeven = new Hook(typeof(HealthManager).GetMethod("SetDead", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookSeven", BindingFlags.Public | BindingFlags.Static));
        var HookEight = new Hook(typeof(HeroTriggerFader).GetMethod("ShouldBeVisible", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookEight", BindingFlags.Public | BindingFlags.Static));
        var HookNine = new Hook(typeof(PlayerData).GetMethod("MaxHealth", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookNine", BindingFlags.Public | BindingFlags.Static));
        var HookTen = new Hook(typeof(HeroController).GetMethod("SetStartWithBackflipJump", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTen", BindingFlags.Public | BindingFlags.Static));
        var HookEleven = new Hook(typeof(HealthManager).GetMethod("SendDeathEvent", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookEleven", BindingFlags.Public | BindingFlags.Static));
        var HookTwelve = new Hook(typeof(HeroSlabCapture).GetMethod("ApplyCaptured", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwelve", BindingFlags.Public | BindingFlags.Static));
        var HookThirteen = new Hook(typeof(PlayerData).GetMethod("ActivateTestingCheats", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookThirteen", BindingFlags.Public | BindingFlags.Static));
        var HookFourteen = new Hook(typeof(HeroController).GetMethod("SilkChargeEnd", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookFourteen", BindingFlags.Public | BindingFlags.Static));
        var HookFifteen = new Hook(typeof(HealthManager).GetMethod("GetIsDead", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookFifteen", BindingFlags.Public | BindingFlags.Static));
        var HookSixteen = new Hook(typeof(SilkGrubCocoon).GetMethod("WasHit", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookSixteen", BindingFlags.Public | BindingFlags.Static));
        var HookSeventeen = new Hook(typeof(PlayerData).GetMethod("MapperLeaveAll", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookSeventeen", BindingFlags.Public | BindingFlags.Static));
        var HookEighteen = new Hook(typeof(HeroController).GetMethod("IsSwimming", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookEighteen", BindingFlags.Public | BindingFlags.Static));
        var HookNineteen = new Hook(typeof(HealthManager).GetMethod("GetAttackDirection", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookNineteen", BindingFlags.Public | BindingFlags.Static));
        var HookTwenty = new Hook(typeof(HeroWispLantern).GetMethod("EffectsCleared", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwenty", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyOne = new Hook(typeof(PlayerData).GetMethod("GetNextSilkGrubValue", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentyOne", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyTwo = new Hook(typeof(HeroController).GetMethod("FaceRight", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentyTwo", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyThree = new Hook(typeof(HealthManager).GetMethod("CheckInvincible", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentyThree", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyFour = new Hook(typeof(LifebloodState).GetMethod("OnDeath", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentyFour", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyFive = new Hook(typeof(PlayerData).GetMethod("CountGameCompletion", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentyFive", BindingFlags.Public | BindingFlags.Static));
        var HookTwentySix = new Hook(typeof(HeroController).GetMethod("FaceLeft", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentySix", BindingFlags.Public | BindingFlags.Static));
        var HookTwentySeven = new Hook(typeof(HealthManager).GetMethod("HealToMax", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentySeven", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyEight = new Hook(typeof(ClockworkHatchling).GetMethod("LowHealthCheck", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentyEight", BindingFlags.Public | BindingFlags.Static));
        var HookTwentyNine = new Hook(typeof(PlayerData).GetMethod("SetupExistingPlayerData", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookTwentyNine", BindingFlags.Public | BindingFlags.Static));
        var HookThirty = new Hook(typeof(HeroController).GetMethod("NotSwimming", BindingFlagsAll), typeof(ScienceEvents30Plugin).GetMethod("HookThirty", BindingFlags.Public | BindingFlags.Static));


        sw.Stop();
        Logger.LogInfo($"Finished subscribing to 30 events at {sw.Elapsed.TotalMilliseconds} ms");
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
}