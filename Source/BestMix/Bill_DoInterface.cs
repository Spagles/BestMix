using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace BestMix;

[HarmonyPatch(typeof(Bill), nameof(Bill.DoInterface))]
public static class Bill_DoInterface
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var billStackFieldInfo = AccessTools.Field(typeof(Bill), "billStack");
        var endGroupGUI = AccessTools.Method(typeof(Widgets), nameof(Widgets.EndGroup));
        var addBmGuiPart = AccessTools.Method(typeof(Bill_DoInterface), nameof(AddBmGui),
            [typeof(float), typeof(BillStack), typeof(Bill)]);

        var instructionList = instructions.ToList();
        var length = instructionList.Count;
        for (var i = 0; i < length; i++)
        {
            var codeInstruction = instructionList[i];
            if (instructionList[i].opcode == OpCodes.Call && instructionList[i].Calls(endGroupGUI))
            {
                // push width value to stack
                yield return new CodeInstruction(OpCodes.Ldarg, 3) { labels = codeInstruction.labels };

                // push BillStack instance to stack
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldfld, billStackFieldInfo);

                // push Bill instance to stack
                yield return new CodeInstruction(OpCodes.Ldarg_0);

                // call static method
                yield return new CodeInstruction(OpCodes.Call, addBmGuiPart);

                // returning original code.
                yield return new CodeInstruction(OpCodes.Call, codeInstruction.operand);

                continue; // preventing duplicating same IL twice.
            }

            yield return codeInstruction;
        }
    }

    public static void AddBmGui(float width, BillStack billstack, Bill bill)
    {
        if (bill.recipe.IsSurgery)
        {
            return;
        }

        var baseColor = Color.white;
        var rectBm = new Rect(width - (24f + 150f), 0f, 24f, 24f);
        var bmTex = BMBillUtility.GetBillBmTex(billstack.billGiver as Thing, bill);
        if (!Widgets.ButtonImage(rectBm, bmTex, baseColor, baseColor * GenUI.SubtleMouseoverColor))
        {
            return;
        }

        BMBillUtility.SetBillBmVal(billstack.billGiver as Thing, bill);
        SoundDefOf.Click.PlayOneShotOnCamera();
    }
}