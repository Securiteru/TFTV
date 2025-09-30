using HarmonyLib;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Equipments;
using System.Reflection;

namespace TFTV
{
    public class RetrievableItems
    {
        // Patch: ShouldDestroyItem
        [HarmonyPatch(typeof(DieAbility), "ShouldDestroyItem")]
        public static class PhoenixPoint_DieAbility_ShouldDestroyItem_Patch
        {
            public static bool Prefix(DieAbility __instance, ref bool __result, ref TacticalItem item)
            {
                if (__instance.TacticalActor.IsControlledByPlayer)
                {
                    return true; // Let original run
                }
                __result = false;
                return false; // Skip original
            }
        }

        // Patch: DropItems
        [HarmonyPatch(typeof(DieAbility), "DropItems")]
        public static class PhoenixPoint_DieAbility_DropItems_Patch
        {
            public static bool Prefix(DieAbility __instance)
            {
                if (__instance.DieAbilityDef.DestroyItems)
                {
                    __instance.DieAbilityDef.DestroyItems = false;
                }
                return true;
            }
        }

        // Initialize: Patch all
        public void Initialize()
        {
            var harmony = new Harmony("io.github.realitymachina.retrievableitems");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
} 