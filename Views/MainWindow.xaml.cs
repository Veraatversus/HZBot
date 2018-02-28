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
            //Kann nicht schreiben im steam komme aber gleich dc war eben noch im Film
        }

        #endregion Constructors

        #region Methods

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource jsonRootViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("jsonRootViewSource")));
            // Laden Sie Daten durch Festlegen der CollectionViewSource.Source-Eigenschaft:
            // jsonRootViewSource.Source = [generische Datenquelle]
        }

        #endregion Methods
    }
}