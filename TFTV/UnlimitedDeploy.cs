using HarmonyLib;
using PhoenixPoint.Geoscape.Entities;
using PhoenixPoint.Geoscape.View.ViewControllers.Roster;
using PhoenixPoint.Geoscape.View.ViewModules;
using PhoenixPoint.Geoscape.View.ViewStates;
using PhoenixPoint.Tactical.Levels.ActorDeployment;
using PhoenixPoint.Tactical.Levels.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace TFTV
{
    public class UnlimitedDeploy
    {
        // Patch: Remove squad cap before deployment setup
        [HarmonyPatch(typeof(UIStateRosterDeployment), "SetUpInitialDeployment")]
        public static class Patch_SetUpInitialDeployment
        {
            public static void Prefix(GeoMission ____mission)
            {
                try
                {
                    // Remove the cap by setting a very high value
                    ____mission.MissionDef.MaxPlayerUnits = 9999;
                }
                catch (Exception ex)
                {
                    Debug.LogError($"UnlimitedDeploy: Error removing deploy cap: {ex}");
                }
            }
        }

        // Patch: Hide squad cap in UI
        [HarmonyPatch(typeof(UIModuleDeploymentMissionBriefing), "SetCurrentDeployment")]
        public static class Patch_SetCurrentDeployment
        {
            public static bool Prefix(UIModuleDeploymentMissionBriefing __instance, int currentDeploymentNumber)
            {
                try
                {
                    // Remove the "/{1}" from the squad slots used text
                    string text = __instance.SquadSlotsUsedTextKey.Localize(null).Replace("/{1}", "");
                    __instance.SquadSlotsUsedText.text = string.Format(text, currentDeploymentNumber, "");
                    return false; // Skip original
                }
                catch (Exception ex)
                {
                    Debug.LogError($"UnlimitedDeploy: Error hiding deploy cap: {ex}");
                    return true;
                }
            }
        }

        // Patch: Allow unlimited deployment in squad selection
        [HarmonyPatch(typeof(UIStateRosterDeployment), "OnEnrollmentChanged")]
        public static class Patch_OnEnrollmentChanged
        {
            public static bool Prefix(UIStateRosterDeployment __instance, GeoRosterDeploymentItem item, List<GeoRosterDeploymentItem> ____deploymentItems)
            {
                try
                {
                    // Toggle enrollment
                    item.EnrollForDeployment = !item.EnrollForDeployment;
                    item.RefreshCheckVisuals();
                    // Update deploy button state
                    var selected = ____deploymentItems.Where(i => i.EnrollForDeployment);
                    Patch_OverrideSetRecruitment_UncapDeploy.Patch(__instance, selected);
                    return false; // Skip original
                }
                catch (Exception ex)
                {
                    Debug.LogError($"UnlimitedDeploy: Error in OnEnrollmentChanged: {ex}");
                    return true;
                }
            }
        }

        // Helper for updating deploy button state
        public static class Patch_OverrideSetRecruitment_UncapDeploy
        {
            public static void Patch(UIStateRosterDeployment __instance, IEnumerable<GeoRosterDeploymentItem> squad)
            {
                try
                {
                    int count = squad.Count(i => i.EnrollForDeployment);
                    var briefing = typeof(UIStateRosterDeployment).GetProperty("_missionBriefingModule", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(__instance) as UIModuleDeploymentMissionBriefing;
                    if (briefing != null)
                    {
                        briefing.SetCurrentDeployment(count, 0);
                        briefing.DeployButton.SetInteractable(count > 0);
                        briefing.DeployButton.ResetButtonAnimations();
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"UnlimitedDeploy: Error updating deploy button: {ex}");
                }
            }
        }

        // Initialize: Patch all
        public void Initialize()
        {
            var harmony = new Harmony("io.github.sheepy.unlimiteddeploy");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
} 