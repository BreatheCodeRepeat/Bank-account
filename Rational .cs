using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuportLaborator_11
{
    class Rational
    {
        private int divisor;
        private int dividend;

        public Rational(int dividend)
        {
            this.dividend = dividend;
            this.divisor = 1;
        }
        public Rational(int dividend, int divisor)
        {
            this.dividend = dividend;
            this.divisor = divisor;

        }

        public static bool operator ==(Rational a,Rational b)
        {
            return a.divisor * b.dividend == b.divisor * a.dividend;
        }
        public static bool operator !=(Rational a, Rational b)
        {
            return !(a == b);
        }

        public override bool Equals(Object a)
        {
            if (a is Rational)
            {
                return this == (Rational)a;
            }
            return false;

        }
        public static bool operator <(Rational a, Rational b)
        {
            if (a.dividend * b.divisor < b.dividend * a.divisor) return false;
            return true;
        }
        public static bool operator >(Rational a, Rational b)
        {
            return !(a < b);
        }
        
    }
}
