// Copied from vset\teamfoundationserver\controls\WPF
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace CodeCoverageControlUI
{
    /// <summary>
    /// Interaction logic for Spinner.xaml
    /// </summary>
    internal partial class Spinner : UserControl
    {
        public Spinner()
        {
            InitializeComponent();
            storyboardRotate = (Storyboard)Resources["storyboardRotate"];
        }

        public void Pause()
        {
            storyboardRotate.Pause(this);
            Paused = true;
        }

        public void Resume()
        {
            storyboardRotate.Resume(this);
            Paused = false;
        }

        private void OnCanvasLoaded(object sender, RoutedEventArgs e)
        {
            storyboardRotate.Begin(this, true);
            if (Paused)
                Pause();
        }

        /// <summary>
        /// Keep track of whether the control is paused before the storyboard animation begins, since Begin() resets the state.
        /// </summary>
        private bool Paused
        {
            get;
            set;
        }

        private Storyboard storyboardRotate;
    }

    internal class CanvasScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double canvasWidthOrHeight = 120;
            double gridWidthOrHeight = (double)value;
            return gridWidthOrHeight / canvasWidthOrHeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

