// using System;
// class SpiralMatrix
// {
//    static void Main()
//    {
//        Console.Write("Please enter number such that 0<=number<=20 : ");
//        int number = int.Parse(Console.ReadLine());
//        int temp = 0;
//        if ((number < 0) || (number > 20))
//        {
//        Console.WriteLine("Invalid input.");
//        }
//        else
//        {
//            int[,] spiralMatrix = new int[number, number];
//            int row = 0;
//            int col = 0;
//            string direction = "right";
//            int maxValue = number * number;
//            for (int i = 1; i <= maxValue; i++)
//            {
//                if (direction == "right" && (col > (number - 1) || spiralMatrix[row, col] != 0))
//                {
//                    direction = "down";
//                    row++;
//                    col--;
//                }
//                if (direction == "down" && (row > (number - 1) || spiralMatrix[row, col] != 0))
//                {
//                    direction = "left";
//                    row--;
//                    col--;
//                }
//                if (direction == "left" && (col < 0 || spiralMatrix[row, col] != 0))
//                {
//                    direction = "up";
//                    row--;
//                    col++;
//                }
//                if (direction == "up" && (row < 0 || spiralMatrix[row, col] != 0))
//                {
//                    direction = "right";
//                    row++;
//                    col++;
//                }
//                spiralMatrix[row, col] = i;
//                if (direction == "right")
//                {
//                    col++;
//                }
//                if (direction == "down")
//                {
//                    row++;
//                }
//                if (direction == "left")
//                {
//                    col--;
//                }
//                if (direction == "up")
//                {
//                    row--;
//                }
//            }
//            Console.WriteLine("The Spiral Matrix from 1 to square of N numbers is:");
//            for (int r = 0; r < number; r++)
//            {
//                for (int c = 0; c < number; c++)
//                {
//                Console.Write("{0,4}", spiralMatrix[r, c]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }
// }
