using System.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public class CharacterStatPlugin : HzPluginBase
    {
        #region Constructors

        public CharacterStatPlugin(HzAccount account) : base(account)
        {
            ImproveCharacterStatCommand = new AsyncRelayCommand<CharacterStat>(
                async stat => await this.ImproveCharacterStatAsync(stat.StatType),
                stat => Account.Character?.CanImproveCharacterStat() ?? false);

            TrainCharacterStatCommand = new AsyncRelayCommand<CharacterStat>(
                async (stat) => await this.StartTrainingAsync(stat.StatType),
                (stat) => Account.ActiveWorker == null && (Account.Character?.CanTrain() ?? false));
        }

        #endregion Constructors

        #region Properties

        public bool IsAutoTrain { get; set; }
        public bool IsAutoSkill { get; set; }
        public AsyncRelayCommand<CharacterStat> ImproveCharacterStatCommand { get; private set; }

        //Train Stats Commands
        public AsyncRelayCommand<CharacterStat> TrainCharacterStatCommand { get; private set; }

        #endregion Properties

        #region Methods

        public async override Task OnPrimaryWorkerComplete()
        {
            // IsAutoSkill
            if (IsAutoSkill && Account.Character.CanImproveCharacterStat())
            {
                var trainCount = Account.Character.stat_points_available;
                for (int i = 0; i < trainCount; i++)
                {
                    await ImproveCharacterStatCommand.TryExecuteAsync(Account.Character.GetNextImroveStat());
                }
            }

            // IsAutoTrain
            if (IsAutoTrain && Account.Character.CanTrain() && Account.ActiveWorker == null)
            {
                var trainStat = Account.Character.Stats.FirstOrDefault(stat => stat.TrainingValue > 0) ?? Account.Character.GetNextImroveStat();
                if (trainStat != null)
                {
                    await TrainCharacterStatCommand.TryExecuteAsync(trainStat);
                    Account.Log.Add($"[TRAINING] START: TrainStat:{trainStat.StatType}");
                }
            }
        }

        #endregion Methods
    }
}