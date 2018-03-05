using System.ComponentModel;
using System.Windows;

namespace HZBot
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(HzAccount account)
        {
            Account = account;
            DataContext = Account;
            InitializeComponent();
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public HzAccount Account
        {
            get { return (HzAccount)GetValue(AccountProperty); }
            set { SetValue(AccountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Account.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountProperty =
            DependencyProperty.Register(nameof(Account), typeof(HzAccount), typeof(MainWindow), new PropertyMetadata(null));

        //public HzAccount Account
        //{
        //    get { return account; }
        //    set { account = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Account))); }
        //}

        #endregion Properties

        #region Fields

        // private HzAccount account;

        #endregion Fields
    }
}