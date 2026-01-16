using System;
using System.Diagnostics;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace Null0;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "Null0")]
public partial class Null0Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        var sw = Stopwatch.StartNew();
        Logger.LogInfo($"Doing nothing at {sw.Elapsed.TotalMilliseconds} ms");
        sw.Stop();
        Logger.LogInfo($"Finished doing nothing at {sw.Elapsed.TotalMilliseconds} ms");
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }
}


