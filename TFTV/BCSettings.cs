using System.Collections.Generic;

namespace PRMBetterClasses
{
    public class BCSettings
    {
        // Dictionary of special Characters identified by their name to give them a special skill set on the 3rd row (personal perk row)
        // The string key for the outer dictionary is the name of the character
        // The int key of the inner dictionary (value of the outer dictionary) is the level spot where the ability should get on
        // The string value of the inner dictionagy is finally the ability def name of the skill
        public Dictionary<string, Dictionary<int, string>> SpecialCharacterPersonalSkills = new Dictionary<string, Dictionary<int, string>>();

        public Dictionary<string, float> BuffsForAdditionalProficiency = new Dictionary<string, float>
        {
            { Proficiency.Buff, 0.0f }
        };
        public List<ClassSpecDef> ClassSpecializations = new List<ClassSpecDef>
        {
            new ClassSpecDef(
                classDef: ClassKeys.Assault,
                mainSpec: new string[]
                {
                    "",
                    "QUICK AIM",
                    "KILL'N'RUN",
                    "",
                    "READY FOR ACTION",
                    "ONSLAUGHT",
                    "RAPID CLEARANCE"
                }),
            new ClassSpecDef(
                classDef: ClassKeys.Heavy,
                mainSpec: new string[]
                {
                    "",
                    "RETURN FIRE",
                    "HUNKER DOWN",
                    "",
                    "SKIRMISHER",
                    "SHRED RESISTANCE",
                    "RAGE BURST"
                }),
            new ClassSpecDef(
                classDef: ClassKeys.Sniper,
                mainSpec: new string[]
                {
                    "",
                    "EXTREME FOCUS",
                    "ARMOR BREAK", // ARMOR BREAK
                    "",
                    "MASTER MARKSMAN",
                    "INSPIRE",
                    "MARKED FOR DEATH"
                }),
            new ClassSpecDef(
                classDef: ClassKeys.Berserker,
                mainSpec: new string[]
                {
                    "",
                    "DASH",
                    "CLOSE QUARTERS EVADE",
                    "",
                    "BLOODLUST",
                    "IGNORE PAIN",
                    "ADRENALINE RUSH"
                }),
            new ClassSpecDef(
                classDef: ClassKeys.Priest,
                mainSpec: new string[]
                {
                    "",
                    "MIND CONTROL",
                    "INDUCE PANIC",
                    "",
                    "MIND SENSE",
                    "PSYCHIC WARD",
                    "MIND CRUSH"
                }),
            new ClassSpecDef(
                classDef: ClassKeys.Technician,
                mainSpec: new string[]
                {
                    "",
                    "FAST USE",
                    "ELECTRIC REINFORCEMENT",
                    "",
                    "STABILITY",
                    "FIELD MEDIC",
                    "AMPLIFY PAIN"
                }),
            new ClassSpecDef(
                classDef: ClassKeys.Infiltrator,
                mainSpec: new string[]
                {
                    "",
                    "SURPRISE ATTACK",
                    "DEPLOY DECOY",
                    "",
                    "NEURAL FEEDBACK", // NEURAL FEEDBACK
                    "JAMMING FIELD", // JAMMING FIELD
                    "PARAPSYCHOSIS" // PARAPSYCHOSIS ex SNEAK ATTACK
                }),
        };
        public string[] OrderOfPersonalPerks = new string[]
        {
                PerkType.Background,
                PerkType.Faction_1,
                PerkType.Class_1,
                PerkType.Proficiency,
                PerkType.Background,
                PerkType.Class_2,
                PerkType.Faction_2,
        };
        public List<PersonalPerksDef> PersonalPerks = new List<PersonalPerksDef>()
        {   new PersonalPerksDef(
                key: PerkType.Background,
                //isRandom: true,
                spc: 10,
                rngList: new List<string>
                {
                    "SURVIVOR",
                    "NURSE",
                    "SCAV",
                    "CORPSE DISPOSER",
                    "HARD LABOR",
                    "SQUATTER",
                    "VOLUNTEERED",
                    "CONDO RAIDER",
                    "TUNNEL RAT",
                    "HUNTER",
                    "TROUBLEMAKER",
                    "PARANOID",
                    "PRIVILEGED",
                    "A HISTORY OF VIOLENCE",
                    "DAREDEVIL",
                    "DAMAGED AMYGDALA",
                    "SANITATION EXPERT",
                    "LAB ASSISTANT",
                    "ROCKETEER",
                    "TRUE GRIT"
                }),
            new PersonalPerksDef(
                key: PerkType.Proficiency,
                //isRandom: true,
                spc: 15,
                rngList: new List<string>
                {
                    "HANDGUN PROFICIENCY",
                    "PDW PROFICIENCY",
                    "MELEE WEAPON PROFICIENCY",
                    "ASSAULT RIFLE PROFICIENCY",
                    "SHOTGUN PROFICIENCY",
                    "SNIPER RIFLE PROFICIENCY",
                    "HEAVY WEAPON PROFICIENCY",
                    //"MOUNTED WEAPON PROFICIENCY"
                }),
            new PersonalPerksDef(
                perkKey: PerkType.Class_1,
                isRandom: true,
                spCost: 20,
                perkDict: new Dictionary<string, Dictionary<string, List<string>>>
                {{ FactionKeys.All, new Dictionary<string, List<string>> {
                    { ClassKeys.Assault.Name, new List<string> { "QUARTERBACK", "KILL'N'RUN" } },
                    { ClassKeys.Heavy.Name, new List<string> { "JETPACK CONTROL", "HUNKER DOWN", "SHRED RESISTANCE", "ENTRENCH", "DRUM MAGAZINE" } },
                    { ClassKeys.Sniper.Name, new List<string> { "GUNSLINGER", "KILL ZONE" } },
                    { ClassKeys.Berserker.Name, new List<string> { "GUN KATA", "EXERTION", "KILLER INSTINCT" } },
                    { ClassKeys.Priest.Name, new List<string> { "BIOCHEMIST", "LAY WASTE" } },
                    { ClassKeys.Technician.Name, new List<string> { "REMOTE DEPLOYMENT", "STABILITY", "AMPLIFY PAIN" } },
                    { ClassKeys.Infiltrator.Name, new List<string> { "VANISH", "NEURAL FEEDBACK", "JAMMING FIELD", "PARAPSYCHOSIS" } }
                } } }),
            new PersonalPerksDef(
                perkKey: PerkType.Class_2,
                isRandom: true,
                spCost: 20,
                perkDict: new Dictionary<string, Dictionary<string, List<string>>>
                {{ FactionKeys.All, new Dictionary<string, List<string>> {
                    { ClassKeys.Assault.Name, new List<string> { "AIMED BURST", "KILL'N'RUN", "SUPPRESSION" } },
                    { ClassKeys.Heavy.Name, new List<string> { "BOOM BLAST", "SKIRMISHER", "HUNKER DOWN", "ENTRENCH", "SUPPRESSIVE OVERWATCH" } },
                    { ClassKeys.Sniper.Name, new List<string> { "KILL ZONE", "GUNSLINGER" } },
                    { ClassKeys.Berserker.Name, new List<string> { "KILLER INSTINCT", "GUN KATA" } },
                    { ClassKeys.Priest.Name, new List<string> { "LAY WASTE", "BIOCHEMIST" } },
                    { ClassKeys.Technician.Name, new List<string> { "REMOTE CONTROL", "STABILITY", "AMPLIFY PAIN" } },
                    { ClassKeys.Infiltrator.Name, new List<string> { "SPIDER DRONE PACK", "PARAPSYCHOSIS", "VANISH", "VEIL OF SHADOWS" } }
                } } }),
            new PersonalPerksDef(
                perkKey: PerkType.Faction_1,
                isRandom: true,
                spCost: 15,
                perkDict: new Dictionary<string, Dictionary<string, List<string>>>
                {
                    { FactionKeys.PX, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "DIE HARD", "OVERWATCH FOCUS", "TAKEDOWN" } }
                    } },
                    { FactionKeys.Anu, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "BREATHE MIST" } }
                    } },
                    { FactionKeys.NJ, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "TAKEDOWN" } }
                    } },
                    { FactionKeys.Syn, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "OVERWATCH FOCUS", "ENDURANCE" } }
                    } },
                    { FactionKeys.IN, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "BREATHE MIST", "TAKEDOWN", "OVERWATCH FOCUS" } }
                    } },
                    { FactionKeys.PU, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "PUNISHER", "AR TARGETING", "TAKEDOWN" } }
                    } },
                    { FactionKeys.FS, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "BREATHE MIST", "SOWER OF CHANGE" } }
                    } },
                }),
            new PersonalPerksDef(
                perkKey: PerkType.Faction_2,
                isRandom: true,
                spCost: 20,
                perkDict: new Dictionary<string, Dictionary<string, List<string>>>
                {
                    { FactionKeys.PX, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "BATTLE HARDENED" } }
                    } },
                    { FactionKeys.Anu, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "SOWER OF CHANGE", "RESURRECT" } }
                    } },
                    { FactionKeys.NJ, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "PUNISHER", "AR TARGETING" } }
                    } },
                    { FactionKeys.Syn, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "ENDURANCE", "SABOTEUR" } }
                    } },
                    { FactionKeys.IN, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "SOWER OF CHANGE", "PUNISHER", "ENDURANCE" } }
                    } },
                    { FactionKeys.PU, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "PUNISHER", "AR TARGETING" } }
                    } },
                    { FactionKeys.FS, new Dictionary<string, List<string>>
                    {
                        { ClassKeys.AllClasses.Name, new List<string> { "SOWER OF CHANGE" } }
                    } },
                })
        };

        // Exclusion map for random distributed skills
        public Dictionary<string, List<string>> RadomSkillExclusionMap = new Dictionary<string, List<string>>
        {
            { "HANDGUN PROFICIENCY", new List<string> { ClassKeys.Sniper.Name, ClassKeys.Berserker.Name } },
            { "PDW PROFICIENCY", new List<string> { ClassKeys.Technician.Name } },
            { "MELEE WEAPON PROFICIENCY", new List<string> { ClassKeys.Berserker.Name } },
            { "ASSAULT RIFLE PROFICIENCY", new List<string> { ClassKeys.Assault.Name } },
            { "SHOTGUN PROFICIENCY", new List<string> { ClassKeys.Assault.Name } },
            { "SNIPER RIFLE PROFICIENCY", new List<string> { ClassKeys.Sniper.Name } },
            { "HEAVY WEAPON PROFICIENCY", new List<string> { ClassKeys.Heavy.Name } },
            { "MOUNTED WEAPON PROFICIENCY", new List<string> { ClassKeys.Heavy.Name } },
            { Proficiency.VW, new List<string> { ClassKeys.Priest.Name } },
            { Proficiency.SW, new List<string> { ClassKeys.Infiltrator.Name } },
            { "ROCKETEER", new List<string> { ClassKeys.Heavy.Name } },
            { "DAMAGED AMYGDALA", new List<string> { ClassKeys.Priest.Name } },
            { "STEALTH SPECIALIST", new List<string> { ClassKeys.Infiltrator.Name } }
        };

        // Learn the first personal ability = is set rigth from the start
      //  public bool LearnFirstPersonalSkill = true;


        /// <summary>
        /// commented out BCSettings that are set in TFTV Settings (auto standby + learn first personal skill), 
        /// plus removed crossbow ammo settings and activate story rework because no longer used. - Voland
        /// </summary>
        // Deactivate auto standy in tactical missions
     //   public bool DeactivateTacticalAutoStandby = false;

        // Activate story rework
       // public bool ActivateStoryRework = false;

        // Infiltrator Crossbow Ammo changes
      //  public int BaseCrossbow_Ammo = 6;
      //  public int VenomCrossbow_Ammo = 4;

        // Flag if UI texts should be changed to default (Enlish) text or set by localization
        public bool DoNotLocalizeChangedTexts = true;
        // Create new ability dictionary as json file in mod directory
        internal bool CreateNewJsonFiles = false;
        // DebugLevel (0: nothing, 1: error, 2: debug, 3: info)
        public int Debug = 1;
    }
}
