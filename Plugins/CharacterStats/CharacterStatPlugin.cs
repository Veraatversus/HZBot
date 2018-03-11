using System.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public class CharacterStatPlugin : HzPluginBase
    {
        #region Constructors

        public CharacterStatPlugin(HzAccount account) : base(account)
        {
            ImproveCharacterStatCommand = new AsyncRelayCommand<HzCharacterStat>(
                async stat => await this.ImproveCharacterStatAsync(stat.StatType),
                stat => Account.Character?.HzStats.CanImproveCharacterStat(stat) ?? false);

            TrainCharacterStatCommand = new AsyncRelayCommand<HzCharacterStat>(
                async (stat) => await this.StartTrainingAsync(stat.StatType),
                (stat) => Account.ActiveWorker == null && (Account.Character?.HzStats.CanTrain(stat) ?? false));
        }

        #endregion Constructors

        #region Properties

        public AsyncRelayCommand<HzCharacterStat> ImproveCharacterStatCommand { get; private set; }

        //Train Stats Commands
        public AsyncRelayCommand<HzCharacterStat> TrainCharacterStatCommand { get; private set; }

        #endregion Properties

        #region Methods

        public async override Task OnPrimaryWorkerDoWork()
        {
            // IsAutoSkill
            if (Account.Config.IsAutoSkill)
            {
                var trainCount = Account.Character.stat_points_available;
                for (int i = 0; i < trainCount; i++)
                {
                    var stat = Account.Character.HzStats.GetNextImroveStat();
                    await ImproveCharacterStatCommand.TryExecuteAsync(stat);
                }
            }

            // IsAutoTrain
            if (Account.Config.IsAutoTrain && Account.ActiveWorker == null)
            {
                var trainStat = Account.Character.HzStats.TrainStats.FirstOrDefault(stat => stat.TrainingValue > 0) ?? Account.Character.HzStats.GetNextImroveStat();
                if (Account.Character.HzStats.CanTrain(trainStat))
                {
                    await TrainCharacterStatCommand.TryExecuteAsync(trainStat);
                }
            }
        }

        #endregion Methods
    }
}