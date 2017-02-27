﻿using System;

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
            var length1 = matrix.Length;
            var length2 = matrix[0].Length;

            var limit = length1 > length2 ? length2 / 2 : length1 / 2;
            for (var i = 0; i < limit; i++)
            {
                for (var x = 0; x < r % (2 * (length1 + length2 - 4 * i - 2)); x++)
                {
                    int col, temp = matrix[i][i];
                    var row = col = i;

                    for (; col < length2 - i - 1; col++) matrix[row][col] = matrix[row][col + 1];
                    for (; row < length1 - i - 1; row++) matrix[row][col] = matrix[row + 1][col];
                    for (; col > i; col--) matrix[row][col] = matrix[row][col - 1];
                    for (; row > i; row--) matrix[row][col] = matrix[row - 1][col];

                    matrix[i + 1][i] = temp;
                }
            }
            
            return matrix;
        }

        public void OutputMatrix(int[][] matrix)
        {
            var length1 = matrix.Length;
            var length2 = matrix[0].Length;
            for (long i = 0; i < length1; i++)
            {
                for (long j = 0; j < length2; j++)
                {
                    var cout = matrix[i][j];
                    Console.Write(j == length2 - 1 ? $"{cout} \n" : $"{cout} ");
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
