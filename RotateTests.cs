using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixRotator
{
    [TestClass]
    public class RotateTests
    {
        private readonly IMatrixRotator _matrixRotator = new InterviewMatrixRotator();

        [TestMethod]
        public void TestCase1()
        {
            const int rotates = 1;
            var actual = new[]
            {
                new[] {1, 2, 3, 4},
                new[] {5, 6, 7, 8},
                new[] {9, 10, 11, 12},
                new[] {13, 14, 15, 16}
            };
            var expected = new[]
            {
                new[] {2, 3, 4, 8},
                new[] {1, 7, 11, 12},
                new[] {5, 6, 10, 16},
                new[] {9, 13, 14, 15}
            };

            var result = _matrixRotator.Rotate(actual, rotates);

            Assert.IsTrue(Compare(result, expected));
        }

        [TestMethod]
        public void TestCase2()
        {
            const int rotates = 2;
            var actual = new[]
            {
                new[] {1, 2, 3, 4},
                new[] {5, 6, 7, 8},
                new[] {9, 10, 11, 12},
                new[] {13, 14, 15, 16}
            };
            var expected = new[]
            {
                new[] {3, 4, 8, 12},
                new[] {2, 11, 10, 16},
                new[] {1, 7, 6, 15},
                new[] {5, 9, 13, 14}
            };

            var result = _matrixRotator.Rotate(actual, rotates);

            Assert.IsTrue(Compare(result, expected));
        }

        [TestMethod]
        public void TestCase3()
        {
            const int rotates = 7;
            var actual = new[]
            {
                new[] {1, 2, 3, 4},
                new[] {7, 8, 9, 10},
                new[] {13, 14, 15, 16},
                new[] {19, 20, 21, 22},
                new[] {25, 26, 27, 28}
            };
            var expected = new[]
            {
                new[] {28, 27, 26, 25},
                new[] {22, 9, 15, 19},
                new[] {16, 8, 21, 13},
                new[] {10, 14, 20, 7},
                new[] {4, 3, 2, 1}
            };

            var result = _matrixRotator.Rotate(actual, rotates);

            Assert.IsTrue(Compare(result, expected));
        }

        [TestMethod]
        public void TestCase4()
        {
            const int rotates = 3;
            var actual = new[] {new[] {1, 1}, new[] {1, 1}};
            var expected = new[] {new[] {1, 1}, new[] {1, 1}};

            var result = _matrixRotator.Rotate(actual, rotates);

            Assert.IsTrue(Compare(result, expected));
        }

        private static bool Compare(int[][] expected, int[][] actual)
        {
            var length1 = expected.Length;
            var length2 = expected[0].Length;
            for (var i = 0; i < length1; i++)
            {
                for (var j = 0; j < length2; j++)
                {
                    if (expected[i][j] != actual[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}