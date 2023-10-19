using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryForMatrixs;

namespace TestForMatrixs
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Метод сравнения матриц между собой.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool CompareMatrixs(Matrixs A, Matrixs B)
        {
            if (A.Line != B.Line || A.Column != B.Column || A[0] != B[0])
            {
                return false;
            }
            int i = 0;
            while (i < A.Line)
            {
                int j = 0;
                while (j < A.Column)
                {
                    if (A[i, j] != B[i, j])
                    {
                        return false;
                    }
                    j++;
                }
                i++;
            }
            return true;
        }
        /// <summary>
        /// Тест, проверяющий сложение одноэлементных матриц.
        /// </summary>
        [TestMethod]
        public void SingleElementMatrixsAddition()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 1;
            matrix1.Column = 1;
            matrix1[0, 0] = 3;

            Matrixs matrix2 = new Matrixs();
            matrix2.Line = 1;
            matrix2.Column = 1;
            matrix2[0, 0] = 1;

            Matrixs matrix3 = matrix1 + matrix2;

            Matrixs result = new Matrixs();
            result.Line = 1;
            result.Column = 1;
            result[0, 0] = 4;
            result[0] = "Result Matrix";

            Assert.IsTrue(CompareMatrixs(result, matrix3));
        }
        /// <summary>
        /// Тест, проверяющий сложение квадратных матриц. 
        /// </summary>
        [TestMethod]
        public void AdditionSquareMatrixs()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1[0, 0] = 1; matrix1[0, 1] = 2; matrix1[1, 0] = 3; matrix1[1, 1] = 4;

            Matrixs matrix2 = new Matrixs();
            matrix2.Line = 2;
            matrix2.Column = 2;
            matrix2[0, 0] = 9; matrix2[0, 1] = 8; matrix2[1, 0] = 7; matrix2[1, 1] = 6;

            Matrixs matrix3 = matrix1 + matrix2;

            Matrixs result = new Matrixs();
            result.Line = 2;
            result.Column = 2;
            result[0, 0] = 10; result[0, 1] = 10; result[1, 0] = 10; result[1, 1] = 10;
            result[0] = "Result Matrix";

            Assert.IsTrue(CompareMatrixs(result, matrix3));
        }
        /// <summary>
        /// Тест, проверяющий возможность сложения матриц.
        /// </summary>
        [TestMethod]
        public void MatrixAdditionCheck()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 1;
            matrix1.Column = 2;
            matrix1[0, 0] = 2; matrix1[0, 1] = 3;

            Matrixs matrix2 = new Matrixs();
            matrix2.Line = 1;
            matrix2.Column = 1;
            matrix2[0, 0] = 1;

            Matrixs matrix3 = matrix1 + matrix2;

            Matrixs result = new Matrixs();

            Assert.IsTrue(CompareMatrixs(result, matrix3));
        }
        /// <summary>
        /// Тест, проверяющий наличие в матрице ненулевых элементов.
        /// </summary>
        [TestMethod]
        public void MatrixWithNoZeroElements()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 3;
            matrix1.Column = 2;
            matrix1[0, 0] = 0; matrix1[0, 1] = 0; matrix1[1, 0] = 0; matrix1[1, 1] = 0; matrix1[2, 0] = 2; matrix1[2, 1] = 0;
            bool noZero = false;
            if (matrix1)
            {
                noZero = true;
            }
            Assert.IsTrue(noZero);
        }
        /// <summary>
        /// Тест, проверяющий матрицу на все нулевые значения.
        /// </summary>
        [TestMethod]
        public void MatrixWithZeroElements()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1[0, 0] = 0; matrix1[0, 1] = 0; matrix1[1, 0] = 0; matrix1[1, 1] = 0;
            bool zero = true;
            if (matrix1)
            {
                zero = false;
            }

            Assert.IsTrue(zero);
        }
        /// <summary>
        /// Тест, проверяющий произвденеие отрицательных элементов матрицы(без вывода);.
        /// </summary>
        [TestMethod]
        public void MultiplicationNegativeElenentsOfMatrixWithOutOutput()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1[0, 0] = -2; matrix1[0, 1] = -5; matrix1[1, 0] = -3; matrix1[1, 1] = -1.1;

            double negative = 33;

            double result = Matrixs.MultiplyNegativeElements(matrix1);

            Assert.AreEqual(result, negative);
        }
        /// <summary>
        /// Тест, проверяющий произвденеие отрицательных элементов матрицы(с выводом).
        /// </summary>
        [TestMethod]
        public void MultiplicationNegativeElenentsOfMatrixWithOutput()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1[0, 0] = 2; matrix1[0, 1] = -5; matrix1[1, 0] = -5; matrix1[1, 1] = -1;

            double negative = -25;

            double result = 0;
            result = Matrixs.MultiplyNegativeElements(matrix1, result);

            Assert.AreEqual(result, negative);
        }
        /// <summary>
        /// Тест, проверяющий произведение отрицательных элементов матрицы, у которой все элементы положительны или ноль.
        /// </summary>
        [TestMethod]
        public void MultiplicationNegativeElementsMatrix()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 3;
            matrix1.Column = 3;
            matrix1[0, 0] = 3; matrix1[0, 1] = 3; matrix1[0, 2] = 3; matrix1[1, 0] = 1; matrix1[1, 1] = 1; matrix1[1, 2] = 1; matrix1[2, 0] = 0; matrix1[2, 1] = 0; matrix1[2, 2] = 0;

            double negative = 0;

            double result = Matrixs.MultiplyNegativeElements(matrix1);

            Assert.AreEqual(result, negative);
        }
    }
}