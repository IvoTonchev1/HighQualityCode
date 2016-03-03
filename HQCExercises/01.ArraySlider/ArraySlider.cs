namespace _01.ArraySlider
{
    using System;
    using System.Linq;

    public class ArraySlider
    {
        public static void Main()
        {
            long[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            int currentIndex = 0;
            int arrLength = arr.Length;
            string line = Console.ReadLine();
            while (line != "stop")
            {
                string[] input = line.Split();
                int offset = int.Parse(input[0]);
                if (offset >= 0)
                {
                    currentIndex += offset % arrLength;
                    currentIndex %= arrLength;
                }
                else
                {
                    int temp = offset % arrLength;
                    currentIndex += temp;
                    if (currentIndex < 0)
                    {
                        currentIndex += arrLength;
                    }
                }

                long number = arr[currentIndex];
                long result = PerformOperation(number, input[1], input[2]);
                arr[currentIndex] = result;
                line = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }

        private static long PerformOperation(long number, string operation, string secondNumber)
        {
            long second = long.Parse(secondNumber);
            long result = number;
            switch (operation)
            {
                case "+":
                    result += second;
                    break;
                case "-":
                    result -= second;
                    break;
                case "*":
                    result *= second;
                    break;
                case "/":
                    result /= second;
                    break;
                case "|":
                    result |= second;
                    break;
                case "^":
                    result ^= second;
                    break;
                case "&":
                    result &= second;
                    break;
            }

            if (result < 0)
            {
                result = 0;
            }

            return result;
        }
    }
}
