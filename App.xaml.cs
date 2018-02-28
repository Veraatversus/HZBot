using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;

namespace HZBot
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var configFilePath = "config.json";
            JObject config = null;
            if (File.Exists(configFilePath))
            {
                config = JObject.Parse(File.ReadAllText(configFilePath));
            }
            var account = config?["account"] != null ? config?["account"].ToObject<HzAccount>() : new HzAccount();
            var window = new MainWindow { Account = account };

            window.Show();
        }

        #endregion Methods
    }
}