using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using System.Diagnostics;
namespace ScienceEvents10;


// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.u-tale.scienceevents10")]
public partial class ScienceEvents10Plugin : BaseUnityPlugin
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
        Logger.LogInfo($"Subscribing to 10 events at {sw.ElapsedMilliseconds} ms");

        var HookOne = new Hook(typeof(PlayerData).GetMethod("CacheSavedFleas", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookOne", BindingFlags.Public | BindingFlags.Static));
        var HookTwo = new Hook(typeof(HeroController).GetMethod("TempStoreCurrency", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookTwo", BindingFlags.Public | BindingFlags.Static));
        var HookThree = new Hook(typeof(HealthManager).GetMethod("ClearItemDropsBattleScene", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookThree", BindingFlags.Public | BindingFlags.Static));
        var HookFour = new Hook(typeof(QuestBoardInteractable).GetMethod("OpenBoard", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookFour", BindingFlags.Public | BindingFlags.Static));
        var HookFive = new Hook(typeof(PlayerData).GetMethod("GetAllPowerups", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookFive", BindingFlags.Public | BindingFlags.Static));
        var HookSix = new Hook(typeof(HeroController).GetMethod("SetStartWithAttack", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookSix", BindingFlags.Public | BindingFlags.Static));
        var HookSeven = new Hook(typeof(HealthManager).GetMethod("SetDead", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookSeven", BindingFlags.Public | BindingFlags.Static));
        var HookEight = new Hook(typeof(HeroTriggerFader).GetMethod("ShouldBeVisible", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookEight", BindingFlags.Public | BindingFlags.Static));
        var HookNine = new Hook(typeof(PlayerData).GetMethod("MaxHealth", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookNine", BindingFlags.Public | BindingFlags.Static));
        var HookTen = new Hook(typeof(HeroController).GetMethod("SetStartWithBackflipJump", BindingFlagsAll), typeof(ScienceEvents10Plugin).GetMethod("HookTen", BindingFlags.Public | BindingFlags.Static));


        sw.Stop();
        Logger.LogInfo($"Finished subscribing to 10 events at {sw.ElapsedMilliseconds} ms");
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

}