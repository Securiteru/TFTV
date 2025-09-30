using HarmonyLib;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.DamageKeywords;
using PhoenixPoint.Tactical.Entities.Weapons;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Statuses;
using PhoenixPoint.Tactical.View.ViewControllers;
using PhoenixPoint.Tactical.View.ViewModules;
using PhoenixPoint.Tactical.Levels;
using Base.Defs;
using Base.UI;
using Base.Entities.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace TFTV
{
    public class TacticalWeapons
    {
        private static readonly DefRepository Repo = TFTVMain.Repo;
        private static readonly DefCache DefCache = TFTVMain.Main.DefCache;
        private static readonly SharedData Shared = TFTVMain.Shared;

        // 1. RICOCHET RIFLE - Master of indirect fire through calculated bounces
        public static WeaponDef ricochetRifle;
        
        // 2. CHEMICAL MORTAR - Area denial through persistent chemical effects
        public static WeaponDef chemicalMortar;
        
        // 3. TETHER GUN - Connects battlefield elements with tactical cables
        public static WeaponDef tetherGun;
        
        // 4. DEPLOYMENT LAUNCHER - Fires tactical equipment instead of ammunition
        public static WeaponDef deploymentLauncher;
        
        // 5. PHASE RIFLE - Weapon with swappable "phase modes" for different tactical roles
        public static WeaponDef phaseRifle;

        public void Initialize()
        {
            var harmony = new Harmony("io.github.tftv.tacticalweapons");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            
            CreateRicochetRifle();
            CreateChemicalMortar(); 
            CreateTetherGun();
            CreateDeploymentLauncher();
            CreatePhaseRifle();
            
            // Initialize the Phase Rifle mode system
            PhaseRifleModes.Initialize();
        }

        #region Ricochet Rifle Implementation
        
        private static void CreateRicochetRifle()
        {
            try
            {
                // Base it on a sniper rifle for good range and precision
                WeaponDef sourceWeapon = DefCache.GetDef<WeaponDef>("NE_SniperRifle_WeaponDef");
                
                ricochetRifle = Helper.CreateDefFromClone(sourceWeapon, "{A1B2C3D4-E5F6-7890-1234-RICOCHETRIFLE}", "TFTV_RicochetRifle_WeaponDef");
                
                // Setup basic properties
                ricochetRifle.ViewElementDef = Helper.CreateDefFromClone(sourceWeapon.ViewElementDef, "{A1B2C3D4-E5F6-7890-1234-RICOCHETVIEW}", "TFTV_RicochetRifle_ViewDef");
                ricochetRifle.ViewElementDef.DisplayName1 = new LocalizedTextBind("RICOCHET RIFLE", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                ricochetRifle.ViewElementDef.Description = new LocalizedTextBind("Advanced rifle that can ricochet shots off walls to hit enemies behind cover.", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                
                // Damage and mechanics
                ricochetRifle.DamagePayload.DamageKeywords = new List<DamageKeywordPair>()
                {
                    new DamageKeywordPair()
                    {
                        DamageKeywordDef = Shared.SharedDamageKeywords.DamageKeyword,
                        Value = 60
                    },
                    new DamageKeywordPair()
                    {
                        DamageKeywordDef = Shared.SharedDamageKeywords.PiercingKeyword,
                        Value = 20
                    }
                };
                
                ricochetRifle.SpreadDegrees = 41f / 18; // 18 effective range
                ricochetRifle.ChargesMax = 8;
                ricochetRifle.APToUsePerc = 50; // Half action points

                // Create ricochet ability
                ShootAbilityDef ricochetShoot = Helper.CreateDefFromClone(
                    DefCache.GetDef<ShootAbilityDef>("Weapon_ShootAbilityDef"),
                    "{A1B2C3D4-E5F6-7890-1234-RICOCHETSHOOT}",
                    "TFTV_RicochetShoot_AbilityDef");
                    
                ricochetShoot.ViewElementDef = Helper.CreateDefFromClone(
                    ((TacticalAbilityDef)sourceWeapon.Abilities[0]).ViewElementDef,
                    "{A1B2C3D4-E5F6-7890-1234-RICOCHETSHOOTVIEW}",
                    "TFTV_RicochetShoot_ViewDef");
                    
                ricochetShoot.ViewElementDef.DisplayName1 = new LocalizedTextBind("RICOCHET SHOT", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                ricochetShoot.ViewElementDef.Description = new LocalizedTextBind("Fire a shot that can bounce off walls up to 3 times.", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);

                ricochetRifle.Abilities = new AbilityDef[]
                {
                    ricochetShoot,
                    DefCache.GetDef<AbilityDef>("Reload_AbilityDef"),
                    DefCache.GetDef<AbilityDef>("DropItem_AbilityDef")
                };

                TFTVLogger.Always("Ricochet Rifle created successfully");
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        #endregion

        #region Chemical Mortar Implementation
        
        private static void CreateChemicalMortar()
        {
            try
            {
                // Base it on grenade launcher for area effects
                WeaponDef sourceWeapon = DefCache.GetDef<WeaponDef>("PX_GrenadeLauncher_WeaponDef");
                
                chemicalMortar = Helper.CreateDefFromClone(sourceWeapon, "{B1C2D3E4-F5G6-7890-1234-CHEMMORTAR}", "TFTV_ChemicalMortar_WeaponDef");
                
                chemicalMortar.ViewElementDef = Helper.CreateDefFromClone(sourceWeapon.ViewElementDef, "{B1C2D3E4-F5G6-7890-1234-CHEMVIEW}", "TFTV_ChemicalMortar_ViewDef");
                chemicalMortar.ViewElementDef.DisplayName1 = new LocalizedTextBind("CHEMICAL MORTAR", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                chemicalMortar.ViewElementDef.Description = new LocalizedTextBind("Launches chemical shells that create persistent area denial effects.", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                
                // Enhanced area damage with chemical effects
                chemicalMortar.DamagePayload.DamageKeywords = new List<DamageKeywordPair>()
                {
                    new DamageKeywordPair()
                    {
                        DamageKeywordDef = Shared.SharedDamageKeywords.DamageKeyword,
                        Value = 40
                    },
                    new DamageKeywordPair()
                    {
                        DamageKeywordDef = Shared.SharedDamageKeywords.AcidKeyword,
                        Value = 30
                    },
                    new DamageKeywordPair()
                    {
                        DamageKeywordDef = Shared.SharedDamageKeywords.PoisonousKeyword,
                        Value = 20
                    }
                };
                
                chemicalMortar.DamagePayload.AoeRadius = 4f; // Large area effect
                chemicalMortar.DamagePayload.DamageDeliveryType = DamageDeliveryType.Sphere;
                chemicalMortar.ChargesMax = 6;
                chemicalMortar.APToUsePerc = 75; // Heavy weapon

                TFTVLogger.Always("Chemical Mortar created successfully");
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        #endregion

        #region Tether Gun Implementation
        
        private static void CreateTetherGun()
        {
            try
            {
                // Base it on crossbow for precision targeting
                WeaponDef sourceWeapon = DefCache.GetDef<WeaponDef>("SY_Crossbow_WeaponDef");
                
                tetherGun = Helper.CreateDefFromClone(sourceWeapon, "{C1D2E3F4-G5H6-7890-1234-TETHERGUN}", "TFTV_TetherGun_WeaponDef");
                
                tetherGun.ViewElementDef = Helper.CreateDefFromClone(sourceWeapon.ViewElementDef, "{C1D2E3F4-G5H6-7890-1234-TETHERVIEW}", "TFTV_TetherGun_ViewDef");
                tetherGun.ViewElementDef.DisplayName1 = new LocalizedTextBind("TETHER GUN", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                tetherGun.ViewElementDef.Description = new LocalizedTextBind("Fires tactical cables to bind enemies or create movement routes.", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                
                // Low damage but special effects
                tetherGun.DamagePayload.DamageKeywords = new List<DamageKeywordPair>()
                {
                    new DamageKeywordPair()
                    {
                        DamageKeywordDef = Shared.SharedDamageKeywords.DamageKeyword,
                        Value = 20
                    },
                    new DamageKeywordPair()
                    {
                        DamageKeywordDef = Shared.SharedDamageKeywords.ParalysingKeyword,
                        Value = 40
                    }
                };
                
                tetherGun.SpreadDegrees = 41f / 15; // 15 effective range
                tetherGun.ChargesMax = 4;
                tetherGun.APToUsePerc = 25; // Quick to use

                TFTVLogger.Always("Tether Gun created successfully");
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        #endregion

        #region Deployment Launcher Implementation
        
        private static void CreateDeploymentLauncher()
        {
            try
            {
                // Base it on rocket launcher for deployable items
                WeaponDef sourceWeapon = DefCache.GetDef<WeaponDef>("NJ_HeavyRocketLauncher_WeaponDef");
                
                deploymentLauncher = Helper.CreateDefFromClone(sourceWeapon, "{D1E2F3G4-H5I6-7890-1234-DEPLOYLAUNCH}", "TFTV_DeploymentLauncher_WeaponDef");
                
                deploymentLauncher.ViewElementDef = Helper.CreateDefFromClone(sourceWeapon.ViewElementDef, "{D1E2F3G4-H5I6-7890-1234-DEPLOYVIEW}", "TFTV_DeploymentLauncher_ViewDef");
                deploymentLauncher.ViewElementDef.DisplayName1 = new LocalizedTextBind("DEPLOYMENT LAUNCHER", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                deploymentLauncher.ViewElementDef.Description = new LocalizedTextBind("Fires tactical equipment instead of ammunition to modify the battlefield.", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                
                // Minimal damage, all about utility
                deploymentLauncher.DamagePayload.DamageKeywords = new List<DamageKeywordPair>()
                {
                    new DamageKeywordPair()
                    {
                        DamageKeywordDef = Shared.SharedDamageKeywords.DamageKeyword,
                        Value = 10
                    }
                };
                
                deploymentLauncher.DamagePayload.AoeRadius = 2f;
                deploymentLauncher.DamagePayload.DamageDeliveryType = DamageDeliveryType.Sphere;
                deploymentLauncher.ChargesMax = 5;
                deploymentLauncher.APToUsePerc = 50;

                TFTVLogger.Always("Deployment Launcher created successfully");
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        #endregion

        #region Phase Rifle Implementation
        
        private void CreatePhaseRifle()
        {
            try
            {
                // Use laser sniper rifle as base for Phase Rifle
                WeaponDef sourceWeapon = DefCache.GetDef<WeaponDef>("NJ_LaserSniper_WeaponDef");
                
                WeaponDef phaseRifle = Helper.CreateDefFromClone(
                    sourceWeapon,
                    "{E5F6G7H8-I9J0-1234-5678-PHASERIFLE}",
                    "TFTV_PhaseRifle_WeaponDef");

                phaseRifle.ViewElementDef = Helper.CreateDefFromClone(
                    sourceWeapon.ViewElementDef,
                    "{E5F6G7H8-I9J0-1234-5678-PHASERIFLEV}",
                    "TFTV_PhaseRifle_ViewDef");

                phaseRifle.ViewElementDef.DisplayName1 = new LocalizedTextBind("PHASE RIFLE", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);
                phaseRifle.ViewElementDef.Description = new LocalizedTextBind("Advanced energy weapon with multiple firing modes that can be switched mid-combat.", TFTVMain.Main.Settings.DoNotLocalizeChangedTexts);

                // Start in Kinetic mode by default
                List<AbilityDef> abilities = new List<AbilityDef>(sourceWeapon.Abilities);
                
                // Add phase switching abilities (these will be created by PhaseRifleModes.Initialize())
                // They'll be added to the weapon after the system initializes
                
                phaseRifle.Abilities = abilities.ToArray();
                
                // Modify base stats for Phase Rifle
                phaseRifle.DamagePayload.DamageKeywords.Clear();
                phaseRifle.DamagePayload.DamageKeywords.Add(new DamageKeywordPair()
                {
                    DamageKeywordDef = Shared.SharedDamageKeywords.DamageKeyword,
                    Value = 120 // High base damage
                });

                phaseRifle.DamagePayload.Range = 18f; // Long range
                phaseRifle.ChargesMax = 8;
                phaseRifle.APToUsePerc = 50; // 2 action points to fire (converted to int)

                TFTVLogger.Always("Phase Rifle created successfully");
            }
            catch (Exception e)
            {
                TFTVLogger.Error(e);
            }
        }

        #endregion

        #region Weapon Behavior Patches

        // Patch for ricochet behavior - intercept projectile logic
        [HarmonyPatch(typeof(Weapon), "GetDamagePayload")]
        public static class Weapon_GetDamagePayload_RicochetPatch
        {
            public static void Postfix(Weapon __instance, ref DamagePayload __result)
            {
                try
                {
                    if (__instance.WeaponDef == ricochetRifle && __instance.TacticalActor != null)
                    {
                        // Modify damage payload for ricochet behavior
                        // After first bounce, reduce damage but split projectile
                        __result.ProjectilesPerShot = 3; // Split after first bounce
                        __result.DamageKeywords.Find(dk => dk.DamageKeywordDef == Shared.SharedDamageKeywords.DamageKeyword).Value *= 0.8f; // Slight damage reduction
                    }
                }
                catch (Exception e)
                {
                    TFTVLogger.Error(e);
                }
            }
        }

        // Patch for chemical mortar persistent effects
        [HarmonyPatch(typeof(DamagePayload), "CalculateDamage")]
        public static class DamagePayload_CalculateDamage_ChemicalPatch
        {
            public static void Postfix(DamagePayload __instance, ref DamageResult __result)
            {
                try
                {
                    if (__instance.AutoFireShotCount > 0) // Check if this is from chemical mortar
                    {
                        // Add persistent chemical area effect
                        // This would normally create voxel effects or environmental hazards
                        TFTVLogger.Always("Chemical mortar effect triggered");
                    }
                }
                catch (Exception e)
                {
                    TFTVLogger.Error(e);
                }
            }
        }

        // Patch for tether gun movement restriction
        [HarmonyPatch(typeof(TacticalActor), "GetMoveRange")]
        public static class TacticalActor_GetMoveRange_TetherPatch
        {
            public static void Postfix(TacticalActor __instance, ref float __result)
            {
                try
                {
                    // Check if actor is tethered and reduce movement accordingly
                    if (__instance.Status != null && __instance.Status.HasStatus(Shared.SharedGameTags.ParalyzedStatus))
                    {
                        // For now, treat any paralyzed status as potential tether
                        // In a full implementation, we'd check for specific tether status
                        __result *= 0.5f; // Half movement when tethered
                    }
                }
                catch (Exception e)
                {
                    TFTVLogger.Error(e);
                }
            }
        }

        // Patch for deployment launcher terrain modification
        [HarmonyPatch(typeof(ShootAbility), "Activate")]
        public static class ShootAbility_Activate_DeploymentPatch
        {
            public static void Postfix(ShootAbility __instance)
            {
                try
                {
                    if (__instance.Weapon.WeaponDef == deploymentLauncher)
                    {
                        // Create deployable cover or equipment at target location
                        TFTVLogger.Always("Deployment launcher effect triggered");
                        // This would spawn tactical equipment at the target position
                    }
                }
                catch (Exception e)
                {
                    TFTVLogger.Error(e);
                }
            }
        }

        // Patch for phase rifle mode switching
        [HarmonyPatch(typeof(Equipment), "OnEquip")]
        public static class Equipment_OnEquip_PhasePatch
        {
            public static void Postfix(Equipment __instance)
            {
                try
                {
                    if (__instance is Weapon weapon && weapon.WeaponDef == phaseRifle)
                    {
                        // Initialize phase rifle in kinetic mode
                        TFTVLogger.Always("Phase rifle equipped - initializing in Kinetic mode");
                        // Set initial damage keywords and properties
                    }
                }
                catch (Exception e)
                {
                    TFTVLogger.Error(e);
                }
            }
        }

        // Patch for Phase Rifle damage modification based on current mode
        [HarmonyPatch(typeof(Weapon), "GetDamagePayload")]
        public static class Weapon_GetDamagePayload_PhaseRiflePatch
        {
            public static void Postfix(Weapon __instance, ref DamagePayload __result, Vector3 targetPosition)
            {
                try
                {
                    // Check if this is a Phase Rifle
                    if (__instance.WeaponDef.name == "TFTV_PhaseRifle_WeaponDef")
                    {
                        TacticalActor actor = __instance.TacticalActor;
                        PhaseMode currentMode = PhaseRifleModes.GetCurrentPhaseMode(actor);
                        
                        // For this implementation, we'll modify damage without specific target detection
                        // In a full implementation, you'd need proper target detection logic
                        TacticalActor target = null; // Simplified for now
                        
                        // Apply phase-specific modifications
                        PhaseRifleModes.ModifyDamageForPhaseMode(currentMode, ref __result, target);
                        
                        TFTVLogger.Always(string.Format("Phase Rifle fired in {0} mode", currentMode));
                    }
                }
                catch (Exception e)
                {
                    TFTVLogger.Error(e);
                }
            }
        }

        #endregion
    }
} 