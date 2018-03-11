using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace HZBot
{
    public class HzUserControl : UserControl, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public HzAccount Account => DataContext as HzAccount;

        #endregion Properties

        #region Methods

        public void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion Methods
    }
}