using System.Windows;

namespace HZBot
{
    /// <summary>
    /// Interaktionslogik für ChooseCurrencyWindow.xaml
    /// </summary>
    public partial class ChooseCurrencyWindow : Window
    {
        #region Constructors

        public ChooseCurrencyWindow(HzAccount account)
        {
            InitializeComponent();
            this.account = account;
        }

        #endregion Constructors

        #region Properties

        public HzAccount Account => account;

        #endregion Properties

        #region Fields

        private readonly HzAccount account;

        #endregion Fields

        #region Methods

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion Methods
    }
}