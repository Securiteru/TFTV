
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern 'Assembly-CSharp'
{
  .ver 0:0:0:0
}
.assembly extern '0Harmony'
{
  .ver 1:2:0:1
}
.assembly extern UnityEngine.CoreModule
{
  .ver 0:0:0:0
}
.assembly extern System.Core
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern UnityEngine.UI
{
  .ver 1:0:0:0
}
.assembly PhoenixPt_UnlimitedDeploy
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 10 55 6E 6C 69 6D 69 74 65 64 20 44 65 70   // ...Unlimited Dep
                                                                                              6C 6F 79 00 00 )                                  // loy..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 24 50 68 6F 65 6E 69 78 20 50 6F 69 6E 74   // ..$Phoenix Point
                                                                                                    20 6D 6F 64 20 2D 20 55 6E 6C 69 6D 69 74 65 64   //  mod - Unlimited
                                                                                                    20 44 65 70 6C 6F 79 00 00 )                      //  Deploy..
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 06 53 68 65 65 70 79 00 00 )                // ...Sheepy..
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 0D 50 75 62 6C 69 63 20 44 6F 6D 61 69 6E   // ...Public Domain
                                                                                                  00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 66 30 35 66 62 35 64 38 2D 62 66 64 66   // ..$f05fb5d8-bfdf
                                                                                                  2D 34 38 34 35 2D 61 61 63 35 2D 35 30 39 39 31   // -4845-aac5-50991
                                                                                                  32 64 32 37 64 34 64 00 00 )                      // 2d27d4d..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 32 2E 30 2E 30 2E 30 00 00 )             // ...2.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1A 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 35 01 00 54   // ,Version=v4.5..T
                                                                                                        0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C   // ..FrameworkDispl
                                                                                                        61 79 4E 61 6D 65 12 2E 4E 45 54 20 46 72 61 6D   // ayName..NET Fram
                                                                                                        65 77 6F 72 6B 20 34 2E 35 )                      // ework 4.5
  .hash algorithm 0x00008004
  .ver 2:0:0:0
}
.module PhoenixPt_UnlimitedDeploy.dll
// MVID: {548DB853-AFF6-4818-A30F-CDA961E94AF1}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x06E40000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit Sheepy.PhoenixPt_UnlimitedDeploy.Mod
       extends [mscorlib]System.Object
{
  .class auto ansi serializable sealed nested private beforefieldinit '<>c'
         extends [mscorlib]System.Object
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public static initonly class Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c' '<>9'
    .field public static class [mscorlib]System.Func`2<string,string> '<>9__5_0'
    .field public static class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem,bool> '<>9__7_0'
    .field public static class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem,bool> '<>9__8_0'
    .field public static class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition,bool> '<>9__18_0'
    .method private hidebysig specialname rtspecialname static 
            void  .cctor() cil managed
    {
      // Code size       11 (0xb)
      .maxstack  8
      IL_0000:  newobj     instance void Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::.ctor()
      IL_0005:  stsfld     class Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c' Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9'
      IL_000a:  ret
    } // end of method '<>c'::.cctor

    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
    } // end of method '<>c'::.ctor

    .method assembly hidebysig instance string 
            '<TitleCase>b__5_0'(string e) cil managed
    {
      // Code size       31 (0x1f)
      .maxstack  8
      IL_0000:  ldarg.1
      IL_0001:  ldc.i4.0
      IL_0002:  ldc.i4.1
      IL_0003:  callvirt   instance string [mscorlib]System.String::Substring(int32,
                                                                              int32)
      IL_0008:  callvirt   instance string [mscorlib]System.String::ToUpper()
      IL_000d:  ldarg.1
      IL_000e:  ldc.i4.1
      IL_000f:  callvirt   instance string [mscorlib]System.String::Substring(int32)
      IL_0014:  callvirt   instance string [mscorlib]System.String::ToLower()
      IL_0019:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_001e:  ret
    } // end of method '<>c'::'<TitleCase>b__5_0'

    .method assembly hidebysig instance bool 
            '<OverrideEnrollmentChanged_UncapVehicle>b__7_0'(class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem s) cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.1
      IL_0001:  ldfld      bool ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem::EnrollForDeployment
      IL_0006:  ret
    } // end of method '<>c'::'<OverrideEnrollmentChanged_UncapVehicle>b__7_0'

    .method assembly hidebysig instance bool 
            '<OverrideSetRecruitment_UncapDeploy>b__8_0'(class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem e) cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.1
      IL_0001:  ldfld      bool ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem::EnrollForDeployment
      IL_0006:  ret
    } // end of method '<>c'::'<OverrideSetRecruitment_UncapDeploy>b__8_0'

    .method assembly hidebysig instance bool 
            '<IsVehicleZone>b__18_0'(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition cond) cil managed
    {
      // Code size       22 (0x16)
      .maxstack  8
      IL_0000:  ldarg.1
      IL_0001:  ldfld      class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition::MissionData
      IL_0006:  ldfld      class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData::ActorTagDef
      IL_000b:  ldsfld     class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeploymentTag
      IL_0010:  call       bool [UnityEngine.CoreModule]UnityEngine.Object::op_Equality(class [UnityEngine.CoreModule]UnityEngine.Object,
                                                                                        class [UnityEngine.CoreModule]UnityEngine.Object)
      IL_0015:  ret
    } // end of method '<>c'::'<IsVehicleZone>b__18_0'

  } // end of class '<>c'

  .field private static class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef vehicleDeploymentTag
  .field private static int32 vehicleDeployedCount
  .field private static int32 vehicleZoneCount
  .field private static int32 zoneCount
  .field private static class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone> allZones
  .field private static class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> artificalTags
  .method public hidebysig static void  Init() cil managed
  {
    // Code size       213 (0xd5)
    .maxstack  6
    IL_0000:  ldtoken    Sheepy.PhoenixPt_UnlimitedDeploy.Mod
    IL_0005:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_000a:  callvirt   instance string [mscorlib]System.Type::get_Namespace()
    IL_000f:  call       class ['0Harmony']Harmony.HarmonyInstance ['0Harmony']Harmony.HarmonyInstance::Create(string)
    IL_0014:  dup
    IL_0015:  ldtoken    ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewStates.UIStateRosterDeployment
    IL_001a:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_001f:  ldstr      "SetUpInitialDeployment"
    IL_0024:  ldstr      "BeforeSetUpInitialDeployment_UncapDeploy"
    IL_0029:  ldnull
    IL_002a:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::Patch(class ['0Harmony']Harmony.HarmonyInstance,
                                                                          class [mscorlib]System.Type,
                                                                          string,
                                                                          string,
                                                                          string)
    IL_002f:  dup
    IL_0030:  ldtoken    ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewStates.UIStateRosterDeployment
    IL_0035:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_003a:  ldstr      "OnEnrollmentChanged"
    IL_003f:  ldstr      "OverrideEnrollmentChanged_UncapVehicle"
    IL_0044:  ldnull
    IL_0045:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::Patch(class ['0Harmony']Harmony.HarmonyInstance,
                                                                          class [mscorlib]System.Type,
                                                                          string,
                                                                          string,
                                                                          string)
    IL_004a:  dup
    IL_004b:  ldtoken    ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewStates.UIStateRosterDeployment
    IL_0050:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0055:  ldstr      "CheckForDeployment"
    IL_005a:  ldstr      "OverrideSetRecruitment_UncapDeploy"
    IL_005f:  ldnull
    IL_0060:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::Patch(class ['0Harmony']Harmony.HarmonyInstance,
                                                                          class [mscorlib]System.Type,
                                                                          string,
                                                                          string,
                                                                          string)
    IL_0065:  dup
    IL_0066:  ldtoken    ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewModules.UIModuleDeploymentMissionBriefing
    IL_006b:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0070:  ldstr      "SetCurrentDeployment"
    IL_0075:  ldstr      "OverrideSetCurrentDeployment_HideCap"
    IL_007a:  ldnull
    IL_007b:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::Patch(class ['0Harmony']Harmony.HarmonyInstance,
                                                                          class [mscorlib]System.Type,
                                                                          string,
                                                                          string,
                                                                          string)
    IL_0080:  dup
    IL_0081:  ldtoken    ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn
    IL_0086:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_008b:  ldstr      "DeployForTurn"
    IL_0090:  ldstr      "BeforeDeployForTurn_SetPriority"
    IL_0095:  ldstr      "AfterDeployForTurn_RestoreZones"
    IL_009a:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::Patch(class ['0Harmony']Harmony.HarmonyInstance,
                                                                          class [mscorlib]System.Type,
                                                                          string,
                                                                          string,
                                                                          string)
    IL_009f:  dup
    IL_00a0:  ldtoken    ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn
    IL_00a5:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00aa:  ldstr      "GetAllowedZonePositions"
    IL_00af:  ldnull
    IL_00b0:  ldstr      "AfterGetAllowedZonePositions_StoreZones"
    IL_00b5:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::Patch(class ['0Harmony']Harmony.HarmonyInstance,
                                                                          class [mscorlib]System.Type,
                                                                          string,
                                                                          string,
                                                                          string)
    IL_00ba:  ldtoken    ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn
    IL_00bf:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00c4:  ldstr      "GenerateNextActorToDeploy"
    IL_00c9:  ldnull
    IL_00ca:  ldstr      "AfterGenerateNextActorToDeploy_CheckZones"
    IL_00cf:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::Patch(class ['0Harmony']Harmony.HarmonyInstance,
                                                                          class [mscorlib]System.Type,
                                                                          string,
                                                                          string,
                                                                          string)
    IL_00d4:  ret
  } // end of method Mod::Init

  .method private hidebysig static void  Patch(class ['0Harmony']Harmony.HarmonyInstance harmony,
                                               class [mscorlib]System.Type target,
                                               string toPatch,
                                               string prefix,
                                               [opt] string postfix) cil managed
  {
    .param [5] = nullref
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  ldc.i4.s   60
    IL_0005:  callvirt   instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string,
                                                                                                                valuetype [mscorlib]System.Reflection.BindingFlags)
    IL_000a:  ldarg.3
    IL_000b:  ldarg.s    postfix
    IL_000d:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::Patch(class ['0Harmony']Harmony.HarmonyInstance,
                                                                          class [mscorlib]System.Reflection.MethodInfo,
                                                                          string,
                                                                          string)
    IL_0012:  ret
  } // end of method Mod::Patch

  .method private hidebysig static void  Patch(class ['0Harmony']Harmony.HarmonyInstance harmony,
                                               class [mscorlib]System.Reflection.MethodInfo toPatch,
                                               string prefix,
                                               [opt] string postfix) cil managed
  {
    .param [4] = nullref
    // Code size       22 (0x16)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       class ['0Harmony']Harmony.HarmonyMethod Sheepy.PhoenixPt_UnlimitedDeploy.Mod::ToHarmonyMethod(string)
    IL_0008:  ldarg.3
    IL_0009:  call       class ['0Harmony']Harmony.HarmonyMethod Sheepy.PhoenixPt_UnlimitedDeploy.Mod::ToHarmonyMethod(string)
    IL_000e:  ldnull
    IL_000f:  callvirt   instance class [mscorlib]System.Reflection.Emit.DynamicMethod ['0Harmony']Harmony.HarmonyInstance::Patch(class [mscorlib]System.Reflection.MethodBase,
                                                                                                                                  class ['0Harmony']Harmony.HarmonyMethod,
                                                                                                                                  class ['0Harmony']Harmony.HarmonyMethod,
                                                                                                                                  class ['0Harmony']Harmony.HarmonyMethod)
    IL_0014:  pop
    IL_0015:  ret
  } // end of method Mod::Patch

  .method private hidebysig static class ['0Harmony']Harmony.HarmonyMethod 
          ToHarmonyMethod(string name) cil managed
  {
    // Code size       53 (0x35)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brtrue.s   IL_0005

    IL_0003:  ldnull
    IL_0004:  ret

    IL_0005:  ldtoken    Sheepy.PhoenixPt_UnlimitedDeploy.Mod
    IL_000a:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_000f:  ldarg.0
    IL_0010:  call       instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string)
    IL_0015:  dup
    IL_0016:  ldnull
    IL_0017:  call       bool [mscorlib]System.Reflection.MethodInfo::op_Equality(class [mscorlib]System.Reflection.MethodInfo,
                                                                                  class [mscorlib]System.Reflection.MethodInfo)
    IL_001c:  brfalse.s  IL_002f

    IL_001e:  ldarg.0
    IL_001f:  ldstr      " is null"
    IL_0024:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0029:  newobj     instance void [mscorlib]System.NullReferenceException::.ctor(string)
    IL_002e:  throw

    IL_002f:  newobj     instance void ['0Harmony']Harmony.HarmonyMethod::.ctor(class [mscorlib]System.Reflection.MethodInfo)
    IL_0034:  ret
  } // end of method Mod::ToHarmonyMethod

  .method private hidebysig static bool  LogError(class [mscorlib]System.Exception ex) cil managed
  {
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldc.i4.1
    IL_0001:  ret
  } // end of method Mod::LogError

  .method private hidebysig static string 
          TitleCase(string txt) cil managed
  {
    // Code size       59 (0x3b)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.1
    IL_0002:  newarr     [mscorlib]System.Char
    IL_0007:  dup
    IL_0008:  ldc.i4.0
    IL_0009:  ldc.i4.s   32
    IL_000b:  stelem.i2
    IL_000c:  callvirt   instance string[] [mscorlib]System.String::Split(char[])
    IL_0011:  ldsfld     class [mscorlib]System.Func`2<string,string> Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9__5_0'
    IL_0016:  dup
    IL_0017:  brtrue.s   IL_0030

    IL_0019:  pop
    IL_001a:  ldsfld     class Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c' Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9'
    IL_001f:  ldftn      instance string Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<TitleCase>b__5_0'(string)
    IL_0025:  newobj     instance void class [mscorlib]System.Func`2<string,string>::.ctor(object,
                                                                                           native int)
    IL_002a:  dup
    IL_002b:  stsfld     class [mscorlib]System.Func`2<string,string> Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9__5_0'
    IL_0030:  ldstr      " "
    IL_0035:  call       string ['0Harmony']Harmony.GeneralExtensions::Join<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                    class [mscorlib]System.Func`2<!!0,string>,
                                                                                    string)
    IL_003a:  ret
  } // end of method Mod::TitleCase

  .method public hidebysig static void  BeforeSetUpInitialDeployment_UncapDeploy(class ['Assembly-CSharp']PhoenixPoint.Geoscape.Entities.GeoMission ____mission) cil managed
  {
    // Code size       27 (0x1b)
    .maxstack  2
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  callvirt   instance class ['Assembly-CSharp']PhoenixPoint.Common.Levels.Missions.TacMissionTypeDef ['Assembly-CSharp']PhoenixPoint.Geoscape.Entities.GeoMission::get_MissionDef()
      IL_0006:  ldc.i4     0x270f
      IL_000b:  stfld      int32 ['Assembly-CSharp']PhoenixPoint.Common.Levels.Missions.TacMissionTypeDef::MaxPlayerUnits
      IL_0010:  leave.s    IL_001a

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0012:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::LogError(class [mscorlib]System.Exception)
      IL_0017:  pop
      IL_0018:  leave.s    IL_001a

    }  // end handler
    IL_001a:  ret
  } // end of method Mod::BeforeSetUpInitialDeployment_UncapDeploy

  .method public hidebysig static bool  OverrideEnrollmentChanged_UncapVehicle(class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewStates.UIStateRosterDeployment __instance,
                                                                               class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem item,
                                                                               class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem> ____deploymentItems) cil managed
  {
    .custom instance void ['0Harmony']Harmony.HarmonyPriority::.ctor(int32) = ( 01 00 C8 00 00 00 00 00 ) 
    // Code size       79 (0x4f)
    .maxstack  4
    .locals init (bool V_0)
    .try
    {
      IL_0000:  ldarg.1
      IL_0001:  ldarg.1
      IL_0002:  ldfld      bool ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem::EnrollForDeployment
      IL_0007:  ldc.i4.0
      IL_0008:  ceq
      IL_000a:  stfld      bool ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem::EnrollForDeployment
      IL_000f:  ldarg.1
      IL_0010:  callvirt   instance void ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem::RefreshCheckVisuals()
      IL_0015:  ldarg.0
      IL_0016:  ldarg.2
      IL_0017:  ldsfld     class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem,bool> Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9__7_0'
      IL_001c:  dup
      IL_001d:  brtrue.s   IL_0036

      IL_001f:  pop
      IL_0020:  ldsfld     class Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c' Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9'
      IL_0025:  ldftn      instance bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<OverrideEnrollmentChanged_UncapVehicle>b__7_0'(class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem)
      IL_002b:  newobj     instance void class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem,bool>::.ctor(object,
                                                                                                                                                                                       native int)
      IL_0030:  dup
      IL_0031:  stsfld     class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem,bool> Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9__7_0'
      IL_0036:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                                                                                                                        class [mscorlib]System.Func`2<!!0,bool>)
      IL_003b:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::OverrideSetRecruitment_UncapDeploy(class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewStates.UIStateRosterDeployment,
                                                                                                         class [mscorlib]System.Collections.Generic.IEnumerable`1<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem>)
      IL_0040:  pop
      IL_0041:  ldc.i4.0
      IL_0042:  stloc.0
      IL_0043:  leave.s    IL_004d

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0045:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::LogError(class [mscorlib]System.Exception)
      IL_004a:  stloc.0
      IL_004b:  leave.s    IL_004d

    }  // end handler
    IL_004d:  ldloc.0
    IL_004e:  ret
  } // end of method Mod::OverrideEnrollmentChanged_UncapVehicle

  .method public hidebysig static bool  OverrideSetRecruitment_UncapDeploy(class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewStates.UIStateRosterDeployment __instance,
                                                                           class [mscorlib]System.Collections.Generic.IEnumerable`1<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem> squad) cil managed
  {
    .custom instance void ['0Harmony']Harmony.HarmonyPriority::.ctor(int32) = ( 01 00 C8 00 00 00 00 00 ) 
    // Code size       120 (0x78)
    .maxstack  4
    .locals init (int32 V_0,
             bool V_1)
    .try
    {
      IL_0000:  ldarg.1
      IL_0001:  ldsfld     class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem,bool> Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9__8_0'
      IL_0006:  dup
      IL_0007:  brtrue.s   IL_0020

      IL_0009:  pop
      IL_000a:  ldsfld     class Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c' Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9'
      IL_000f:  ldftn      instance bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<OverrideSetRecruitment_UncapDeploy>b__8_0'(class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem)
      IL_0015:  newobj     instance void class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem,bool>::.ctor(object,
                                                                                                                                                                                       native int)
      IL_001a:  dup
      IL_001b:  stsfld     class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem,bool> Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9__8_0'
      IL_0020:  call       int32 [System.Core]System.Linq.Enumerable::Count<class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewControllers.Roster.GeoRosterDeploymentItem>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                                                                class [mscorlib]System.Func`2<!!0,bool>)
      IL_0025:  stloc.0
      IL_0026:  ldtoken    ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewStates.UIStateRosterDeployment
      IL_002b:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0030:  ldstr      "_missionBriefingModule"
      IL_0035:  ldc.i4.s   36
      IL_0037:  call       instance class [mscorlib]System.Reflection.PropertyInfo [mscorlib]System.Type::GetProperty(string,
                                                                                                                      valuetype [mscorlib]System.Reflection.BindingFlags)
      IL_003c:  dup
      IL_003d:  brtrue.s   IL_0043

      IL_003f:  pop
      IL_0040:  ldnull
      IL_0041:  br.s       IL_0049

      IL_0043:  ldarg.0
      IL_0044:  call       instance object [mscorlib]System.Reflection.PropertyInfo::GetValue(object)
      IL_0049:  isinst     ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewModules.UIModuleDeploymentMissionBriefing
      IL_004e:  dup
      IL_004f:  ldloc.0
      IL_0050:  ldc.i4.0
      IL_0051:  callvirt   instance void ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewModules.UIModuleDeploymentMissionBriefing::SetCurrentDeployment(int32,
                                                                                                                                                           int32)
      IL_0056:  ldfld      class ['Assembly-CSharp']PhoenixPoint.Common.View.ViewControllers.PhoenixGeneralButton ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewModules.UIModuleDeploymentMissionBriefing::DeployButton
      IL_005b:  dup
      IL_005c:  ldloc.0
      IL_005d:  ldc.i4.0
      IL_005e:  cgt
      IL_0060:  callvirt   instance void ['Assembly-CSharp']PhoenixPoint.Common.View.ViewControllers.PhoenixGeneralButton::SetInteractable(bool)
      IL_0065:  callvirt   instance void ['Assembly-CSharp']PhoenixPoint.Common.View.ViewControllers.PhoenixGeneralButton::ResetButtonAnimations()
      IL_006a:  ldc.i4.0
      IL_006b:  stloc.1
      IL_006c:  leave.s    IL_0076

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_006e:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::LogError(class [mscorlib]System.Exception)
      IL_0073:  stloc.1
      IL_0074:  leave.s    IL_0076

    }  // end handler
    IL_0076:  ldloc.1
    IL_0077:  ret
  } // end of method Mod::OverrideSetRecruitment_UncapDeploy

  .method public hidebysig static bool  OverrideSetCurrentDeployment_HideCap(class ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewModules.UIModuleDeploymentMissionBriefing __instance,
                                                                             int32 currentDeploymentNumber) cil managed
  {
    .custom instance void ['0Harmony']Harmony.HarmonyPriority::.ctor(int32) = ( 01 00 C8 00 00 00 00 00 ) 
    // Code size       68 (0x44)
    .maxstack  4
    .locals init (bool V_0)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  ldfld      class [UnityEngine.UI]UnityEngine.UI.Text ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewModules.UIModuleDeploymentMissionBriefing::SquadSlotsUsedText
      IL_0006:  ldarg.0
      IL_0007:  ldfld      class ['Assembly-CSharp']Base.UI.LocalizedTextBind ['Assembly-CSharp']PhoenixPoint.Geoscape.View.ViewModules.UIModuleDeploymentMissionBriefing::SquadSlotsUsedTextKey
      IL_000c:  ldnull
      IL_000d:  callvirt   instance string ['Assembly-CSharp']Base.UI.LocalizedTextBind::Localize(string)
      IL_0012:  ldstr      "/{1}"
      IL_0017:  ldstr      ""
      IL_001c:  callvirt   instance string [mscorlib]System.String::Replace(string,
                                                                            string)
      IL_0021:  ldarg.1
      IL_0022:  box        [mscorlib]System.Int32
      IL_0027:  ldstr      bytearray (1E 22 )                                           // ."
      IL_002c:  call       string [mscorlib]System.String::Format(string,
                                                                  object,
                                                                  object)
      IL_0031:  callvirt   instance void [UnityEngine.UI]UnityEngine.UI.Text::set_text(string)
      IL_0036:  ldc.i4.0
      IL_0037:  stloc.0
      IL_0038:  leave.s    IL_0042

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_003a:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::LogError(class [mscorlib]System.Exception)
      IL_003f:  stloc.0
      IL_0040:  leave.s    IL_0042

    }  // end handler
    IL_0042:  ldloc.0
    IL_0043:  ret
  } // end of method Mod::OverrideSetCurrentDeployment_HideCap

  .method private hidebysig static bool  IsPlayerSpawn(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn __instance) cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.TacticalFaction ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn::get_TacticalFaction()
    IL_0006:  callvirt   instance bool ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.TacticalFaction::get_IsControlledByPlayer()
    IL_000b:  ret
  } // end of method Mod::IsPlayerSpawn

  .method private hidebysig static void  GetVehicleTag(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn __instance) cil managed
  {
    // Code size       132 (0x84)
    .maxstack  2
    .locals init (class [mscorlib]System.Collections.Generic.IEnumerator`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone> V_0,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> V_1,
             class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition V_2)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.TacticalFaction ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn::get_TacticalFaction()
    IL_0006:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerable`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone> ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.TacticalFaction::get_DeployZones()
    IL_000b:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>::GetEnumerator()
    IL_0010:  stloc.0
    .try
    {
      IL_0011:  br.s       IL_006f

      IL_0013:  ldloc.0
      IL_0014:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>::get_Current()
      IL_0019:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone::GetDeployConditions<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>()
      IL_001e:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::GetEnumerator()
      IL_0023:  stloc.1
      .try
      {
        IL_0024:  br.s       IL_005b

        IL_0026:  ldloc.1
        IL_0027:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::get_Current()
        IL_002c:  stloc.2
        IL_002d:  ldloc.2
        IL_002e:  ldfld      class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition::MissionData
        IL_0033:  ldfld      class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData::ActorTagDef
        IL_0038:  callvirt   instance string [UnityEngine.CoreModule]UnityEngine.Object::get_name()
        IL_003d:  ldstr      "3x3"
        IL_0042:  callvirt   instance bool [mscorlib]System.String::StartsWith(string)
        IL_0047:  brfalse.s  IL_005b

        IL_0049:  ldloc.2
        IL_004a:  ldfld      class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition::MissionData
        IL_004f:  ldfld      class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData::ActorTagDef
        IL_0054:  stsfld     class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeploymentTag
        IL_0059:  leave.s    IL_0083

        IL_005b:  ldloc.1
        IL_005c:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_0061:  brtrue.s   IL_0026

        IL_0063:  leave.s    IL_006f

      }  // end .try
      finally
      {
        IL_0065:  ldloc.1
        IL_0066:  brfalse.s  IL_006e

        IL_0068:  ldloc.1
        IL_0069:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_006e:  endfinally
      }  // end handler
      IL_006f:  ldloc.0
      IL_0070:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0075:  brtrue.s   IL_0013

      IL_0077:  leave.s    IL_0083

    }  // end .try
    finally
    {
      IL_0079:  ldloc.0
      IL_007a:  brfalse.s  IL_0082

      IL_007c:  ldloc.0
      IL_007d:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0082:  endfinally
    }  // end handler
    IL_0083:  ret
  } // end of method Mod::GetVehicleTag

  .method private hidebysig static bool  IsVehicleZone(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone zone) cil managed
  {
    // Code size       43 (0x2b)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone::GetDeployConditions<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>()
    IL_0006:  ldsfld     class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition,bool> Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9__18_0'
    IL_000b:  dup
    IL_000c:  brtrue.s   IL_0025

    IL_000e:  pop
    IL_000f:  ldsfld     class Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c' Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9'
    IL_0014:  ldftn      instance bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<IsVehicleZone>b__18_0'(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition)
    IL_001a:  newobj     instance void class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition,bool>::.ctor(object,
                                                                                                                                                                               native int)
    IL_001f:  dup
    IL_0020:  stsfld     class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition,bool> Sheepy.PhoenixPt_UnlimitedDeploy.Mod/'<>c'::'<>9__18_0'
    IL_0025:  call       bool [System.Core]System.Linq.Enumerable::Any<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                                                     class [mscorlib]System.Func`2<!!0,bool>)
    IL_002a:  ret
  } // end of method Mod::IsVehicleZone

  .method public hidebysig static void  BeforeDeployForTurn_SetPriority(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn __instance,
                                                                        class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData> ____actorDeployData) cil managed
  {
    // Code size       148 (0x94)
    .maxstack  3
    .locals init (valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData> V_0)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::IsPlayerSpawn(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn)
      IL_0006:  brtrue.s   IL_000d

      IL_0008:  leave      IL_0093

      IL_000d:  ldarg.0
      IL_000e:  call       void Sheepy.PhoenixPt_UnlimitedDeploy.Mod::GetVehicleTag(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn)
      IL_0013:  ldc.i4.0
      IL_0014:  stsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeployedCount
      IL_0019:  ldnull
      IL_001a:  stsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::artificalTags
      IL_001f:  ldarg.0
      IL_0020:  callvirt   instance class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.TacticalFaction ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn::get_TacticalFaction()
      IL_0025:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerable`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone> ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.TacticalFaction::get_DeployZones()
      IL_002a:  dup
      IL_002b:  call       int32 [System.Core]System.Linq.Enumerable::Count<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_0030:  stsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::zoneCount
      IL_0035:  ldnull
      IL_0036:  ldftn      bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::IsVehicleZone(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone)
      IL_003c:  newobj     instance void class [mscorlib]System.Func`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,bool>::.ctor(object,
                                                                                                                                                                             native int)
      IL_0041:  call       int32 [System.Core]System.Linq.Enumerable::Count<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                                                      class [mscorlib]System.Func`2<!!0,bool>)
      IL_0046:  stsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleZoneCount
      IL_004b:  ldarg.1
      IL_004c:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData>::GetEnumerator()
      IL_0051:  stloc.0
      .try
      {
        IL_0052:  br.s       IL_0070

        IL_0054:  ldloca.s   V_0
        IL_0056:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData>::get_Current()
        IL_005b:  dup
        IL_005c:  ldfld      class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef> ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData::ActorTags
        IL_0061:  ldsfld     class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeploymentTag
        IL_0066:  callvirt   instance bool class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef>::Contains(!0)
        IL_006b:  stfld      bool ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData::DeployWithPriority
        IL_0070:  ldloca.s   V_0
        IL_0072:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData>::MoveNext()
        IL_0077:  brtrue.s   IL_0054

        IL_0079:  leave.s    IL_0089

      }  // end .try
      finally
      {
        IL_007b:  ldloca.s   V_0
        IL_007d:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData>
        IL_0083:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_0088:  endfinally
      }  // end handler
      IL_0089:  leave.s    IL_0093

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_008b:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::LogError(class [mscorlib]System.Exception)
      IL_0090:  pop
      IL_0091:  leave.s    IL_0093

    }  // end handler
    IL_0093:  ret
  } // end of method Mod::BeforeDeployForTurn_SetPriority

  .method public hidebysig static void  AfterDeployForTurn_RestoreZones(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn __instance) cil managed
  {
    // Code size       111 (0x6f)
    .maxstack  2
    .locals init (valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> V_0,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> V_1)
    .try
    {
      IL_0000:  ldnull
      IL_0001:  stsfld     class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::allZones
      IL_0006:  ldsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::artificalTags
      IL_000b:  brfalse.s  IL_0015

      IL_000d:  ldarg.0
      IL_000e:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::IsPlayerSpawn(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn)
      IL_0013:  brtrue.s   IL_0017

      IL_0015:  leave.s    IL_006e

      IL_0017:  ldsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::artificalTags
      IL_001c:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<!0,!1> class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::GetEnumerator()
      IL_0021:  stloc.0
      .try
      {
        IL_0022:  br.s       IL_0045

        IL_0024:  ldloca.s   V_0
        IL_0026:  call       instance valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<!0,!1> valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::get_Current()
        IL_002b:  stloc.1
        IL_002c:  ldloca.s   V_1
        IL_002e:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::get_Key()
        IL_0033:  callvirt   instance class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.DeployCondition> ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone::get_DeployConditions()
        IL_0038:  ldloca.s   V_1
        IL_003a:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::get_Value()
        IL_003f:  callvirt   instance bool class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.DeployCondition>::Remove(!0)
        IL_0044:  pop
        IL_0045:  ldloca.s   V_0
        IL_0047:  call       instance bool valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::MoveNext()
        IL_004c:  brtrue.s   IL_0024

        IL_004e:  leave.s    IL_005e

      }  // end .try
      finally
      {
        IL_0050:  ldloca.s   V_0
        IL_0052:  constrained. valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>
        IL_0058:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_005d:  endfinally
      }  // end handler
      IL_005e:  ldnull
      IL_005f:  stsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::artificalTags
      IL_0064:  leave.s    IL_006e

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0066:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::LogError(class [mscorlib]System.Exception)
      IL_006b:  pop
      IL_006c:  leave.s    IL_006e

    }  // end handler
    IL_006e:  ret
  } // end of method Mod::AfterDeployForTurn_RestoreZones

  .method public hidebysig static void  AfterGetAllowedZonePositions_StoreZones(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn __instance,
                                                                                class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class [mscorlib]System.Collections.Generic.List`1<valuetype [UnityEngine.CoreModule]UnityEngine.Vector3>> __result) cil managed
  {
    // Code size       37 (0x25)
    .maxstack  1
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::IsPlayerSpawn(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn)
      IL_0006:  brtrue.s   IL_000a

      IL_0008:  leave.s    IL_0024

      IL_000a:  ldarg.1
      IL_000b:  callvirt   instance class [mscorlib]System.Collections.Generic.Dictionary`2/KeyCollection<!0,!1> class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class [mscorlib]System.Collections.Generic.List`1<valuetype [UnityEngine.CoreModule]UnityEngine.Vector3>>::get_Keys()
      IL_0010:  call       class [mscorlib]System.Collections.Generic.List`1<!!0> [System.Core]System.Linq.Enumerable::ToList<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_0015:  stsfld     class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::allZones
      IL_001a:  leave.s    IL_0024

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_001c:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::LogError(class [mscorlib]System.Exception)
      IL_0021:  pop
      IL_0022:  leave.s    IL_0024

    }  // end handler
    IL_0024:  ret
  } // end of method Mod::AfterGetAllowedZonePositions_StoreZones

  .method public hidebysig static void  AfterGenerateNextActorToDeploy_CheckZones(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn __instance,
                                                                                  class ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData __result) cil managed
  {
    // Code size       236 (0xec)
    .maxstack  5
    .locals init (valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone> V_0,
             class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone V_1,
             class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition V_2)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::IsPlayerSpawn(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.Missions.TacParticipantSpawn)
      IL_0006:  brfalse.s  IL_0014

      IL_0008:  ldsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleZoneCount
      IL_000d:  ldsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::zoneCount
      IL_0012:  blt.s      IL_0019

      IL_0014:  leave      IL_00eb

      IL_0019:  ldarg.1
      IL_001a:  brfalse.s  IL_002e

      IL_001c:  ldarg.1
      IL_001d:  ldfld      class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef> ['Assembly-CSharp']PhoenixPoint.Common.Levels.ActorDeployment.ActorDeployData::ActorTags
      IL_0022:  ldsfld     class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeploymentTag
      IL_0027:  callvirt   instance bool class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef>::Contains(!0)
      IL_002c:  brtrue.s   IL_0033

      IL_002e:  leave      IL_00eb

      IL_0033:  ldsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeployedCount
      IL_0038:  ldc.i4.1
      IL_0039:  add
      IL_003a:  stsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeployedCount
      IL_003f:  ldsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeployedCount
      IL_0044:  ldsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleZoneCount
      IL_0049:  sub
      IL_004a:  ldc.i4.0
      IL_004b:  bgt.s      IL_0052

      IL_004d:  leave      IL_00eb

      IL_0052:  ldsfld     class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::allZones
      IL_0057:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>::GetEnumerator()
      IL_005c:  stloc.0
      .try
      {
        IL_005d:  br.s       IL_00c8

        IL_005f:  ldloca.s   V_0
        IL_0061:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>::get_Current()
        IL_0066:  stloc.1
        IL_0067:  ldloc.1
        IL_0068:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::IsVehicleZone(class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone)
        IL_006d:  brtrue.s   IL_00c8

        IL_006f:  newobj     instance void ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition::.ctor()
        IL_0074:  dup
        IL_0075:  ldloc.1
        IL_0076:  stfld      class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.DeployCondition::DeployZone
        IL_007b:  dup
        IL_007c:  newobj     instance void ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData::.ctor()
        IL_0081:  dup
        IL_0082:  ldsfld     class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleDeploymentTag
        IL_0087:  stfld      class ['Assembly-CSharp']PhoenixPoint.Common.Entities.GameTagsTypes.ActorDeploymentTagDef ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData::ActorTagDef
        IL_008c:  stfld      class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployConditionData ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition::MissionData
        IL_0091:  stloc.2
        IL_0092:  ldloc.1
        IL_0093:  callvirt   instance class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.DeployCondition> ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone::get_DeployConditions()
        IL_0098:  ldloc.2
        IL_0099:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.DeployCondition>::Add(!0)
        IL_009e:  ldsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleZoneCount
        IL_00a3:  ldc.i4.1
        IL_00a4:  add
        IL_00a5:  stsfld     int32 Sheepy.PhoenixPt_UnlimitedDeploy.Mod::vehicleZoneCount
        IL_00aa:  ldsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::artificalTags
        IL_00af:  brtrue.s   IL_00bc

        IL_00b1:  ldc.i4.2
        IL_00b2:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::.ctor(int32)
        IL_00b7:  stsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::artificalTags
        IL_00bc:  ldsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition> Sheepy.PhoenixPt_UnlimitedDeploy.Mod::artificalTags
        IL_00c1:  ldloc.1
        IL_00c2:  ldloc.2
        IL_00c3:  callvirt   instance void class [mscorlib]System.Collections.Generic.Dictionary`2<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone,class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.MissionDeployCondition>::Add(!0,
                                                                                                                                                                                                                                                                                               !1)
        IL_00c8:  ldloca.s   V_0
        IL_00ca:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>::MoveNext()
        IL_00cf:  brtrue.s   IL_005f

        IL_00d1:  leave.s    IL_00e1

      }  // end .try
      finally
      {
        IL_00d3:  ldloca.s   V_0
        IL_00d5:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ['Assembly-CSharp']PhoenixPoint.Tactical.Levels.ActorDeployment.TacticalDeployZone>
        IL_00db:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_00e0:  endfinally
      }  // end handler
      IL_00e1:  leave.s    IL_00eb

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_00e3:  call       bool Sheepy.PhoenixPt_UnlimitedDeploy.Mod::LogError(class [mscorlib]System.Exception)
      IL_00e8:  pop
      IL_00e9:  leave.s    IL_00eb

    }  // end handler
    IL_00eb:  ret
  } // end of method Mod::AfterGenerateNextActorToDeploy_CheckZones

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Mod::.ctor

} // end of class Sheepy.PhoenixPt_UnlimitedDeploy.Mod


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file Test.res
