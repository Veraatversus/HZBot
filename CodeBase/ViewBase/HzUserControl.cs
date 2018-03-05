using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace HZBot
{
    public class HzUserControl : UserControl, INotifyPropertyChanged
    {
        #region Fields

        // Using a DependencyProperty as the backing store for Account.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountProperty =
            DependencyProperty.Register(nameof(Account), typeof(HzAccount), typeof(HzUserControl), new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Account = DataContext as HzAccount;
        }

        #endregion Fields

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public HzAccount Account
        {
            get { return (HzAccount)GetValue(AccountProperty); }
            set { SetValue(AccountProperty, value); }
        }

        #endregion Properties

        #region Methods

        public void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion Methods
    }
}