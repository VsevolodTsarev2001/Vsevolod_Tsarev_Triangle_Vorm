using System;

namespace Tringle
{
    [Serializable]
    public class Triangle
    {
        public double A;
        public double B;
        public double C;

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Triangle(double s, double a)
        {
            // This constructor is unused; you might consider removing it
            A = a;
        }

        public Triangle() { }

        public bool ExistTriangle
        {
            get
            {
                return A + B > C && A + C > B && B + C > A;
            }
        }

        public double GetSetA
        {
            get { return A; }
            set { A = value; }
        }
        public double GetSetB
        {
            get { return B; }
            set { B = value; }
        }
        public double GetSetC
        {
            get { return C; }
            set { C = value; }
        }

        public string TriangleType
        {
            get
            {
                if (ExistTriangle)
                {
                    if (A == B && B == C)
                    {
                        return "võrdne";
                    }
                    else if (A == B || A == C || B == C)
                    {
                        return "võrdhaarne";
                    }
                    else
                    {
                        return "erikülgne";
                    }
                }
                else
                {
                    return "tundmatu tüüp";
                }
            }
        }

        public double Perimeter()
        {
            return A + B + C;
        }

        public double Area()
        {
            if (ExistTriangle)
            {
                double p = Perimeter() / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
            return 0;
        }
    }
}
