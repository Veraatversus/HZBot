﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HZBot
{
    public class ScrollViewerCorrector

    {
        #region Fields

        public static readonly DependencyProperty FixScrollingProperty =

            DependencyProperty.RegisterAttached("FixScrolling", typeof(bool), typeof(ScrollViewerCorrector), new FrameworkPropertyMetadata(false, ScrollViewerCorrector.OnFixScrollingPropertyChanged));

        #endregion Fields

        #region Methods

        public static bool GetFixScrolling(DependencyObject obj)

        {
            return (bool)obj.GetValue(FixScrollingProperty);
        }

        public static void SetFixScrolling(DependencyObject obj, bool value)

        {
            obj.SetValue(FixScrollingProperty, value);
        }

        public static void OnFixScrollingPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)

        {
            var viewer = sender as ScrollViewer;

            if (viewer == null)

                throw new ArgumentException("The dependency property can only be attached to a ScrollViewer", "sender");

            if ((bool)e.NewValue == true)

                viewer.PreviewMouseWheel += HandlePreviewMouseWheel;
            else if ((bool)e.NewValue == false)

                viewer.PreviewMouseWheel -= HandlePreviewMouseWheel;
        }

        #endregion Methods

        private static List<MouseWheelEventArgs> _reentrantList = new List<MouseWheelEventArgs>();

        private static void HandlePreviewMouseWheel(object sender, MouseWheelEventArgs e)

        {
            var scrollControl = sender as ScrollViewer;

            if (!e.Handled && sender != null && !_reentrantList.Contains(e))

            {
                var previewEventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                previewEventArg.RoutedEvent = UIElement.PreviewMouseWheelEvent;
                previewEventArg.Source = sender;

                var originalSource = e.OriginalSource as UIElement;

                _reentrantList.Add(previewEventArg);

                originalSource.RaiseEvent(previewEventArg);

                _reentrantList.Remove(previewEventArg);

                // at this point if no one else handled the event in our children, we do our job

                if (!previewEventArg.Handled && 
                    ((e.Delta > 0 && scrollControl.VerticalOffset == 0)
                    || (e.Delta <= 0 && scrollControl.VerticalOffset >= scrollControl.ExtentHeight - scrollControl.ViewportHeight)))

                {
                    e.Handled = true;

                    var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                    {

                        RoutedEvent = UIElement.MouseWheelEvent,

                        Source = sender
                    };

                    // var parent = (UIElement)((FrameworkElement)sender).Parent;

                    //(sender as UIElement).RaiseEvent(eventArg);
                    FindParent<ScrollViewer>(sender as FrameworkElement)?.RaiseEvent(eventArg);
                }
            }
        }

        public static T FindParent<T>(DependencyObject child)
   where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
    }
}