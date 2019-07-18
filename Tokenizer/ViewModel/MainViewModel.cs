using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Tokenizer.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            
            Image = new BitmapImage(new Uri("Resources/test.png", UriKind.Relative));
            MouseDownCommand = new RelayCommand<MouseEventArgs>(OnMouseDown);
        }

        private void OnMouseDown(MouseEventArgs e)
        {
            int x = 0;
        }

        public BitmapImage Image { get; }
        public RelayCommand<MouseEventArgs> MouseDownCommand {get;}
        public double PanelX { get; set; }
        public double PanelY { get; set; }
    }
}