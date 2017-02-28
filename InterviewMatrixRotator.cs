using System;

namespace MatrixRotator
{
    /*
     * You are given a 2D matrix, a, of dimension MxN and a positive integer, R. You have to rotate the
     * matrix R times and return the resultant matrix. Rotations should be in counter-clockwise direction.
     * Rotation of a 4x5 matrix is represented by the following figure.
     * 
     * Constraints
     * 2 <= M, N <= 300
     * 1 <= R <= 109
     * min(M, N) % 2 == 0
     * 1 <= aij <= 108, where i ∈ [1..M] & j ∈ [1..N]
     * 
     * Explanation
     * 1 2 3 4       2 3 4 8
     * 5 6 7 8       1 7 11 12
     * 9 10 11 12 -> 5 6 10 16
     * 13 14 15 16   9 13 14 15
     * 
     * 1 2 3 4       2 3 4 8      3 4 8 12
     * 5 6 7 8       1 7 11 12    2 11 10 16
     * 9 10 11 12 -> 5 6 10 16 -> 1 7 6 15
     * 13 14 15 16   9 13 14 15   5 9 13 14
     */

    public class InterviewMatrixRotator : IMatrixRotator
    {
        public int[][] Rotate(int[][] matrix, int r)
        {
            var rowLength = matrix.Length;
            var colLength = matrix[0].Length;
            var limit = rowLength > colLength ? colLength / 2 : rowLength / 2;

            for (var i = 0; i < limit; i++)
            {
                for (var j = 0; j < r % (2 * (rowLength + colLength - 4 * i - 2)); j++)
                {
                    int col, temp = matrix[i][i];
                    var row = col = i;

                    for (; col < colLength - i - 1; col++) matrix[row][col] = matrix[row][col + 1];
                    for (; row < rowLength - i - 1; row++) matrix[row][col] = matrix[row + 1][col];
                    for (; col > i; col--) matrix[row][col] = matrix[row][col - 1];
                    for (; row > i; row--) matrix[row][col] = matrix[row - 1][col];

                    matrix[i + 1][i] = temp;
                }
            }
            
            return matrix;
        }

        public void OutputMatrix(int[][] matrix)
        {
            var rowLength = matrix.Length;
            var colLength = matrix[0].Length;

            for (long i = 0; i < rowLength; i++)
            {
                for (long j = 0; j < colLength; j++)
                {
                    var value = matrix[i][j];
                    Console.Write(j == colLength - 1 ? $"{value} \n" : $"{value} ");
                }
            }
        }
    }

    public interface IMatrixRotator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="martix">Initial matrix</param>
        /// <param name="r">Number of rotations</param>
        /// <returns>Rotated matrix</returns>
        int[][] Rotate(int[][] martix, int r);
    }
}
