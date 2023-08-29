﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    internal class Program
    {
        static bool IsSimplified(int numerator, int denominator)
        {
            for (int i = 2; i <= numerator; ++i)
            {
                if (denominator % i == 0 && numerator % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private class Fraction
        {
            private int numerator;
            private int denominator;

            public Fraction(int numerator, int denominator) 
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
            public double Value 
            { 
                get 
                { 
                    if (denominator == 0) 
                    {
                        return 0.0;
                    }

                    return (double)numerator / denominator; 
                }
            }
            public string Display
            {
                get
                {
                    if (denominator == 0)
                    {
                        return "--";
                    }
                    return String.Format("{0}/{1}", numerator, denominator);
                }
            }
        }

        private class FractionSorterByValue: IComparer<Fraction>
        {
            public int Compare(Fraction c1, Fraction c2)
            {
                return c1.Value.CompareTo(c2.Value);
            }
        }

        static void Main(string[] args)
        {
            List<Fraction> list = new List<Fraction>();
            list.Add(new Fraction(0, 0));
            int minDenominator = int.Parse(args[0]);
            int maxDenominator = int.Parse(args[1]);
            for (int denominator = minDenominator; denominator <= maxDenominator; denominator++) 
            { 
                for (int numerator = 1; numerator < denominator; ++numerator)
                {
                    if (IsSimplified(numerator, denominator)) 
                    {
                        list.Add(new Fraction(numerator, denominator));
                    }
                }
            }
            list.Sort(new FractionSorterByValue());
            Console.WriteLine("    var FractionsList = \n    [");
            foreach (Fraction fraction in list)
            {
                Console.WriteLine("      [\"{0}\", {1}],", fraction.Display, fraction.Value);
            }
            Console.WriteLine("    ];");
            Console.WriteLine("    var FractionsCount = {0};", list.Count);
        }
    }
}
