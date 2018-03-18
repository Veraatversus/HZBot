﻿using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
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
            CommandBinding cb = new CommandBinding(ApplicationCommands.Copy, CopyCmdExecuted, CopyCmdCanExecute);

            this.LogListBox.CommandBindings.Add(cb);
        }

        #endregion Constructors

        void CopyCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            System.Windows.Controls.ListBox lb = e.OriginalSource as System.Windows.Controls.ListBox;
            string copyContent = String.Empty;

            foreach (var item in lb.SelectedItems.OfType<LogObject>())
            {
                copyContent += item.Text;
                copyContent += Environment.NewLine;
            }
            Clipboard.SetText(copyContent);
        }
        void CopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            System.Windows.Controls.ListBox lb = e.OriginalSource as System.Windows.Controls.ListBox;

            if (lb.SelectedItems.Count > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }
    }
}