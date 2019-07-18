using System;
using GalaSoft.MvvmLight;

namespace Tokenizer.ViewModel
{
    public class RectangleViewmodel : ViewModelBase
    {
        private const double DoubleTolerance = .001;
        private double _left;
        private double _top;
        private double _width;
        private double _height;


        public double Left
        {
            get => _left;
            set
            {
                if (Math.Abs(_left - value) > DoubleTolerance)
                {
                    _left = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double Top
        {
            get => _top;
            set
            {
                if (Math.Abs(_top - value) > DoubleTolerance)
                {
                    _top = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                if (Math.Abs(_width - value) > DoubleTolerance)
                {
                    _width = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (Math.Abs(_height - value) > DoubleTolerance)
                {
                    _height = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}