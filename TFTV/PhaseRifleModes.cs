using HarmonyLib;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.DamageKeywords;
using PhoenixPoint.Tactical.Entities.Weapons;
using PhoenixPoint.Tactical.Entities.Statuses;
using PhoenixPoint.Tactical.Levels;
using Base.Defs;
using Base.UI;
using Base.Entities.Abilities;
using Base.Entities.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TFTV
{
    public enum PhaseMode
    {
        Kinetic,    // High damage, destroys cover, pushes enemies
        Energy,     // Ignores armor, disables electronics
        Sonic,      // Area effect, causes disorientation  
        Thermal,    // Heat-seeking, extra damage to organics
        EMP         // Disables mechanical enemies, damages robots
    }

    public class PhaseRifleModes
    {
        private static readonly DefRepository Repo = TFTVMain.Repo;
        private static readonly DefCache DefCache = TFTVMain.Main.DefCache;
        private static readonly SharedData Shared = TFTVMain.Shared;

        // Status effects for each phase mode
        public static StatusDef kineticModeStatus;
        public static StatusDef energyModeStatus;
        public static StatusDef sonicModeStatus;
        public static StatusDef thermalModeStatus;
        public static StatusDef empModeStatus;

        // Abilities for switching modes
        public static ApplyStatusAbilityDef switchToKineticAbility;
        public static ApplyStatusAbilityDef switchToEnergyAbility;
        public static ApplyStatusAbilityDef switchToSonicAbility;
        public static ApplyStatusAbilityDef switchToThermalAbility;
        public static ApplyStatusAbilityDef switchToEmpAbility;

        public static void Initialize()
        {
            CreatePhaseStatusEffects();
            CreatePhaseSwitchAbilities();
            IntegrateWithPhaseRifle();
            TFTVLogger.Always("Phase Rifle mode system initialized successfully");
        }

        private static void CreatePhaseStatusEffects()
        {
            try
            {
                // Create status effects for each phase mode
                CreateKineticModeStatus();
                CreateEnergyModeStatus();
                CreateSonicModeStatus();
                CreateThermalModeStatus();
                CreateEmpModeStatus();
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        private static void CreateKineticModeStatus()
        {
            // Kinetic Mode: High damage, destroys cover, pushes enemies
            StanceStatusDef sourceStatus = DefCache.GetDef<StanceStatusDef>("E_SneakAttackStatus [SneakAttack_AbilityDef]");
            
            kineticModeStatus = Helper.CreateDefFromClone(
                sourceStatus,
                "{F1A2B3C4-D5E6-7890-1234-KINETICMODE}",
                "TFTV_PhaseRifle_KineticMode_StatusDef");
        }

        private static void CreateEnergyModeStatus()
        {
            // Energy Mode: Ignores armor, disables electronics
            StanceStatusDef sourceStatus = DefCache.GetDef<StanceStatusDef>("E_SneakAttackStatus [SneakAttack_AbilityDef]");
            
            energyModeStatus = Helper.CreateDefFromClone(
                sourceStatus,
                "{F2A3B4C5-D6E7-8901-2345-ENERGYMODE}",
                "TFTV_PhaseRifle_EnergyMode_StatusDef");
        }

        private static void CreateSonicModeStatus()
        {
            // Sonic Mode: Area effect, causes disorientation
            StanceStatusDef sourceStatus = DefCache.GetDef<StanceStatusDef>("E_SneakAttackStatus [SneakAttack_AbilityDef]");
            
            sonicModeStatus = Helper.CreateDefFromClone(
                sourceStatus,
                "{F3A4B5C6-D7E8-9012-3456-SONICMODE}",
                "TFTV_PhaseRifle_SonicMode_StatusDef");
        }

        private static void CreateThermalModeStatus()
        {
            // Thermal Mode: Heat-seeking, extra damage to organics
            StanceStatusDef sourceStatus = DefCache.GetDef<StanceStatusDef>("E_SneakAttackStatus [SneakAttack_AbilityDef]");
            
            thermalModeStatus = Helper.CreateDefFromClone(
                sourceStatus,
                "{F4A5B6C7-D8E9-0123-4567-THERMALMODE}",
                "TFTV_PhaseRifle_ThermalMode_StatusDef");
        }

        private static void CreateEmpModeStatus()
        {
            // EMP Mode: Disables mechanical enemies, damages robots
            StanceStatusDef sourceStatus = DefCache.GetDef<StanceStatusDef>("E_SneakAttackStatus [SneakAttack_AbilityDef]");
            
            empModeStatus = Helper.CreateDefFromClone(
                sourceStatus,
                "{F5A6B7C8-D9E0-1234-5678-EMPMODE}",
                "TFTV_PhaseRifle_EmpMode_StatusDef");
        }

        private static void CreatePhaseSwitchAbilities()
        {
            try
            {
                ApplyStatusAbilityDef sourceAbility = DefCache.GetDef<ApplyStatusAbilityDef>("QuickAim_AbilityDef");

                // Create abilities to switch to each mode
                CreateSwitchAbility(sourceAbility, PhaseMode.Kinetic);
                CreateSwitchAbility(sourceAbility, PhaseMode.Energy);
                CreateSwitchAbility(sourceAbility, PhaseMode.Sonic);
                CreateSwitchAbility(sourceAbility, PhaseMode.Thermal);
                CreateSwitchAbility(sourceAbility, PhaseMode.EMP);
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        private static void CreateSwitchAbility(ApplyStatusAbilityDef sourceAbility, PhaseMode mode)
        {
            string modeName = mode.ToString().ToUpper();
            string abilityGuid = GetAbilityGuid(mode);
            string viewGuid = GetViewGuid(mode);
            
            ApplyStatusAbilityDef switchAbility = Helper.CreateDefFromClone(
                sourceAbility,
                abilityGuid,
                string.Format("TFTV_PhaseRifle_SwitchTo{0}_AbilityDef", mode));

            switchAbility.ViewElementDef = Helper.CreateDefFromClone(
                sourceAbility.ViewElementDef,
                viewGuid,
                string.Format("TFTV_PhaseRifle_SwitchTo{0}_ViewDef", mode));

            switchAbility.ViewElementDef.DisplayName1 = new LocalizedTextBind(string.Format("SWITCH TO {0}", modeName), TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
            switchAbility.ViewElementDef.Description = new LocalizedTextBind(string.Format("Switch Phase Rifle to {0} mode.", modeName), TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
            
            switchAbility.ActionPointCost = 0.25f; // 1 action point to switch
            switchAbility.StatusDef = GetStatusForMode(mode);

            // Store the ability reference
            StoreAbilityReference(mode, switchAbility);
        }

        private static string GetAbilityGuid(PhaseMode mode)
        {
            switch (mode)
            {
                case PhaseMode.Kinetic: return "{G1A2B3C4-D5E6-7890-1234-SWITCHKINETIC}";
                case PhaseMode.Energy: return "{G2A3B4C5-D6E7-8901-2345-SWITCHENERGY}";
                case PhaseMode.Sonic: return "{G3A4B5C6-D7E8-9012-3456-SWITCHSONIC}";
                case PhaseMode.Thermal: return "{G4A5B6C7-D8E9-0123-4567-SWITCHTHERMAL}";
                case PhaseMode.EMP: return "{G5A6B7C8-D9E0-1234-5678-SWITCHEMP}";
                default: return "{G0A0B0C0-D0E0-0000-0000-SWITCHDEFAULT}";
            }
        }

        private static string GetViewGuid(PhaseMode mode)
        {
            switch (mode)
            {
                case PhaseMode.Kinetic: return "{V1A2B3C4-D5E6-7890-1234-VIEWKINETIC}";
                case PhaseMode.Energy: return "{V2A3B4C5-D6E7-8901-2345-VIEWENERGY}";
                case PhaseMode.Sonic: return "{V3A4B5C6-D7E8-9012-3456-VIEWSONIC}";
                case PhaseMode.Thermal: return "{V4A5B6C7-D8E9-0123-4567-VIEWTHERMAL}";
                case PhaseMode.EMP: return "{V5A6B7C8-D9E0-1234-5678-VIEWEMP}";
                default: return "{V0A0B0C0-D0E0-0000-0000-VIEWDEFAULT}";
            }
        }

        private static StatusDef GetStatusForMode(PhaseMode mode)
        {
            switch (mode)
            {
                case PhaseMode.Kinetic: return kineticModeStatus;
                case PhaseMode.Energy: return energyModeStatus;
                case PhaseMode.Sonic: return sonicModeStatus;
                case PhaseMode.Thermal: return thermalModeStatus;
                case PhaseMode.EMP: return empModeStatus;
                default: return kineticModeStatus;
            }
        }

        private static void StoreAbilityReference(PhaseMode mode, ApplyStatusAbilityDef ability)
        {
            switch (mode)
            {
                case PhaseMode.Kinetic: switchToKineticAbility = ability; break;
                case PhaseMode.Energy: switchToEnergyAbility = ability; break;
                case PhaseMode.Sonic: switchToSonicAbility = ability; break;
                case PhaseMode.Thermal: switchToThermalAbility = ability; break;
                case PhaseMode.EMP: switchToEmpAbility = ability; break;
            }
        }

        // Get current phase mode from actor status
        public static PhaseMode GetCurrentPhaseMode(TacticalActor actor)
        {
            if (actor.Status == null) return PhaseMode.Kinetic;

            if (actor.Status.HasStatus(kineticModeStatus)) return PhaseMode.Kinetic;
            if (actor.Status.HasStatus(energyModeStatus)) return PhaseMode.Energy;
            if (actor.Status.HasStatus(sonicModeStatus)) return PhaseMode.Sonic;
            if (actor.Status.HasStatus(thermalModeStatus)) return PhaseMode.Thermal;
            if (actor.Status.HasStatus(empModeStatus)) return PhaseMode.EMP;

            return PhaseMode.Kinetic; // Default
        }

        // Apply phase mode effects to weapon damage
        public static void ModifyDamageForPhaseMode(PhaseMode mode, ref DamagePayload damagePayload, TacticalActor target)
        {
            try
            {
                switch (mode)
                {
                    case PhaseMode.Kinetic:
                        ApplyKineticEffects(ref damagePayload);
                        break;
                    case PhaseMode.Energy:
                        ApplyEnergyEffects(ref damagePayload);
                        break;
                    case PhaseMode.Sonic:
                        ApplySonicEffects(ref damagePayload);
                        break;
                    case PhaseMode.Thermal:
                        ApplyThermalEffects(ref damagePayload, target);
                        break;
                    case PhaseMode.EMP:
                        ApplyEmpEffects(ref damagePayload, target);
                        break;
                }
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        private static void ApplyKineticEffects(ref DamagePayload damagePayload)
        {
            // Kinetic: High damage, destroys cover, pushes enemies
            var damageKeyword = damagePayload.DamageKeywords.FirstOrDefault(dk => dk.DamageKeywordDef == Shared.SharedDamageKeywords.DamageKeyword);
            if (damageKeyword != null)
            {
                damageKeyword.Value *= 1.25f; // 25% more damage
            }
            
            // Add shredding for cover destruction
            var shreddingKeyword = damagePayload.DamageKeywords.FirstOrDefault(dk => dk.DamageKeywordDef == Shared.SharedDamageKeywords.ShreddingKeyword);
            if (shreddingKeyword == null)
            {
                damagePayload.DamageKeywords.Add(new DamageKeywordPair
                {
                    DamageKeywordDef = Shared.SharedDamageKeywords.ShreddingKeyword,
                    Value = 15
                });
            }
        }

        private static void ApplyEnergyEffects(ref DamagePayload damagePayload)
        {
            // Energy: Ignores armor, disables electronics
            var piercingKeyword = damagePayload.DamageKeywords.FirstOrDefault(dk => dk.DamageKeywordDef == Shared.SharedDamageKeywords.PiercingKeyword);
            if (piercingKeyword != null)
            {
                piercingKeyword.Value *= 2f; // Double piercing
            }
            else
            {
                damagePayload.DamageKeywords.Add(new DamageKeywordPair
                {
                    DamageKeywordDef = Shared.SharedDamageKeywords.PiercingKeyword,
                    Value = 30
                });
            }

            // Add shock damage for electronics
            damagePayload.DamageKeywords.Add(new DamageKeywordPair
            {
                DamageKeywordDef = Shared.SharedDamageKeywords.ShockKeyword,
                Value = 50
            });
        }

        private static void ApplySonicEffects(ref DamagePayload damagePayload)
        {
            // Sonic: Area effect, causes disorientation
            damagePayload.AoeRadius = 2f; // 2-tile radius
            damagePayload.DamageDeliveryType = DamageDeliveryType.Sphere;

            // Add paralysis for disorientation
            damagePayload.DamageKeywords.Add(new DamageKeywordPair
            {
                DamageKeywordDef = Shared.SharedDamageKeywords.ParalysingKeyword,
                Value = 20
            });
        }

        private static void ApplyThermalEffects(ref DamagePayload damagePayload, TacticalActor target)
        {
            // Thermal: Heat-seeking, extra damage to organics
            bool isOrganic = target != null && IsOrganicTarget(target);
            
            var damageKeyword = damagePayload.DamageKeywords.FirstOrDefault(dk => dk.DamageKeywordDef == Shared.SharedDamageKeywords.DamageKeyword);
            if (damageKeyword != null && isOrganic)
            {
                damageKeyword.Value *= 1.5f; // 50% more damage to organics
            }

            // Add burning effect
            damagePayload.DamageKeywords.Add(new DamageKeywordPair
            {
                DamageKeywordDef = Shared.SharedDamageKeywords.BurningKeyword,
                Value = 25
            });
        }

        private static void ApplyEmpEffects(ref DamagePayload damagePayload, TacticalActor target)
        {
            // EMP: Disables mechanical enemies, damages robots
            bool isMechanical = target != null && IsMechanicalTarget(target);
            
            if (isMechanical)
            {
                var damageKeyword = damagePayload.DamageKeywords.FirstOrDefault(dk => dk.DamageKeywordDef == Shared.SharedDamageKeywords.DamageKeyword);
                if (damageKeyword != null)
                {
                    damageKeyword.Value *= 2f; // Double damage to mechanicals
                }
            }

            // Add shock and paralysis
            damagePayload.DamageKeywords.Add(new DamageKeywordPair
            {
                DamageKeywordDef = Shared.SharedDamageKeywords.ShockKeyword,
                Value = 100
            });

            damagePayload.DamageKeywords.Add(new DamageKeywordPair
            {
                DamageKeywordDef = Shared.SharedDamageKeywords.ParalysingKeyword,
                Value = 50
            });
        }

        private static bool IsOrganicTarget(TacticalActor target)
        {
            // Check if target is organic (has flesh, not mechanical)
            return target.TacticalActorBaseDef.name.Contains("Crab") || 
                   target.TacticalActorBaseDef.name.Contains("Worm") ||
                   target.TacticalActorBaseDef.name.Contains("Human") ||
                   target.TacticalActorBaseDef.name.Contains("Soldier") ||
                   !target.TacticalActorBaseDef.name.Contains("Mutog"); // Most are organic except Mutogs
        }

        private static bool IsMechanicalTarget(TacticalActor target)
        {
            // Check if target is mechanical
            return target.TacticalActorBaseDef.name.Contains("Mutog") ||
                   target.TacticalActorBaseDef.name.Contains("Scarab") ||
                   target.TacticalActorBaseDef.name.Contains("Aspida") ||
                   target.TacticalActorBaseDef.name.Contains("Armadillo");
        }

        // Integrate phase switching abilities with the Phase Rifle weapon
        private static void IntegrateWithPhaseRifle()
        {
            try
            {
                WeaponDef phaseRifle = DefCache.GetDef<WeaponDef>("TFTV_PhaseRifle_WeaponDef");
                if (phaseRifle != null && switchToKineticAbility != null)
                {
                    List<AbilityDef> abilities = new List<AbilityDef>(phaseRifle.Abilities);
                    
                    // Add all phase switching abilities
                    abilities.Add(switchToKineticAbility);
                    abilities.Add(switchToEnergyAbility);
                    abilities.Add(switchToSonicAbility);
                    abilities.Add(switchToThermalAbility);
                    abilities.Add(switchToEmpAbility);
                    
                    phaseRifle.Abilities = abilities.ToArray();
                    
                    TFTVLogger.Always("Phase switching abilities integrated with Phase Rifle");
                }
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }
    }
} 