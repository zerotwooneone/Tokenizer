using System;

namespace Tokenizer.ViewModel
{
    public class StaticsUtil : IMathUtil
    {
        public double Min(double p1, double p2)
        {
            return Math.Min(p1, p2);
        }

        public double Max(double p1, double p2)
        {
            return Math.Max(p1, p2);
        }
    }
}