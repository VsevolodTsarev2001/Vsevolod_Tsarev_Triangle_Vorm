using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_Vorm
{
    public class Triangle
    {
        public double a; // первая сторона
        public double b; // вторая сторона
        public double c; // третья сторона
        public double ha; // высота проведенная к стороне а 
        public Triangle(double A, double B, double C) // Конструктор
        {
            a = A; // создаем с заданными длинами сторон согласно заданию
            b = B;
            c = C;
        }
        public Triangle() // Конструктор, создаст треугольник без указания переметров треугольника
        {
        }
        public Triangle(double A, double HA) // Конструктор, позволит создать треугольник с указанием основания и высоты проведенной к нему
        {
            a = A; // основание треугольника
            ha = HA;// высота, проведенная к основанию
        }






        public double SurfaceAHA() //метод для нахождения площади, если теругольник создан при помощи конструктора public Triangle(double A, double HA) 
        {
            double s = (1 / 2) * a * ha;
            return s;
        }
        public double GetSetA // свойство позволяющее установить либо изменить значение стороны а
        {
            get // устанавливаем...
            {return a;}
            set // меняем...
            {a = value;}
        }
        public double GetSetB // свойство позволяющее установить либо изменить значение стороны b
        {
            get
            {return b;}
            set
            {b = value;}
        }
        public double GetSetC // свойство позволяющее установить либо изменить значение стороны c
        {
            get
            {return c;}
            set
            {c = value;}
        }
        public bool ExistTriangle // свойство позволяющее установить, существует ли треугольник с заданыыми сторонами
        {
            get
            {
                if ((a < b + c) && (b < a + c) && (c < a + b))//сумма 2 сторон должна быть больше третьей
                return true;
                else return false;
            }
        }
        public string TriangleType // свойство позволяющее установить, существует ли треугольник с заданыыми сторонами
        {
            get
            {
                if (ExistTriangle)
                {
                     if (a == b && a == c && b == c)//
                        return "равносторонний";
                     else if (a == b || a == c || b == c)
                        return "равнобедренный";
                     else 
                        return "разносторонний";
                }
                else
                {
                    return "ломаная";
                }
                
                    
                
            }
        }

        public string outputA() // выводим сторону а, данный метод возвращает строковое значение (атрибут string)
        {
            return Convert.ToString(a); // a - ссылка на внутреннее поле объекта класса
        }
        public string outputB()
        {
            return Convert.ToString(b); // выводим сторону b
        }
        public string outputC() // выводим сторону с
        {
            return Convert.ToString(c);
        }
        public double Perimeter() // сумма всех сторон типа double
        {
            double p = a + b + c; // вычисление...
            return p; // возврат
        }
        public double Surface() // аналогично периметру..
        {
            double s = 0;
            if (ExistTriangle==true)
            { 
            double p = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            }
            return s;
        }

    }
}
