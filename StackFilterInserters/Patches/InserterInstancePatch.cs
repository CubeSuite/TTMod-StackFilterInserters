using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace StackFilterInserters.Patches
{
    public class InserterDefinitionPatch 
    {
        private static bool stackInserterUnlocked = false;

        [HarmonyPatch(typeof(InserterDefinition), "InitInstance")]
        [HarmonyPostfix]
        private static void setToStack(ref InserterInstance newInstance) {
            if (newInstance.isFilter) {
                newInstance.isStack = true;
            }
        }
    }

    //public class InserterInstancePatch
    //{
    //    private static bool stackInserterUnlocked = false;
    //    private static bool hasPrinted = false;

    //    [HarmonyPatch(typeof(InserterInstance), "Give")]
    //    [HarmonyPrefix]
    //    private static void setIsStack(InserterInstance __instance) {
    //        if(__instance.isStack && __instance.isFilter) {
    //            Debug.Log("Stack filter is giving");
    //        }
    //    }

    //    [HarmonyPatch(typeof(InserterInstance), "Take")]
    //    [HarmonyPrefix]
    //    private static bool debugTake(InserterInstance __instance) {
            

    //        if (stackInserterUnlocked && __instance.isFilter && !__instance.isStack) {
    //            __instance.isStack = true;
    //            Debug.Log($"Setting filter inserter to stack mode");
    //        }

    //        if (__instance.isStack && __instance.isFilter) {
    //            Debug.Log($"Take called for insterter: filter {__instance.isFilter}, {__instance.isStack}");
    //        }

    //        int NumHandSlotsRemaining = (__instance.isStack ? __instance.maxStackSize : 1) - __instance.currentHeldStackCount; // Amount left in hand
    //        int resID_FilterID = (__instance.currentHeldResType > 0) ? __instance.currentHeldResType : __instance.filterType; // -1 if empty

    //        if(__instance.isStack && __instance.isFilter) {
    //            Debug.Log($"{NumHandSlotsRemaining} / {__instance.maxStackSize} hand slots available");
    //            Debug.Log($"currentHelpResType: {__instance.currentHeldResType.ToString()}");
    //            Debug.Log($"FilterType: {__instance.filterType}");
    //            hasPrinted = true;
    //        }

    //        ResourceStack resourceStack;
    //        if (__instance.takeResourceContainer.TakeAvailableRes(out resourceStack, resID_FilterID, NumHandSlotsRemaining)) {
    //            __instance.resourceTakenThisFrame = resourceStack.id;
    //            __instance.SetHeldItem(resourceStack.info);
    //            Debug.Log($"Stack in hand: {resourceStack.info.displayName}, Count: {resourceStack.count}");
    //            bool isHandFull = resourceStack.count >= NumHandSlotsRemaining;
    //            Debug.Log(isHandFull ? "Hand is full" : "Hand is not full");
    //            __instance.currentHeldStackCount += resourceStack.count;
    //            Debug.Log($"New hand stack count: {__instance.currentHeldStackCount}");
    //            if (isHandFull) {
    //                Debug.Log($"Moving to give");
    //                __instance.armState = InserterInstance.ArmState.SwingingToGive;
    //                __instance.animState = 0f;
    //                __instance.queuedSound = InserterInstance.InserterSound.Retract;
    //            }
    //        }

    //        return false;
    //    }
    //}
}
