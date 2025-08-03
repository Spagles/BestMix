using System.Reflection;
using HarmonyLib;
using Multiplayer.API;
using Verse;

namespace BestMix;

[StaticConstructorOnStartup]
internal static class MultiplayerSupport
{
    private static readonly Harmony harmony = new("rimworld.pelador.bestmix.multiplayersupport");

    static MultiplayerSupport()
    {
        if (!MP.enabled)
        {
            return;
        }

        //SyncMethods
        MP.RegisterSyncMethod(typeof(BMBillUtility), nameof(BMBillUtility.SetBMixBillMode));
        MP.RegisterSyncMethod(typeof(CompBestMix), nameof(CompBestMix.SetBMixMode));

        // Add all Methods where there is Rand calls here
        var methods = new[]
        {
            AccessTools.Method(typeof(BestMixUtility), nameof(BestMixUtility.RndFloat))
        };
        foreach (var method in methods)
        {
            fixRng(method);
        }
    }

    private static void fixRng(MethodInfo method)
    {
        harmony.Patch(method,
            new HarmonyMethod(typeof(MultiplayerSupport), nameof(fixRngPre)),
            new HarmonyMethod(typeof(MultiplayerSupport), nameof(fixRngPos))
        );
    }

    private static void fixRngPre()
    {
        Rand.PushState(Find.TickManager.TicksAbs);
    }

    private static void fixRngPos()
    {
        Rand.PopState();
    }
}