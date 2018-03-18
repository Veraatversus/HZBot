using System;
using System.Windows;
using System.Windows.Input;

namespace HZBot
{
    /// <summary>
    /// Interaktionslogik für LogUserControl.xaml
    /// </summary>
    public partial class LogUserControl : HzUserControl
    {
        #region Constructors

        public LogUserControl()
        {
            InitializeComponent();
            var cb = new CommandBinding(ApplicationCommands.Copy, CopyCmdExecuted, CopyCmdCanExecute);

            this.LogListBox.CommandBindings.Add(cb);
        }

        #endregion Constructors

        #region Methods

        private void CopyCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            var lb = e.OriginalSource as System.Windows.Controls.ListBox;
            var copyContent = String.Empty;

            foreach (var item in lb.SelectedItems)
            {
                //string.Format("{0:00}:{1:00}:{2:00}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) + " - " + item.Text;
                copyContent += item.ToString();
                copyContent += Environment.NewLine;
            }
            Clipboard.SetText(copyContent);
        }

        private void CopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var lb = e.OriginalSource as System.Windows.Controls.ListBox;

            if (lb.SelectedItems.Count > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        #endregion Methods
    }
}