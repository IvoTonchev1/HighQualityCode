namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides cannot be negative.");
            }

            if ((a + b) <= c || (a + c) <= b || (b + c) <= a)
            {
                throw new ArgumentException("The sum of any two sides cannot be less than or equal to the thirs side.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static string NumberToDigit(int number)
        {
            string digit = string.Empty;

            switch (number)
            {
                case 0: 
                    digit = "zero";
                    break;
                case 1:
                    digit = "one";
                    break;
                case 2:
                    digit = "two";
                    break;
                case 3: 
                    digit = "three";
                    break;
                case 4: 
                    digit = "four";
                    break;
                case 5:
                    digit = "five";
                    break;
                case 6:
                    digit = "six";
                    break;
                case 7: 
                    digit = "seven";
                    break;
                case 8: 
                    digit = "eight";
                    break;
                case 9: 
                    digit = "nine";
                    break;
                default:
                    throw new ArgumentException("Invalid output. Only a single digit is allowed.");
            }

            return digit;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Array is empty.");
            }

            int max = int.MinValue;

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsNumber(double number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {              
                throw new InvalidOperationException(string.Format("{0} is not valid format", format));
            }
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static bool IsVertical(double x1, double x2)
        {
            bool result = x1 == x2;

            return result;
        }

        public static bool IsHorizontal(double y1, double y2)
        {
            bool result = y1 == y2;

            return result;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontal(3, 3));
            Console.WriteLine("Vertical? " + IsVertical(-1, 2.5));

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");

            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
