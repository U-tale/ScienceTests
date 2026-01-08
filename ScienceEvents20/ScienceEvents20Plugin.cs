using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ScienceEvents20;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.scienceevents20")]
public partial class ScienceEvents20Plugin : BaseUnityPlugin
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

    #endregion



    private void Awake()
    {

        var BindingFlagsAll = new BindingFlags();
        BindingFlagsAll = BindingFlags.Public;
        BindingFlagsAll |= BindingFlags.NonPublic;
        BindingFlagsAll |= BindingFlags.Static;
        BindingFlagsAll |= BindingFlags.Instance;

        Logger.LogInfo(typeof(HeroController).ToString());
        Logger.LogInfo(typeof(HeroController).GetMethod("SetStartWithAttack", BindingFlagsAll));

        var sw = Stopwatch.StartNew();

        // Initialization logic here
        Logger.LogInfo($"Subscribing to 20 events at {sw.Elapsed.TotalMilliseconds} ms");

        var HookOne = new Hook(typeof(PlayerData).GetMethod("CacheSavedFleas", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookOne", BindingFlags.Public | BindingFlags.Static));
        var HookTwo = new Hook(typeof(HeroController).GetMethod("TempStoreCurrency", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookTwo", BindingFlags.Public | BindingFlags.Static));
        var HookThree = new Hook(typeof(HealthManager).GetMethod("ClearItemDropsBattleScene", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookThree", BindingFlags.Public | BindingFlags.Static));
        var HookFour = new Hook(typeof(QuestBoardInteractable).GetMethod("OpenBoard", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookFour", BindingFlags.Public | BindingFlags.Static));
        var HookFive = new Hook(typeof(PlayerData).GetMethod("GetAllPowerups", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookFive", BindingFlags.Public | BindingFlags.Static));
        var HookSix = new Hook(typeof(HeroController).GetMethod("SetStartWithAttack", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookSix", BindingFlags.Public | BindingFlags.Static));
        var HookSeven = new Hook(typeof(HealthManager).GetMethod("SetDead", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookSeven", BindingFlags.Public | BindingFlags.Static));
        var HookEight = new Hook(typeof(HeroTriggerFader).GetMethod("ShouldBeVisible", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookEight", BindingFlags.Public | BindingFlags.Static));
        var HookNine = new Hook(typeof(PlayerData).GetMethod("MaxHealth", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookNine", BindingFlags.Public | BindingFlags.Static));
        var HookTen = new Hook(typeof(HeroController).GetMethod("SetStartWithBackflipJump", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookTen", BindingFlags.Public | BindingFlags.Static));
        var HookEleven = new Hook(typeof(HealthManager).GetMethod("SendDeathEvent", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookEleven", BindingFlags.Public | BindingFlags.Static));
        var HookTwelve = new Hook(typeof(HeroSlabCapture).GetMethod("ApplyCaptured", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookTwelve", BindingFlags.Public | BindingFlags.Static));
        var HookThirteen = new Hook(typeof(PlayerData).GetMethod("ActivateTestingCheats", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookThirteen", BindingFlags.Public | BindingFlags.Static));
        var HookFourteen = new Hook(typeof(HeroController).GetMethod("SilkChargeEnd", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookFourteen", BindingFlags.Public | BindingFlags.Static));
        var HookFifteen = new Hook(typeof(HealthManager).GetMethod("GetIsDead", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookFifteen", BindingFlags.Public | BindingFlags.Static));
        var HookSixteen = new Hook(typeof(SilkGrubCocoon).GetMethod("WasHit", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookSixteen", BindingFlags.Public | BindingFlags.Static));
        var HookSeventeen = new Hook(typeof(PlayerData).GetMethod("MapperLeaveAll", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookSeventeen", BindingFlags.Public | BindingFlags.Static));
        var HookEighteen = new Hook(typeof(HeroController).GetMethod("IsSwimming", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookEighteen", BindingFlags.Public | BindingFlags.Static));
        var HookNineteen = new Hook(typeof(HealthManager).GetMethod("GetAttackDirection", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookNineteen", BindingFlags.Public | BindingFlags.Static));
        var HookTwenty = new Hook(typeof(HeroWispLantern).GetMethod("EffectsCleared", BindingFlagsAll), typeof(ScienceEvents20Plugin).GetMethod("HookTwenty", BindingFlags.Public | BindingFlags.Static));

        sw.Stop();
        Logger.LogInfo($"Finished subscribing to 20 events at {sw.Elapsed.TotalMilliseconds} ms");
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
}