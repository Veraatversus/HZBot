using System.Threading.Tasks;

namespace HZBot
{
    public interface IHzPlugin
    {
        #region Properties

        HzAccount Account { get; }

        #endregion Properties

        #region Methods

        Task OnLogined();

        Task OnLogoffed();

        Task OnBotStarted();

        Task OnBotStoped();

        Task OnPrimaryWorkerDoWork();

        Task AfterPrimaryWorkerWork();

        Task BeforPrimaryWorkerWork();

        #endregion Methods
    }
}