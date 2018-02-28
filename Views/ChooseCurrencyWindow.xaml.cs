using System.Windows;

namespace HZBot
{
    /// <summary>
    /// Interaktionslogik für ChooseCurrencyWindow.xaml
    /// </summary>
    public partial class ChooseCurrencyWindow : Window
    {
        #region Constructors

        public ChooseCurrencyWindow(Data data)
        {
            this.data = data;
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public Data data { get; private set; }

        #endregion Properties

        #region Methods

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion Methods
    }
}