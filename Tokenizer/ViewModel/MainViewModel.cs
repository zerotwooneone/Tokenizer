using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Tokenizer.Converters;

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
        private readonly IMathUtil _mathUtil;
        private RectangleViewmodel _rectangle;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IMathUtil mathUtil)
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
            MouseDownCommand = new RelayCommand<MouseEventArgsWrapper>(OnMouseDown);
            MouseUpCommand = new RelayCommand<MouseEventArgsWrapper>(OnMouseUp);
            MouseMoveCommand = new RelayCommand<MouseEventArgsWrapper>(OnMouseMove);
            SizeChangedCommand = new RelayCommand<SizeChangedEventArgs>(OnSizeChanged);
            Rectangle = null;
            _mathUtil = mathUtil;
        }

        private void OnSizeChanged(SizeChangedEventArgs obj)
        {
            var imageHeight = Image.Height / 2;
            var imageWidth = Image.Width / 2;

            var canvasHeight = obj.NewSize.Height / 2;
            var canvasWidth = obj.NewSize.Width / 2;

            ImageLeft = canvasWidth - imageWidth;
            ImageTop = canvasHeight - imageHeight;
        }

        private void OnMouseMove(MouseEventArgsWrapper obj)
        {
            if(obj.MouseEventArgs.LeftButton == MouseButtonState.Released || Rectangle == null) return;
            
            var x = _mathUtil.Min(obj.Point.X, Rectangle.Left);
            var y = _mathUtil.Min(obj.Point.Y, Rectangle.Top);

            Rectangle.Left = x;
            Rectangle.Top = y;

            var w = _mathUtil.Max(obj.Point.X, Rectangle.Left) - x;
            var h = _mathUtil.Max(obj.Point.Y, Rectangle.Top) - y;

            Rectangle.Width = w;
            Rectangle.Height = h;
        }

        private void OnMouseUp(MouseEventArgsWrapper obj)
        {
            if (obj.MouseEventArgs.LeftButton == MouseButtonState.Released)
            {
                Rectangle = null;
            }
        }

        private void OnMouseDown(MouseEventArgsWrapper obj)
        {
            if (obj.MouseEventArgs.LeftButton == MouseButtonState.Pressed)
            {
                Rectangle = new RectangleViewmodel
                {
                    Left = obj.Point.X,
                    Top = obj.Point.Y
                };
            }
        }

        public BitmapImage Image { get; }
        public RelayCommand<MouseEventArgsWrapper> MouseDownCommand {get;}
        public RelayCommand<MouseEventArgsWrapper> MouseUpCommand {get;}
        public RelayCommand<MouseEventArgsWrapper> MouseMoveCommand {get;}
        public RectangleViewmodel Rectangle
        {
            get => _rectangle;
            set 
            {
                if (_rectangle != value)
                {
                    _rectangle = value;
                    RaisePropertyChanged();
                }
            }
        }

        public RelayCommand<SizeChangedEventArgs> SizeChangedCommand { get; }

        private double _ImageLeft;
        public double ImageLeft
        {
            get { return _ImageLeft; }
            set
            {
                if (_ImageLeft != value)
                {
                    _ImageLeft = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double _ImageTop;
        public double ImageTop
        {
            get { return _ImageTop; }
            set
            {
                if (_ImageTop != value)
                {
                    _ImageTop = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}