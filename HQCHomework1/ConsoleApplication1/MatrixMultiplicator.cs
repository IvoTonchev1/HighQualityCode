namespace MatrixMultiplicatorCalculator
{
    using System;

    public class MatrixMultiplicator
    {
        public static void Main(string[] args)
        {
            double[,] firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            double[,] secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            double[,] resultMatrix = MultiplyMatrices(firstMatrix, secondMatrix);

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    Console.Write(resultMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] MultiplyMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new ArgumentException("The columns number of the first matrix must be equal to the rows number of the second matrix.");
            }

            int firstMatrixColumns = firstMatrix.GetLength(1);
            var resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < firstMatrixColumns; k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }                
            }
                
            return resultMatrix;
        }
    }
}