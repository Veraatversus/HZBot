using System.ComponentModel;
using System.Windows;

namespace HZBot
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public HzAccount Account
        {
            get { return account; }
            set { account = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Account))); }
        }

        #endregion Properties

        #region Fields

        private HzAccount account;

        #endregion Fields
    }
}