namespace HZBot
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
        public double StaminaWeight { get; set; } = 0.5f;
        public double StrengthWeight { get; set; } = 0.2f;
        public double CriticalRatingWeight { get; set; } = 1;
        public double DodgeRatingWeight { get; set; } = 1;
        public double WeaponDamageWeight { get; set; } = 2;
        public double MissileDamageWeight { get; set; } = 1;

        //HideOutPlugin
        public bool IsAutoHideOutCollect { get; set; }
        public bool IsAutoHideOutBuild { get; set; }

        //Duel Plugin
        public bool IsAutoDuel { get; set; }

        //CharacterStat Plugin
        public bool IsAutoTrain { get => isAutoTrain; set { isAutoTrain = value; RaisePropertyChanged(); } }
        public bool IsAutoSkill { get => isAutoSkill; set { isAutoSkill = value; RaisePropertyChanged(); } }

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