﻿namespace HZBot
{
    /// <summary>
    /// Config Extension Methods
    /// </summary>
    public static class ConFigExtensions
    {
        #region Methods

        public static HzConfig Config(this HzServiceBase service)
        {
            return service.Account.Config;
        }

        #endregion Methods
    }

    /// <summary>
    /// The Config who stores and saves the data
    /// </summary>
    /// <seealso cref="HZBot.HzServiceBase" />
    public class HzConfig : ViewModelBase
    {
        #region Properties

        public static string FilePath { get; } = "accs.json";

        //Account
        public string Username { get => username; set { username = value; RaisePropertyChanged(); } }

        public string Password { get => password; set { password = value; RaisePropertyChanged(); } }
        public int FlashVersion { get; set; } = 147;
        public int ServerId { get; set; } = 16;
        public string ClientID { get; set; } = "s151510585613";
        public bool IsAutoLogin { get; set; }
        public bool IsAutoStartBot { get => isAutoStartBot; set { isAutoStartBot = value; RaisePropertyChanged(); } }

        // Quest Plugin
        public QuestMode QuestMode { get; set; } = QuestMode.Balanced;

        public BuyEnergyMode BuyEnergyMode { get; set; }
        public FightQuestDifficulty QuestDifficulty { get; set; } = FightQuestDifficulty.Medium;
        public bool IsAutoQuest { get => isAutoQuest; set { isAutoQuest = value; RaisePropertyChanged(); } }

        //Item Plugin
        public bool IsAutoEquip { get; set; }

        public SellMode SellMode { get; set; }
        public double StaminaEquipWeight { get; set; } = 0.5f;
        public double StrengthEquipWeight { get; set; } = 0.2f;
        public double CriticalRatingEquipWeight { get; set; } = 1;
        public double DodgeRatingEquipWeight { get; set; } = 1;
        public double WeaponDamageEquipWeight { get; set; } = 2;
        public double MissileDamageEquipWeight { get; set; } = 1;

        //HideOutPlugin
        public bool IsAutoHideOutCollect { get; set; } = true;
        public bool IsAutoHideOutUpgrade { get; set; } = true;
        public bool IsAutoHideOutBuild { get; set; } = true;

        //Duel Plugin
        public bool IsAutoDuel { get; set; } = true;

        //CharacterStat Plugin
        public bool IsAutoTrain { get => isAutoTrain; set { isAutoTrain = value; RaisePropertyChanged(); } }

        public bool IsAutoSkill { get => isAutoSkill; set { isAutoSkill = value; RaisePropertyChanged(); } }
        public double StaminaSkillWeight { get; set; } = 0.1;
        public double StrengthSkillWeight { get; set; } = 0.2;
        public double CriticalRatingSkillWeight { get; set; } = 0.35;
        public double DodgeRatingSkillWeight { get; set; } = 0.35;

        //Worldboss
        public bool IsAutoAttackWorldboss { get; set; } = true;

        //Booster
        public bool IsAutoABooster { get; set; } = true;

        public int WorkBooster { get; set; } = 25;
        public int StatsBooster { get; set; } = 25;
        public int MissionBooster { get; set; } = 50;

        //Goals
        public bool IsAutoGoal { get; set; } = true;

        #endregion Properties

        #region Fields

        private bool isAutoQuest;
        private string username;
        private string password;
        private bool isAutoTrain;
        private bool isAutoSkill;
        private bool isAutoStartBot;

        #endregion Fields
    }
}