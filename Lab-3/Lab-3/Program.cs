using LibraryForMatrixs;
using System;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание переменных типа Matrixs.
            Matrixs matrixA = new Matrixs();
            Matrixs matrixB = new Matrixs(); 
            Matrixs matrixC = new Matrixs(); 
            int negativeA = 0, negativeB = 0, negativeC = 0, number = 0;

            bool isRun = true;

            // Консольное меню.
            while (isRun) 
            {
                Console.WriteLine("\n          Выберите действие:");
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║             1 - Ввод Матриц;           ║");
                Console.WriteLine("║          2 - Вывод 3-ёх Матриц;        ║");
                Console.WriteLine("║     3 - Произведение отрицательных     ║");
                Console.WriteLine("║              элементов Матриц;         ║");
                Console.WriteLine("║       4 - Сумма Матриц A, B и С;       ║");
                Console.WriteLine("║     5 - Выполнение особого задания;    ║");
                Console.WriteLine("║         0 - Выход из программы;        ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n");
                switch (ReadInt())
                {
                    case 1:
                        // Методы создания матриц.
                        matrixA = InputMatrix();
                        matrixB = InputMatrix();
                        matrixC = InputMatrix();
                        break;

                    case 2:
                        Console.WriteLine("\n");
                        OutputMatrix(matrixA); // Метод вывода матрицы А.
                        Console.WriteLine("\n");
                        OutputMatrix(matrixB); // Метод вывода матрицы B.
                        Console.WriteLine("\n");
                        OutputMatrix(matrixC); // Метод вывода матрицы C.
                        break;

                    case 3:
                        // Операция произведения отрицательных элементов матриц.
                        negativeA = Matrixs.MultiplyNegativeElements(matrixA, negativeA);
                        Console.WriteLine(Matrixs.ToString(negativeA, matrixA[0]));
                        negativeB = Matrixs.MultiplyNegativeElements(matrixB, negativeB);
                        Console.WriteLine(Matrixs.ToString(negativeB, matrixB[0]));
                        negativeC = Matrixs.MultiplyNegativeElements(matrixC, negativeC);
                        Console.WriteLine(Matrixs.ToString(negativeC, matrixC[0]));
                        break;

                    case 4:
                        // Сумма Матриц.
                        Matrixs D = new Matrixs();
                        D = matrixA + matrixB + matrixC; // Операция сложения матриц.
                        if (D.Line != 0)
                        {
                            OutputMatrix(D);
                        }
                        else
                        {
                            Console.WriteLine("Матрицы нельзя сложить.");
                        }
                        break;

                    case 5:
                        Console.Write("\nВведите число, выше которого должно быть произведение для выполнения особого задания: ");
                        number = ReadInt();
                        if (Matrixs.MultiplyNegativeElements(matrixA) > number)
                        {
                            if (matrixC) // Проверка на наличие ненулевых элементов внутри матрицы
                            {
                                int min = matrixC[matrixC.Line - 1, 0];
                                int j = 1;
                                while (j < matrixC.Column)
                                {
                                    if (min > matrixC[matrixC.Line - 1, j])
                                    {
                                        min = matrixC[matrixC.Line - 1, j];
                                    }
                                    j++;
                                }

                                int i = 0;
                                while (i < matrixA.Line)
                                {
                                    j = 0;
                                    while (j < matrixA.Column)
                                    {
                                        if (matrixA[i, j] < 0)
                                        {
                                            matrixA[i, j] = matrixA[i, j] + min;
                                        }
                                        j++;
                                    }
                                    i++;
                                }
                                Console.WriteLine("\nЗадача выполнена!\n");
                                OutputMatrix(matrixA);
                            }
                            else
                            {
                                Console.WriteLine("В третьей матрице только нулевые элементы.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Произведение отрицательных элементов не привысило число.");
                        }
                        break;

                    case 0:
                        isRun = false; // Выход из программы.
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор функции!");
                        break;
                }
            }
        }

        /// <summary>
        /// Метод ввода двумерного массива из консоли.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private static int[,] InputMatrix(int line, int column)
        {
            int i = 0;
            int[,] value = new int[1000, 1000];
            while (i < line)
            {
                int j = 0;
                while (j < column)
                {
                    value[i, j] = ReadInt();
                    j++;
                }
                i++;
            }
            return value;
        }

        /// <summary>
        /// Метод создания матрица из консоли.
        /// </summary>
        private static Matrixs InputMatrix()
        {
            int line, column; // Переменные для обозначения строчек и столбцов матриц.
            int[,] values = new int[1000, 1000]; // Создание двумерного массива для обозначения элементов матриц.
            string name; // Создание переменной для обозначения имени матрицы.
            Console.Write("\nВведите имя матрицы: ");
            name = Console.ReadLine();
            Console.Write("\nВведите число строк для матрицы: ");
            line = ReadInt();
            Console.Write("\nВведите число столбцов матрицы: ");
            column = ReadInt();
            Console.Write("\nВведите элементы матрицы: ");
            values = InputMatrix(line, column);
            Console.WriteLine("\n---------ВВОД ДАННЫХ ЗАКОНЧЕН--------\n");

            return new Matrixs(line, column, values, name);
        }

        /// <summary>
        /// Метод вывода матрицы в консоль.
        /// </summary>
        /// <param name="A"></param>
        private static void OutputMatrix(Matrixs A)
        {
            int i =0, j;
            Console.WriteLine("\n" + A[0] + ":\n");
            while (i < A.Line)
            {
                j = 0;
                for (i = 0; i < A.Line; i++)
                {
                    for (j = 0; j < A.Column; j++)
                    {
                        Console.Write(String.Format("{0,4:0.0}", A[i, j]));
                        Console.Write(" ");
                    }
                    Console.WriteLine("\n");
                }
            }
        }

        /// <summary>
        /// Метод для проверки вводимого значения для целочисленного числа.
        /// </summary>
        /// <returns></returns>
        private static int ReadInt()
        {
            string numeral = Console.ReadLine();
            int value;
            while (!Int32.TryParse(numeral, out value))
            {
                Console.WriteLine("Вводный данные не подходят. Введите корректное значение: ");
                numeral = Console.ReadLine();
            }
            return value;
        }
    }
}