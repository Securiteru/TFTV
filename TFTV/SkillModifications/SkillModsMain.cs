using Base.Defs;
using Base.Entities.Abilities;
using Base.Entities.Effects;
using Base.Entities.Effects.ApplicationConditions;
using Base.Entities.Statuses;
using Base.UI;
using HarmonyLib;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Common.UI;
using PhoenixPoint.Tactical;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Effects;
using PhoenixPoint.Tactical.Entities.Effects.ApplicationConditions;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Statuses;
using PRMBetterClasses.Tactical.Entities.DamageKeywords;
using System;
using System.Collections.Generic;
using System.Linq;
using TFTV;
using UnityEngine;

namespace PRMBetterClasses.SkillModifications
{
    internal class SkillModsMain
    {

        private static readonly DefCache DefCache = TFTVMain.Main.DefCache;
        public static SharedSoloEffectorDamageKeywordsDataDef sharedSoloDamageKeywords;

        public static void ApplyChanges()
        {
            try
            {
                // Create solo DamageKeywords
                sharedSoloDamageKeywords = new SharedSoloEffectorDamageKeywordsDataDef();

                // Create Umbra class tag and apply it to their actor defs
                UmbraClassTag();

                // Fix balance issues with psychic abilities and add umbra class tag to not use it against them
                FixPsychicAbilitiesIssues();

                // Change Recover to reduce viral by half
                Change_RecoverToReduceViral();

                // Change stealth ability and indicator skill and apply on all base class proficiency skills
                Apply_StealthIndicator_AllClasses();

                // Assault skills ------------------------------------------------------
                AssaultSkills.ApplyChanges();

                // Sniper skills start ------------------------------------------------------
                SniperSkills.ApplyChanges();

                // Heavy skills start --------------------------------------------------------
                HeavySkills.ApplyChanges();

                // Berserker skills start ----------------------------------------------------
                BerserkerSkills.ApplyChanges();

                // Infiltrator skills start --------------------------------------------------
                InfiltratorSkills.ApplyChanges();

                // Technician skills start ---------------------------------------------------
                TechnicianSkills.ApplyChanges();

                // Priest skills start -------------------------------------------------------
                PriestSkills.ApplyChanges();

                // Call Background perk changes -------------------------------------------------------
                BackgroundPerks.ApplyChanges();

                // Faction perks
                FactionPerks.ApplyChanges();

                // Tweaking the weapon proficiency perks incl. descriptions, see below
                Change_ProficiencyPerks();

                // BattleFocus, currently used as placeholder, will go to Vengeance Torso
                Create_BattleFocus();

                // New custom abilities
                Create_Entrench();
                Create_Suppression();
                Create_VeilOfShadows();
                Create_ExtendedWatch();
                Create_SuppressiveBarrage();
                Create_SuppressiveOverwatch();
                Create_DrumMagazine();

                // Set SP for all skills according to where they are set
                Set_SPcost();
            }

        // Heavy: Suppressive Overwatch (multi-trigger during enemy turn, dmg x0.33, pin on hit)
        public static void Create_SuppressiveOverwatch()
        {
            try
            {
                string skillName = "SuppressiveOverwatch_AbilityDef";
                var defCache = TFTVMain.Main.DefCache;

                // Base self-target apply ability
                ApplyStatusAbilityDef baseSelf = defCache.GetDef<ApplyStatusAbilityDef>("QuickAim_AbilityDef");
                ApplyStatusAbilityDef supOW = Helper.CreateDefFromClone(
                    baseSelf,
                    "7b8f5a2e-0e0d-4b4f-8a5a-0d3f4a1b2c11",
                    skillName);
                supOW.CharacterProgressionData = Helper.CreateDefFromClone(
                    baseSelf.CharacterProgressionData,
                    "c7f7a9a1-0e2b-4d1b-a0a3-71f8b3dc9a77",
                    skillName);
                supOW.ViewElementDef = Helper.CreateDefFromClone(
                    baseSelf.ViewElementDef,
                    "d1b1a2f3-2d3e-42e7-9a73-9c7a8b2c1e33",
                    skillName);

                // Stance status that reduces damage and serves as a marker
                DamageMultiplierStatusDef dmgMult = Helper.CreateDefFromClone(
                    defCache.GetDef<DamageMultiplierStatusDef>("E_Status [RageBurstAbilityDef]"),
                    "2f7e2db0-2d5e-4c8f-9a9b-1c4b7f2a33d9",
                    $"E_DamageMult_SuppressiveOW [{skillName}]");
                dmgMult.Visuals = Helper.CreateDefFromClone(
                    supOW.ViewElementDef,
                    "b7b91a7d-78a7-4b5e-8c51-0f53c622e3e0",
                    $"E_View [E_DamageMult_SuppressiveOW [{skillName}]]");
                dmgMult.Visuals.DisplayName1.LocalizationKey = "PR_BC_SUPPRESSIVE_OW_STATUS";
                dmgMult.Visuals.Description.LocalizationKey = "PR_BC_SUPPRESSIVE_OW_STATUS_DESC";
                dmgMult.Multiplier = 0.33f; // reduce damage to a third
                dmgMult.DurationTurns = 1;
                dmgMult.ExpireOnEndOfTurn = true;
                dmgMult.SingleInstance = true;

                // Marker status to detect in OW re-arm patch
                TacStatusDef marker = Helper.CreateDefFromClone<TacStatusDef>(
                    null,
                    "8d6bc1b0-7c0b-4f77-9c67-8f4ccf0b2a61",
                    "SuppressiveOW_Active_Marker_StatusDef");
                marker.EffectName = marker.name;
                marker.DurationTurns = 1;
                marker.ExpireOnEndOfTurn = true;
                marker.Visuals = dmgMult.Visuals;

                // Multi-status: apply both marker and damage multiplier
                MultiStatusDef multi = Helper.CreateDefFromClone(
                    defCache.GetDef<MultiStatusDef>("E_Status [FastUse_AbilityDef]"),
                    "f22c2bcd-1a4c-462e-8b85-66ed4d1a6138",
                    $"E_MultiStatuses [{skillName}]");
                multi.Statuses = new StatusDef[] { dmgMult, marker };

                supOW.StatusDef = multi;
                supOW.ViewElementDef.DisplayName1.LocalizationKey = "PR_BC_SUPPRESSIVE_OVERWATCH";
                supOW.ViewElementDef.Description.LocalizationKey = "PR_BC_SUPPRESSIVE_OVERWATCH_DESC";
                Sprite icon = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_PersonalTrack_TacticalAnalyst.png");
                supOW.ViewElementDef.LargeIcon = icon;
                supOW.ViewElementDef.SmallIcon = icon;
                supOW.ActionPointCost = 0.5f;
                supOW.WillPointCost = 2.0f;

                // TODO: Harmony patch will detect this marker and re-arm OW after OW shots during enemy turn.
                // TODO: On OW hit, apply the pinned debuff from Suppressive Barrage if present.
            }
            catch (System.Exception e)
            {
                PRMLogger.Error(e);
            }
        }

        // Heavy: Drum Magazine (−2 Speed, increase heavy weapon clip to 10) — passive shell
        public static void Create_DrumMagazine()
        {
            try
            {
                string skillName = "DrumMagazine_AbilityDef";
                var defCache = TFTVMain.Main.DefCache;

                PassiveModifierAbilityDef basePassive = defCache.GetDef<PassiveModifierAbilityDef>("EagleEyed_AbilityDef");
                PassiveModifierAbilityDef drum = Helper.CreateDefFromClone(
                    basePassive,
                    "ae86d3f8-3d0f-4a3a-9f7c-6b7b3c2a9e70",
                    skillName);
                drum.CharacterProgressionData = Helper.CreateDefFromClone(
                    basePassive.CharacterProgressionData,
                    "abf2f0e1-8832-4df1-9a45-5b0d9a4d6b9d",
                    skillName);
                drum.ViewElementDef = Helper.CreateDefFromClone(
                    basePassive.ViewElementDef,
                    "b2d7a25e-9b3e-4c4e-9d9a-3a7d9f2c6e5b",
                    skillName);

                drum.StatModifications = new ItemStatModification[]
                {
                    new ItemStatModification
                    {
                        TargetStat = StatModificationTarget.Speed,
                        Modification = StatModificationType.Add,
                        Value = -2f
                    }
                };
                drum.ViewElementDef.DisplayName1.LocalizationKey = "PR_BC_DRUM_MAGAZINE";
                drum.ViewElementDef.Description.LocalizationKey = "PR_BC_DRUM_MAGAZINE_DESC";
                Sprite icon = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_Armor_Packs.png");
                drum.ViewElementDef.LargeIcon = icon;
                drum.ViewElementDef.SmallIcon = icon;

                // NOTE: Per-actor ammo bump to 10 for heavy-tag weapons will be handled by a small runtime hook
                // on mission start and on equipment change, adjusting Weapon instances (not global defs).
            }
            catch (System.Exception e)
            {
                PRMLogger.Error(e);
            }
        }

        // Extended Watch: Overwatch costs 0 AP for 1 turn; helps chaining OW across rounds
        public static void Create_ExtendedWatch()
        {
            try
            {
                string skillName = "ExtendedWatch_AbilityDef";
                DefCache DefCache = TFTVMain.Main.DefCache;

                // Prepare a dedicated tag and attach it to Overwatch ability
                SkillTagDef baseTag = DefCache.GetDef<SkillTagDef>("AttackAbility_SkillTagDef");
                SkillTagDef owTag = Helper.CreateDefFromClone(
                    baseTag,
                    "4a9b9a5d-8f0a-4a75-8dbe-95d4dbb3f97a",
                    "ExtendedWatch_Overwatch_SkillTagDef");
                TacticalAbilityDef overwatchAD = DefCache.GetDef<TacticalAbilityDef>("Overwatch_AbilityDef");
                if (overwatchAD != null && !overwatchAD.SkillTags.Contains(owTag))
                {
                    overwatchAD.SkillTags = overwatchAD.SkillTags.AddToArray(owTag);
                }

                // Ability shell
                ApplyStatusAbilityDef source = DefCache.GetDef<ApplyStatusAbilityDef>("QuickAim_AbilityDef");
                ApplyStatusAbilityDef extWatch = Helper.CreateDefFromClone(
                    source,
                    "f8f5bcb7-8b62-462e-9d3c-c501b1b8b1bc",
                    skillName);
                extWatch.CharacterProgressionData = Helper.CreateDefFromClone(
                    source.CharacterProgressionData,
                    "d5bbadf9-a2f6-4ef3-9c9e-ef5f1a4f437b",
                    skillName);
                extWatch.ViewElementDef = Helper.CreateDefFromClone(
                    source.ViewElementDef,
                    "d0b5a3b2-3235-4b3e-8a63-9d335e3b5c0f",
                    skillName);

                // Cost modifier targeting Overwatch via tag
                ChangeAbilitiesCostStatusDef owCost = Helper.CreateDefFromClone(
                    DefCache.GetDef<ChangeAbilitiesCostStatusDef>("E_AbilityCostModifier [QuickAim_AbilityDef]"),
                    "c0ad8e15-1a0f-4d3e-9a38-8e42f2d1a6a5",
                    $"E_OverwatchCostModifier [{skillName}]");
                owCost.Visuals = extWatch.ViewElementDef;
                owCost.DurationTurns = 2; // make it persist for two rounds
                owCost.ExpireOnEndOfTurn = false;
                owCost.SingleInstance = false;
                owCost.AbilityCostModification.TargetAbilityTagDef = owTag;
                owCost.AbilityCostModification.SkillTagCullFilter = null;
                owCost.AbilityCostModification.EquipmentTagDef = null;
                owCost.AbilityCostModification.AbilityCullFilter = null;
                owCost.AbilityCostModification.ActionPointModType = TacticalAbilityModificationType.Multiply;
                owCost.AbilityCostModification.ActionPointMod = 0f; // free OW

                // Wire
                extWatch.StatusDef = owCost;
                extWatch.ViewElementDef.DisplayName1.LocalizationKey = "PR_BC_EXTENDED_WATCH";
                extWatch.ViewElementDef.Description.LocalizationKey = "PR_BC_EXTENDED_WATCH_DESC";
                Sprite icon = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_EquipmentAbility_OverwatchFocus-2.png");
                extWatch.ViewElementDef.LargeIcon = icon;
                extWatch.ViewElementDef.SmallIcon = icon;
                extWatch.ActionPointCost = 0.5f;
                extWatch.WillPointCost = 2.0f;
            }
            catch (System.Exception e)
            {
                PRMLogger.Error(e);
            }
        }

        // Suppressive Barrage (Heavy): AoE debuff (Speed, Accuracy) to enemies in radius
        public static void Create_SuppressiveBarrage()
        {
            try
            {
                string skillName = "SuppressiveBarrage_AbilityDef";
                DefCache DefCache = TFTVMain.Main.DefCache;

                // Base AoE from Psychic Scream
                ApplyStatusAbilityDef source = DefCache.GetDef<ApplyStatusAbilityDef>("Priest_PsychicScream_AbilityDef");
                ApplyStatusAbilityDef sup = Helper.CreateDefFromClone(
                    source,
                    "6ae5bd2d-2a64-47f5-9c1a-84bf0f2a5a9d",
                    skillName);
                sup.CharacterProgressionData = Helper.CreateDefFromClone(
                    source.CharacterProgressionData,
                    "c2d5d4b6-4ba8-4c14-8b0a-9339eae4b6a4",
                    skillName);
                sup.ViewElementDef = Helper.CreateDefFromClone(
                    source.ViewElementDef,
                    "a77c24d8-4a2a-4c9a-9f3f-8c9e3e7f8b3e",
                    skillName);

                // Debuff status applied to enemies
                StanceStatusDef pinned = Helper.CreateDefFromClone(
                    DefCache.GetDef<StanceStatusDef>("E_SneakAttackStatus [SneakAttack_AbilityDef]"),
                    "f0d41d39-1f74-43a4-bc42-5f0d2b0f9e9d",
                    $"E_SuppressiveDebuff [{skillName}]");
                pinned.Visuals = Helper.CreateDefFromClone(
                    sup.ViewElementDef,
                    "ed2a3f19-93a7-4db1-9404-50e39a6a3f66",
                    $"E_View [E_SuppressiveDebuff [{skillName}]]");
                pinned.Visuals.DisplayName1.LocalizationKey = "PR_BC_SUPPRESSIVE_BARRAGE_STATUS";
                pinned.Visuals.Description.LocalizationKey = "PR_BC_SUPPRESSIVE_BARRAGE_STATUS_DESC";
                pinned.DurationTurns = 1;
                pinned.SingleInstance = true;
                pinned.StatModifications = new ItemStatModification[]
                {
                    new ItemStatModification { TargetStat = StatModificationTarget.Speed, Modification = StatModificationType.Add, Value = -2 },
                    new ItemStatModification { TargetStat = StatModificationTarget.Accuracy, Modification = StatModificationType.Add, Value = -0.2f },
                };

                // Wire
                sup.StatusDef = pinned;
                sup.ViewElementDef.DisplayName1.LocalizationKey = "PR_BC_SUPPRESSIVE_BARRAGE";
                sup.ViewElementDef.Description.LocalizationKey = "PR_BC_SUPPRESSIVE_BARRAGE_DESC";
                Sprite icon = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_PersonalTrack_TacticalAnalyst.png");
                sup.ViewElementDef.LargeIcon = icon;
                sup.ViewElementDef.SmallIcon = icon;
                sup.ActionPointCost = 1.0f;
                sup.WillPointCost = 3.0f;
                // Range/area (reuse scream radius)
                sup.TargetingDataDef.Origin.Range = source.TargetingDataDef.Origin.Range + 2f; // slightly larger
            }
            catch (System.Exception e)
            {
                PRMLogger.Error(e);
            }
        }

        internal static void UmbraClassTag()
        {
            try
            {
                // Create a new ClassTagDef and SubstanceTypeTagDef for Umbras and add/replace them to their actor def
                ClassTagDef umbraClassTag = Helper.CreateDefFromClone(
                    DefCache.GetDef<ClassTagDef>("Crabman_ClassTagDef"),
                    "092D50F3-B4E7-4B8E-9AD3-47E31DBAE82C",
                    "Umbra_ClassTagDef");

                foreach (TacticalActorDef umbra in new TacticalActorDef[] { DefCache.GetDef<TacticalActorDef>("Oilcrab_ActorDef"), DefCache.GetDef<TacticalActorDef>("Oilfish_ActorDef") })
                {
                    if (umbra.GameTags.CanAdd(umbraClassTag))
                    {
                        umbra.GameTags.Add(umbraClassTag);
                    }
                }
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        private static void FixPsychicAbilitiesIssues()
        {
            TacticalAbilityDef[] psychicAbilities = {
                DefCache.GetDef<TacticalAbilityDef>("Priest_MindControl_AbilityDef"),
                DefCache.GetDef<TacticalAbilityDef>("Exalted_MindControl_AbilityDef"),
                DefCache.GetDef<TacticalAbilityDef>("InducePanic_AbilityDef"),
                DefCache.GetDef<TacticalAbilityDef>("Exalted_InducePanic_AbilityDef"),
                DefCache.GetDef<TacticalAbilityDef>("Priest_PsychicScream_AbilityDef"),
                DefCache.GetDef<TacticalAbilityDef>("Siren_PsychicScream_AbilityDef"),
                DefCache.GetDef<TacticalAbilityDef>("MindCrush_AbilityDef"),
                DefCache.GetDef<TacticalAbilityDef>("Exalted_MindCrush_AbilityDef"),
            };
            SkillTagDef attackSkillTag = DefCache.GetDef<SkillTagDef>("AttackAbility_SkillTagDef");
            GameTagDef metallicSubstanceTag = DefCache.GetDef<GameTagDef>("Metallic_SubstanceTypeTagDef");
            GameTagDef umbraClassTag = DefCache.GetDef<GameTagDef>("Umbra_ClassTagDef");
            foreach (TacticalAbilityDef abilityDef in psychicAbilities)
            {
                if (!abilityDef.SkillTags.Contains(attackSkillTag))
                {
                    abilityDef.SkillTags = abilityDef.SkillTags.AddItem(attackSkillTag).ToArray();
                }
                if (abilityDef.TargetingDataDef.Origin.TargetTags.Contains(metallicSubstanceTag))
                {
                    abilityDef.TargetingDataDef.Origin.TargetTags.Remove(metallicSubstanceTag);
                }
                if (abilityDef.TargetingDataDef.Origin.CullTargetTags.CanAdd(umbraClassTag))
                {
                    abilityDef.TargetingDataDef.Origin.CullTargetTags.Add(umbraClassTag);
                }
                if (abilityDef.TargetingDataDef.Target.CullTargetTags.CanAdd(umbraClassTag))
                {
                    abilityDef.TargetingDataDef.Target.CullTargetTags.Add(umbraClassTag);
                }
            }
        }

        // Make ViralValueChange_EffectDef accessible to Harmony patch for Revover ability (see below)
        internal static ChangeStatusValueEffectDef ViralValueChange_EffectDef;
        private static void Change_RecoverToReduceViral()
        {
            DefCache DefCache = TFTVMain.Main.DefCache;
            // Change description of Recover ability to reflect that it reduces Virus by half
            RecoverWillAbilityDef recover = DefCache.GetDef<RecoverWillAbilityDef>("RecoverWill_AbilityDef");
            recover.ViewElementDef.Description.LocalizationKey = "PR_BC_RECOVER_DESC";
            // Create a new effect to change the virus value, cloned from 'ParalysisValueChange_0.5_EffectDef'
            ViralValueChange_EffectDef = Helper.CreateDefFromClone(
                DefCache.GetDef<ChangeStatusValueEffectDef>("ParalysisValueChange_0.5_EffectDef"),
                "1bb3b06f-55d5-44a0-8cf7-e5382577c4df",
                "ViralValueChange_0.5_EffectDef");
            ViralValueChange_EffectDef.StatusDef = DefCache.GetDef<TacStatusDef>("Infected_StatusDef"); // Infected_StatusDef = virus applied
        }
        // Recover ability: Patching GetWillpowerRecover when character uses Recover to also reduce viral value by half
        [HarmonyPatch(typeof(RecoverWillAbility), "GetStatusSource")]
        internal static class RecoverWillAbility_GetStatusSource_Patch
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051")]
            private static void Postfix(RecoverWillAbility __instance)
            {
                Effect.Apply(TFTVMain.Repo, ViralValueChange_EffectDef, TacUtil.GetActorEffectTarget(__instance.TacticalActorBase, null));
            }
        }

        // Static variables to save icon and localization keys that otherwise would get lost in subsequent calls
        internal static Sprite InfiltratorStealthIcon = null;
        internal static string InfiltratorStealthDisplayName1LocKey = string.Empty;
        internal static string InfiltratorStealthDescriptionLocKey = string.Empty;
        private static void Apply_StealthIndicator_AllClasses()
        {
            DefCache DefCache = TFTVMain.Main.DefCache;
            // Get stealth indicator ability
            ApplyStatusAbilityDef baseForAll = DefCache.GetDef<ApplyStatusAbilityDef>("Stealth_AbilityDef");
            // Save icon and localization keys for subsequent calls, the base ones get overwritten (see below)
            if (InfiltratorStealthIcon == null)
            {
                InfiltratorStealthIcon = baseForAll.ViewElementDef.LargeIcon;
                InfiltratorStealthDisplayName1LocKey = baseForAll.ViewElementDef.DisplayName1.LocalizationKey;
                InfiltratorStealthDescriptionLocKey = baseForAll.ViewElementDef.Description.LocalizationKey;
            }

            // Clone base skill for special Infiltrator skill to keep the stealth bonus on Infiltrator
            string skillName = "StealthInfiltrator_";
            ApplyStatusAbilityDef stealthInfiltrator = Helper.CreateDefFromClone(
                baseForAll,
                "842d9c62-34f7-474c-942c-2676fef2f7e6",
                skillName + "AbilityDef");
            stealthInfiltrator.ViewElementDef = Helper.CreateDefFromClone(
                baseForAll.ViewElementDef,
                "6dfeca1f-1434-44d1-8f40-1843ce204044",
                skillName + "ViewElementDef");
            stealthInfiltrator.ViewElementDef.LargeIcon = InfiltratorStealthIcon;
            stealthInfiltrator.ViewElementDef.SmallIcon = InfiltratorStealthIcon;
            stealthInfiltrator.ViewElementDef.DisplayName1.LocalizationKey = InfiltratorStealthDisplayName1LocKey;
            stealthInfiltrator.ViewElementDef.Description.LocalizationKey = InfiltratorStealthDescriptionLocKey;

            FactionVisibilityConditionStatusDef visibilityConditionStatus = Helper.CreateDefFromClone(
                baseForAll.StatusDef as FactionVisibilityConditionStatusDef,
                "3bae4197-6f49-4ee2-984b-9779321aa9a5",
                skillName + "VisibiltyConditionStatusDef");
            stealthInfiltrator.StatusDef = visibilityConditionStatus;

            // Create new StatModifications array for stealth bonus
            ItemStatModification[] statModifications = new ItemStatModification[] {new ItemStatModification()
            {
                TargetStat = StatModificationTarget.Stealth,
                Modification = StatModificationType.Add,
                Value = 0.25f
            }};

            StanceStatusDef hiddenStatus = Helper.CreateDefFromClone(
                visibilityConditionStatus.HiddenStateStatusDef as StanceStatusDef,
                "a51977b0-be83-4249-8bef-30fe04fff4b3",
                skillName + "HiddenStatusDef");
            hiddenStatus.StatModifications = statModifications;
            hiddenStatus.Visuals = Helper.CreateDefFromClone(
                stealthInfiltrator.ViewElementDef,
                "31859328-2bf7-4ee5-b59a-2600da67a1e8",
                $"E_View [{hiddenStatus.name}]");
            hiddenStatus.Visuals.Color = Color.green;
            hiddenStatus.Visuals.Description.LocalizationKey = "PR_BC_INFILTRATOR_HIDDEN";
            visibilityConditionStatus.HiddenStateStatusDef = hiddenStatus;

            StanceStatusDef locatedStatus = Helper.CreateDefFromClone(
                visibilityConditionStatus.LocatedStateStatusDef as StanceStatusDef,
                "4d827076-1447-4d81-b398-9f42a29fb645",
                skillName + "LocatedStateStatusDef");
            locatedStatus.StatModifications = statModifications;
            locatedStatus.Visuals = Helper.CreateDefFromClone(
                stealthInfiltrator.ViewElementDef,
                "4dfe23e9-e1d8-4233-bf56-fdaae41b5c54",
                $"E_View [{locatedStatus.name}]");
            locatedStatus.Visuals.Color = Color.yellow;
            locatedStatus.Visuals.Description.LocalizationKey = "PR_BC_INFILTRATOR_LOCATED";
            visibilityConditionStatus.LocatedStateStatusDef = locatedStatus;

            StanceStatusDef revealedStatus = Helper.CreateDefFromClone(
                visibilityConditionStatus.RevealedStateStatusDef as StanceStatusDef,
                "ed5e20f8-5324-49fe-b202-aa927df3e3f4",
                skillName + "RevealedStateStatusDef");
            revealedStatus.Visuals = Helper.CreateDefFromClone(
                stealthInfiltrator.ViewElementDef,
                "42f16776-e30e-4435-90a6-3977df8ba154",
                $"E_View [{revealedStatus.name}]");
            revealedStatus.Visuals.Color = Color.red;
            revealedStatus.Visuals.Description.LocalizationKey = "PR_BC_INFILTRATOR_REVEALED";
            visibilityConditionStatus.RevealedStateStatusDef = revealedStatus;

            //Delete stealth bonus from base skill
            ((baseForAll.StatusDef as FactionVisibilityConditionStatusDef).HiddenStateStatusDef as StanceStatusDef).StatModifications = new ItemStatModification[0];
            // New Icon and texts for base skill
            Sprite icon = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_SneakerLegs_Stealth-2.png");
            baseForAll.ViewElementDef.LargeIcon = icon;
            baseForAll.ViewElementDef.SmallIcon = icon;
            baseForAll.ViewElementDef.DisplayName1.LocalizationKey = "PR_BC_HIDDEN";
            baseForAll.ViewElementDef.Description.LocalizationKey = "PR_BC_HIDDEN_DESC";

            // Add stealth indicator ability to Soldier_ActorDef.Abilities if it does not already contains it (set it for all characters)
            TacticalActorDef soldierActorDef = DefCache.GetDef<TacticalActorDef>("Soldier_ActorDef");
            if (!soldierActorDef.Abilities.Contains(baseForAll))
            {
                soldierActorDef.Abilities = soldierActorDef.Abilities.Append(baseForAll).ToArray();
            }

            // Replace base stealth inidcator ability on Infiltrator_ClassProficiency_AbilityDef with new ctreated stealth buff ability
            ClassProficiencyAbilityDef infiltratorCPAD = DefCache.GetDef<ClassProficiencyAbilityDef>("Infiltrator_ClassProficiency_AbilityDef");
            if (!infiltratorCPAD.AbilityDefs.Contains(stealthInfiltrator))
            {
                List<AbilityDef> abilityDefs = infiltratorCPAD.AbilityDefs.ToList();
                _ = abilityDefs.Remove(baseForAll);
                abilityDefs.Add(stealthInfiltrator);
                infiltratorCPAD.AbilityDefs = abilityDefs.ToArray();
            }
        }

        private static void Set_SPcost()
        {
            PRMLogger.Debug("----------------------------------------------------------------------------------------------------", false);
            PRMLogger.Debug("Set SP cost for all abilities.");
            PRMLogger.Debug("----------------------------------------------------------------------------------------------------", false);

            BCSettings Config = TFTVMain.Main.Settings;
            DefCache DefCache = TFTVMain.Main.DefCache;
            string abilityName;
            // Main spec
            foreach (ClassSpecDef classSpec in Config.ClassSpecializations)
            {
                for (int i = 0; i < classSpec.MainSpec.Length; i++)
                {
                    if (i != 0 && i != 3 && Helper.AbilityNameToDefMap.ContainsKey(classSpec.MainSpec[i]))
                    {
                        abilityName = Helper.AbilityNameToDefMap[classSpec.MainSpec[i]];
                        TacticalAbilityDef tacticalAbility = DefCache.GetDef<TacticalAbilityDef>(abilityName);
                        if (tacticalAbility != null && tacticalAbility.CharacterProgressionData != null)
                        {
                            tacticalAbility.CharacterProgressionData.SkillPointCost = Helper.SPperLevel[i];
                            PRMLogger.Debug($"Set ability {tacticalAbility.name} to {Helper.SPperLevel[i]} SP cost.");
                        }
                    }
                }
            }
            foreach (PersonalPerksDef ppd in Config.PersonalPerks)
            {
                switch (ppd.PerkKey)
                {
                    case PerkType.Background:
                    case PerkType.Proficiency:
                        if (ppd.UnrelatedRandomPerks != null)
                        {
                            foreach (string skillName in ppd.UnrelatedRandomPerks)
                            {
                                if (!Helper.AbilityNameToDefMap.ContainsKey(skillName)) continue;
                                abilityName = Helper.AbilityNameToDefMap[skillName];
                                TacticalAbilityDef tacticalAbility = DefCache.GetDef<TacticalAbilityDef>(abilityName);
                                if (tacticalAbility != null && tacticalAbility.CharacterProgressionData != null)
                                {
                                    tacticalAbility.CharacterProgressionData.SkillPointCost = ppd.SPcost;
                                    PRMLogger.Debug($"Set ability {tacticalAbility.name} to {ppd.SPcost} SP cost.");
                                }
                            }
                        }
                        break;
                    case PerkType.Class_1:
                    case PerkType.Class_2:
                    case PerkType.Faction_1:
                    case PerkType.Faction_2:
                        // Handle fixed mappings if present
                        if (ppd.RelatedFixedPerks != null)
                        {
                            foreach (KeyValuePair<string, Dictionary<string, string>> outerRelation in ppd.RelatedFixedPerks)
                            {
                                foreach (KeyValuePair<string, string> innerRelation in outerRelation.Value)
                                {
                                    if (!Helper.AbilityNameToDefMap.ContainsKey(innerRelation.Value)) continue;
                                    abilityName = Helper.AbilityNameToDefMap[innerRelation.Value];
                                    TacticalAbilityDef tacticalAbility = DefCache.GetDef<TacticalAbilityDef>(abilityName);
                                    if (tacticalAbility != null && tacticalAbility.CharacterProgressionData != null)
                                    {
                                        tacticalAbility.CharacterProgressionData.SkillPointCost = ppd.SPcost;
                                        PRMLogger.Debug($"Set ability {tacticalAbility.name} to {ppd.SPcost} SP cost.");
                                    }
                                }
                            }
                        }
                        // Handle RNG pools in PerkDictionary (class/faction aware)
                        else if (ppd.PerkDictionary != null)
                        {
                            HashSet<string> uniqueNames = new HashSet<string>();
                            foreach (KeyValuePair<string, Dictionary<string, List<string>>> outer in ppd.PerkDictionary)
                            {
                                foreach (KeyValuePair<string, List<string>> inner in outer.Value)
                                {
                                    foreach (string dispName in inner.Value)
                                    {
                                        if (string.IsNullOrEmpty(dispName)) continue;
                                        if (!Helper.AbilityNameToDefMap.ContainsKey(dispName)) continue;
                                        if (!uniqueNames.Add(dispName)) continue;
                                        abilityName = Helper.AbilityNameToDefMap[dispName];
                                        TacticalAbilityDef tacticalAbility = DefCache.GetDef<TacticalAbilityDef>(abilityName);
                                        if (tacticalAbility != null && tacticalAbility.CharacterProgressionData != null)
                                        {
                                            tacticalAbility.CharacterProgressionData.SkillPointCost = ppd.SPcost;
                                            PRMLogger.Debug($"Set ability {tacticalAbility.name} to {ppd.SPcost} SP cost.");
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            PRMLogger.Debug("----------------------------------------------------", false);
        }

        private static void Change_ProficiencyPerks()
        {
            BCSettings Config = TFTVMain.Main.Settings;
            DefRepository Repo = TFTVMain.Repo;
            DefCache DefCache = TFTVMain.Main.DefCache;
            foreach (PassiveModifierAbilityDef pmad in Repo.GetAllDefs<PassiveModifierAbilityDef>().Where(p => p.CharacterProgressionData != null && p.name.Contains("Talent")))
            {
                // Assault rifle proficiency fix, was set to shotguns
                if (pmad.name.Contains("Assault"))
                {
                    GameTagDef ARtagDef = DefCache.GetDef<GameTagDef>("AssaultRifleItem_TagDef");
                    pmad.ItemTagStatModifications[0].ItemTag = ARtagDef;
                }

                // Change description text, not localized (currently), old one mentions fixed buffs that are taken away or set differently by this mod
              //  string newText = Helper.NotLocalizedTextMap[pmad.ViewElementDef.name][ViewElement.Description];
             //   pmad.ViewElementDef.Description = new LocalizedTextBind(newText, Config.DoNotLocalizeChangedTexts);

                PRMLogger.Debug("Proficiency def name: " + pmad.name);
                PRMLogger.Debug("Viewelement name:     " + pmad.ViewElementDef.name);
                PRMLogger.Debug("Display1 name:        " + pmad.ViewElementDef.DisplayName1.Localize());
                PRMLogger.Debug("Description:          " + pmad.ViewElementDef.Description.Localize());

                // Get modification from config, but first -0.1 to normalise to 0.0 (proficiency perks are all set to +0.1 buff)
                float newStatModification = -0.1f + Config.BuffsForAdditionalProficiency[Proficiency.Buff];
                // Loop through all subsequent item stat modifications
                if (pmad.ItemTagStatModifications.Length > 0)
                {
                    for (int i = 0; i < pmad.ItemTagStatModifications.Length; i++)
                    {
                        if (pmad.ItemTagStatModifications[i].EquipmentStatModification.Value != (0 + Config.BuffsForAdditionalProficiency[Proficiency.Buff])
                            && pmad.ItemTagStatModifications[i].EquipmentStatModification.Value != (1 + Config.BuffsForAdditionalProficiency[Proficiency.Buff]))
                        {
                            pmad.ItemTagStatModifications[i].EquipmentStatModification.Value += newStatModification;
                        }

                        PRMLogger.Debug("  Target item: " + pmad.ItemTagStatModifications[i].ItemTag.name);
                        PRMLogger.Debug("  Target stat: " + pmad.ItemTagStatModifications[i].EquipmentStatModification.TargetStat);
                        PRMLogger.Debug(" Modification: " + pmad.ItemTagStatModifications[i].EquipmentStatModification.Modification);
                        PRMLogger.Debug("        Value: " + pmad.ItemTagStatModifications[i].EquipmentStatModification.Value);
                    }
                }
                PRMLogger.Debug("----------------------------------------------------", false);
            }
        }

        // New Battle Focus ability
        public static void Create_BattleFocus()
        {
            float damageMod = 1.2f;
            float range = 10.0f;
            string skillName = "BattleFocus_AbilityDef";
            DefCache DefCache = TFTVMain.Main.DefCache;

            // Source to clone from
            ApplyStatusAbilityDef masterMarksman = DefCache.GetDef<ApplyStatusAbilityDef>("MasterMarksman_AbilityDef");

            // Create Neccessary RuntimeDefs
            ApplyStatusAbilityDef battleFocusAbility = Helper.CreateDefFromClone(
                masterMarksman,
                "64fc75aa-93be-4d79-b5ac-191c5c7820da",
                skillName);
            AbilityCharacterProgressionDef progression = Helper.CreateDefFromClone(
                masterMarksman.CharacterProgressionData,
                "7ffae720-a656-454e-a95b-b861a673718a",
                skillName);
            TacticalTargetingDataDef targetingData = Helper.CreateDefFromClone(
                masterMarksman.TargetingDataDef,
                "fed0600a-14b3-4ef5-ac0c-31b3bf6f1e6c",
                skillName);
            TacticalAbilityViewElementDef viewElement = Helper.CreateDefFromClone(
                masterMarksman.ViewElementDef,
                "b498b9de-f10b-464c-a9f9-29a293568b04",
                skillName);
            StanceStatusDef stanceStatus = Helper.CreateDefFromClone( // Borrow status from Sneak Attack, Master Marksman status does not fit
                DefCache.GetDef<StanceStatusDef>("E_SneakAttackStatus [SneakAttack_AbilityDef]"),
                "05929419-7d20-47aa-b700-fa6bc6602716",
                "E_Status [" + skillName + "]");
            VisibleActorsInRangeEffectConditionDef visibleActorsInRangeEffectCondition = Helper.CreateDefFromClone(
                (VisibleActorsInRangeEffectConditionDef)masterMarksman.TargetApplicationConditions[0],
                "63a34054-28de-488e-ae4a-af451434f0d4",
                skillName);

            // Set fields
            battleFocusAbility.CharacterProgressionData = progression;
            battleFocusAbility.TargetingDataDef = targetingData;
            battleFocusAbility.ViewElementDef = viewElement;
            battleFocusAbility.StatusDef = stanceStatus;
            battleFocusAbility.TargetApplicationConditions = new EffectConditionDef[] { visibleActorsInRangeEffectCondition };
            progression.RequiredStrength = 0;
            progression.RequiredWill = 0;
            progression.RequiredSpeed = 0;
            targetingData.Origin.Range = range;
            viewElement.DisplayName1.LocalizationKey = "PR_BC_BATTLE_FOCUS";
            viewElement.Description.LocalizationKey = "PR_BC_BATTLE_FOCUS_DESC";
            viewElement.ShowInInventoryItemTooltip = true;
            Sprite icon = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_PersonalTrack_TacticalAnalyst.png");
            viewElement.LargeIcon = icon;
            viewElement.SmallIcon = icon;
            stanceStatus.EffectName = skillName;
            stanceStatus.ShowNotification = true;
            stanceStatus.Visuals = battleFocusAbility.ViewElementDef;
            stanceStatus.StatModifications[0].Value = damageMod;
            visibleActorsInRangeEffectCondition.TargetingData = battleFocusAbility.TargetingDataDef;
            visibleActorsInRangeEffectCondition.ActorsInRange = true;
        }

        // New Entrench ability: self-buff armor + accuracy for 1 turn
        public static void Create_Entrench()
        {
            try
            {
                string skillName = "Entrench_AbilityDef";
                DefCache DefCache = TFTVMain.Main.DefCache;

                // Base sources
                ApplyStatusAbilityDef source = DefCache.GetDef<ApplyStatusAbilityDef>("CloseQuarters_AbilityDef");
                ApplyStatusAbilityDef quickAim = DefCache.GetDef<ApplyStatusAbilityDef>("QuickAim_AbilityDef");

                // Ability shell
                ApplyStatusAbilityDef entrench = Helper.CreateDefFromClone(
                    source,
                    "8f7d6ad1-3e9e-4e4e-98a8-1c0e4f67b901",
                    skillName);
                entrench.CharacterProgressionData = Helper.CreateDefFromClone(
                    source.CharacterProgressionData,
                    "6a1c4b2e-8bfe-4dbe-8b99-2b1fa51f2722",
                    skillName);
                entrench.TargetingDataDef = quickAim.TargetingDataDef; // self
                entrench.ViewElementDef = Helper.CreateDefFromClone(
                    source.ViewElementDef,
                    "a3fb0d3e-5bdf-4d61-9a0e-8a5d61ed0a6a",
                    skillName);

                // Armor buff (+10) using ItemSlotStatsModifyStatusDef from Electric Reinforcement
                ItemSlotStatsModifyStatusDef armorBuff = Helper.CreateDefFromClone(
                    DefCache.GetDef<ItemSlotStatsModifyStatusDef>("E_Status [ElectricReinforcement_AbilityDef]"),
                    "7bf7b0c1-2c89-4f99-a6a9-6b6b5c5e6d31",
                    "E_ArmourModifier [Entrench_AbilityDef]");
                armorBuff.Visuals = Helper.CreateDefFromClone(
                    entrench.ViewElementDef,
                    "31b16147-2f6d-4a87-b2c7-8ad78d44c7d8",
                    "E_Visuals_ArmourModifier [Entrench_AbilityDef]");
                armorBuff.Visuals.DisplayName1.LocalizationKey = "PR_BC_ENTRENCH_ARMOR_STATUS";
                armorBuff.Visuals.Description.LocalizationKey = "PR_BC_ENTRENCH_ARMOR_STATUS_DESC";
                armorBuff.StatsModifications = new ItemSlotStatsModifyStatusDef.ItemSlotModification[]
                {
                    new ItemSlotStatsModifyStatusDef.ItemSlotModification
                    {
                        Type = ItemSlotStatsModifyStatusDef.StatType.Armour,
                        ModificationType = StatModificationType.AddMax,
                        Value = 10f,
                        ShowsNotification = false,
                        NotifyOnce = false
                    },
                    new ItemSlotStatsModifyStatusDef.ItemSlotModification
                    {
                        Type = ItemSlotStatsModifyStatusDef.StatType.Armour,
                        ModificationType = StatModificationType.AddRestrictedToBounds,
                        Value = 10f,
                        ShowsNotification = true,
                        NotifyOnce = true
                    }
                };

                // Accuracy boost (+15%) using StatMultiplierStatusDef (clone of Trembling)
                StatMultiplierStatusDef accBoost = Helper.CreateDefFromClone(
                    DefCache.GetDef<StatMultiplierStatusDef>("Trembling_StatusDef"),
                    "e61a57a9-ec78-4c7b-9c23-cc57b1b3b86b",
                    "E_AccuracyModifier [Entrench_AbilityDef]");
                accBoost.EffectName = "";
                accBoost.ShowNotification = false;
                accBoost.VisibleOnHealthbar = 0;
                accBoost.VisibleOnStatusScreen = 0;
                accBoost.Visuals = null;
                if (accBoost.StatsMultipliers != null && accBoost.StatsMultipliers.Length > 0)
                {
                    accBoost.StatsMultipliers[0].StatName = "Accuracy";
                    accBoost.StatsMultipliers[0].Multiplier = 1.15f;
                }

                // Container status to apply both armor and accuracy
                AddAttackBoostStatusDef addBoost = Helper.CreateDefFromClone(
                    DefCache.GetDef<AddAttackBoostStatusDef>("E_Status [QuickAim_AbilityDef]"),
                    "5d9d6e0a-5d1e-4c2e-8b66-93d90e5b2a4f",
                    "E_AddAttackBoostStatus [Entrench_AbilityDef]");
                addBoost.DurationTurns = 1;
                addBoost.ExpireOnEndOfTurn = true;
                addBoost.ShowNotification = true;
                addBoost.Visuals = Helper.CreateDefFromClone(
                    entrench.ViewElementDef,
                    "b7125b19-1e8b-4c44-8b40-5b7e3f9d0b98",
                    "E_Visuals_AddAttackBoostStatus [Entrench_AbilityDef]");
                addBoost.Visuals.DisplayName1.LocalizationKey = "PR_BC_ENTRENCH_STATUS";
                addBoost.Visuals.Description.LocalizationKey = "PR_BC_ENTRENCH_STATUS_DESC";
                addBoost.AdditionalStatusesToApply = new TacStatusDef[] { armorBuff, accBoost };

                entrench.StatusDef = addBoost;
                entrench.Active = true;
                entrench.EndsTurn = false;
                entrench.ActionPointCost = 0.5f;
                entrench.WillPointCost = 2.0f;
                entrench.DisablingStatuses = new StatusDef[0];
                entrench.TraitsRequired = new string[] { "start", "ability", "move" };
                entrench.TraitsToApply = new string[] { "ability" };
                entrench.ShowNotificationOnUse = true;
                entrench.StatusApplicationTrigger = StatusApplicationTrigger.ActivateAbility;
                entrench.CharacterProgressionData.RequiredStrength = 0;
                entrench.CharacterProgressionData.RequiredWill = 0;
                entrench.CharacterProgressionData.RequiredSpeed = 0;
                entrench.ViewElementDef.DisplayName1.LocalizationKey = "PR_BC_ENTRENCH";
                entrench.ViewElementDef.Description.LocalizationKey = "PR_BC_ENTRENCH_DESC";
                Sprite icon = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_HunkerDown_1-2.png");
                entrench.ViewElementDef.LargeIcon = icon;
                entrench.ViewElementDef.SmallIcon = icon;
            }
            catch (System.Exception e)
            {
                PRMLogger.Error(e);
            }
        }

        // New Suppression ability: single-target enemy accuracy debuff for 1 turn
        public static void Create_Suppression()
        {
            try
            {
                string skillName = "Suppression_AbilityDef";
                DefCache DefCache = TFTVMain.Main.DefCache;

                ApplyStatusAbilityDef source = DefCache.GetDef<ApplyStatusAbilityDef>("InducePanic_AbilityDef");

                ApplyStatusAbilityDef suppression = Helper.CreateDefFromClone(
                    source,
                    "4d7f0f6a-16d2-4c8a-9f8a-0fca7aa7c6f0",
                    skillName);
                suppression.CharacterProgressionData = Helper.CreateDefFromClone(
                    source.CharacterProgressionData,
                    "e3063a14-0b7f-4c0e-8d82-4a8d3ee6f5a1",
                    skillName);
                suppression.TargetingDataDef = Helper.CreateDefFromClone(
                    source.TargetingDataDef,
                    "1b1f6c6c-5c7b-4f5d-8c1f-bf1b3cf8f0a1",
                    skillName);
                suppression.ViewElementDef = Helper.CreateDefFromClone(
                    source.ViewElementDef,
                    "a0a2a7a9-6a84-4d37-8c39-1872f41c4d5f",
                    skillName);

                // Debuff: Accuracy x0.75 for 1 turn
                StatMultiplierStatusDef accDebuff = Helper.CreateDefFromClone(
                    DefCache.GetDef<StatMultiplierStatusDef>("Trembling_StatusDef"),
                    "3ac8a5a1-6cc5-4a0b-b3b8-0e6a27f3f4a7",
                    "E_AccuracyDebuff [Suppression_AbilityDef]");
                accDebuff.EffectName = "";
                accDebuff.ShowNotification = true;
                accDebuff.VisibleOnHealthbar = 1;
                accDebuff.VisibleOnStatusScreen = 1;
                accDebuff.Visuals = Helper.CreateDefFromClone(
                    suppression.ViewElementDef,
                    "bc8b3cbd-1f69-4d3f-8f2b-9a4a12a1f6a2",
                    "E_View [E_AccuracyDebuff [Suppression_AbilityDef]]");
                accDebuff.Visuals.DisplayName1.LocalizationKey = "PR_BC_SUPPRESSION_STATUS";
                accDebuff.Visuals.Description.LocalizationKey = "PR_BC_SUPPRESSION_STATUS_DESC";
                if (accDebuff.StatsMultipliers != null && accDebuff.StatsMultipliers.Length > 0)
                {
                    accDebuff.StatsMultipliers[0].StatName = "Accuracy";
                    accDebuff.StatsMultipliers[0].Multiplier = 0.75f;
                }
                // Container to control duration/expiry
                AddAttackBoostStatusDef supContainer = Helper.CreateDefFromClone(
                    DefCache.GetDef<AddAttackBoostStatusDef>("E_Status [QuickAim_AbilityDef]"),
                    "b7e47d13-13b2-4c5a-9f96-0f2d4d6c6928",
                    "E_AddAttackBoostStatus [Suppression_AbilityDef]");
                supContainer.DurationTurns = 1;
                supContainer.ExpireOnEndOfTurn = true;
                supContainer.ShowNotification = true;
                supContainer.Visuals = Helper.CreateDefFromClone(
                    suppression.ViewElementDef,
                    "a4a2a7b1-8b64-4b21-8ebb-8b75ab1b3e2f",
                    "E_Visuals_AddAttackBoostStatus [Suppression_AbilityDef]");
                supContainer.Visuals.DisplayName1.LocalizationKey = "PR_BC_SUPPRESSION";
                supContainer.Visuals.Description.LocalizationKey = "PR_BC_SUPPRESSION_DESC";
                supContainer.AdditionalStatusesToApply = new TacStatusDef[] { accDebuff };

                suppression.StatusDef = supContainer;
                suppression.WillPointCost = 2.0f;
                suppression.ActionPointCost = 0.5f;
                suppression.ViewElementDef.DisplayName1.LocalizationKey = "PR_BC_SUPPRESSION";
                suppression.ViewElementDef.Description.LocalizationKey = "PR_BC_SUPPRESSION_DESC";
                Sprite icon2 = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_PersonalTrack_TacticalAnalyst.png");
                suppression.ViewElementDef.LargeIcon = icon2;
                suppression.ViewElementDef.SmallIcon = icon2;

                // Slightly extend range compared to base panic
                suppression.TargetingDataDef.Origin.Range = 12f;
            }
            catch (System.Exception e)
            {
                PRMLogger.Error(e);
            }
        }

        // New Veil of Shadows: AoE ally stealth boost (stealth stat) for 1 turn
        public static void Create_VeilOfShadows()
        {
            try
            {
                string skillName = "VeilOfShadows_AbilityDef";
                DefCache DefCache = TFTVMain.Main.DefCache;

                // Shell from MasterMarksman to avoid hidden special logic
                ApplyStatusAbilityDef master = DefCache.GetDef<ApplyStatusAbilityDef>("MasterMarksman_AbilityDef");
                ApplyStatusAbilityDef frenzy = DefCache.GetDef<ApplyStatusAbilityDef>("Priest_InstilFrenzy_AbilityDef");

                ApplyStatusAbilityDef veil = Helper.CreateDefFromClone(
                    master,
                    "8b2a8e7a-6d61-4e34-a3cf-16d64b8b8301",
                    skillName);
                veil.CharacterProgressionData = Helper.CreateDefFromClone(
                    master.CharacterProgressionData,
                    "5bfb805e-9e23-4f90-8d58-0e0e9f3a4f50",
                    skillName);
                veil.TargetingDataDef = Helper.CreateDefFromClone(
                    frenzy.TargetingDataDef,
                    "e0ce2d5e-8e2f-4c58-8f0e-2a7d5a7142a6",
                    skillName);
                veil.ViewElementDef = Helper.CreateDefFromClone(
                    master.ViewElementDef,
                    "2d9c6859-15a3-4fa9-9f3a-02e0ab13d2c1",
                    skillName);

                StanceStatusDef stealthBoost = Helper.CreateDefFromClone(
                    DefCache.GetDef<StanceStatusDef>("E_SneakAttackStatus [SneakAttack_AbilityDef]"),
                    "5a354a7e-0b7f-4c8f-b017-b8a8bbef5d8b",
                    "E_StealthBoost [VeilOfShadows_AbilityDef]");
                stealthBoost.Visuals = Helper.CreateDefFromClone(
                    veil.ViewElementDef,
                    "b5a6dc21-2c4b-4d1b-9120-0a1a1c3f1962",
                    "E_View [E_StealthBoost [VeilOfShadows_AbilityDef]]");
                stealthBoost.Visuals.DisplayName1.LocalizationKey = "PR_BC_VEIL_OF_SHADOWS_STATUS";
                stealthBoost.Visuals.Description.LocalizationKey = "PR_BC_VEIL_OF_SHADOWS_STATUS_DESC";
                stealthBoost.DurationTurns = 1;
                stealthBoost.SingleInstance = true;
                stealthBoost.StatModifications = new ItemStatModification[]
                {
                    new ItemStatModification
                    {
                        TargetStat = StatModificationTarget.Stealth,
                        Modification = StatModificationType.Add,
                        Value = 0.4f
                    }
                };

                veil.StatusDef = stealthBoost;
                veil.ViewElementDef.DisplayName1.LocalizationKey = "PR_BC_VEIL_OF_SHADOWS";
                veil.ViewElementDef.Description.LocalizationKey = "PR_BC_VEIL_OF_SHADOWS_DESC";
                Sprite icon3 = Helper.CreateSpriteFromImageFile("UI_AbilitiesIcon_SneakerLegs_Stealth-2.png");
                veil.ViewElementDef.LargeIcon = icon3;
                veil.ViewElementDef.SmallIcon = icon3;
                veil.ActionPointCost = 0.5f;
                veil.WillPointCost = 3.0f;
                // Range similar to frenzy
                veil.TargetingDataDef.Origin.Range = frenzy.TargetingDataDef.Origin.Range;
            }
            catch (System.Exception e)
            {
                PRMLogger.Error(e);
            }
        }

    }
}
