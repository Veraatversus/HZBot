using System.Threading.Tasks;

namespace HZBot
{
    public interface IHzPlugin
    {
        #region Properties

        HzAccount Account { get; set; }

        #endregion Properties

        #region Methods

        Task OnLogined();

        Task OnLogoffed();

        Task OnPrimaryWorkerComplete();

        Task OnBotStarted();

        Task OnBotStoped();

        #endregion Methods
    }
}