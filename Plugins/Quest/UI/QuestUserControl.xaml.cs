using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HZBot
{
    /// <summary>
    /// Interaktionslogik für QuestUserControlxaml.xaml
    /// </summary>
    public partial class QuestUserControl : HzUserControl
    {
        #region Constructors

        public QuestUserControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        private void ListView_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }
    }
}