using System.Windows;
using System.Windows.Input;

namespace Tokenizer.Converters
{
    public class MouseEventArgsWrapper
    {
        public MouseEventArgsWrapper(MouseEventArgs mouseEventArgs, Point point)
        {
            MouseEventArgs = mouseEventArgs;
            Point = point;
        }

        public MouseEventArgs MouseEventArgs { get; }
        public Point Point { get; }
    }
}