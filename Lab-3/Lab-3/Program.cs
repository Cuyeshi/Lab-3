using LibraryForMatrixs;
using System;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Matrixs matrixA = new Matrixs(), matrixB = new Matrixs(), matrixC = new Matrixs(); // Создание переменных типа Matrixs.
            double negativeA = 0, negativeB = 0, negativeC = 0, number = 0;

            bool isRun = true;  // Присваивание переменной IsRun значения true.

            while (isRun) // Консольное меню.
            {
                Console.WriteLine("\n          Выберите действие:");
                Console.WriteLine(" ----------------------------------------");
                Console.WriteLine("|           1 - Ввод 3 Матриц;           |");
                Console.WriteLine("|           2 - Вывод 3 Матриц;          |");
                Console.WriteLine("|     3 - Произведение отрицательных     |");
                Console.WriteLine("|      элементов Матриц без вывода;      |");
                Console.WriteLine("|     4 - Произведение отрицательных     |");
                Console.WriteLine("|       элементов Матриц с выводом;      |");
                Console.WriteLine("|       5 - Сумма Матриц A, B и С;       |");
                Console.WriteLine("|     6 - Выполнение особого задания;    |");
                Console.WriteLine("|         0 - Выход из программы;        |");
                Console.WriteLine(" ----------------------------------------\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Program.InputMatrix(matrixA); // Метод создания матрицы из полученной информации.
                        Program.InputMatrix(matrixB);
                        Program.InputMatrix(matrixC);
                        break;

                    case 2:
                        Console.WriteLine("\n");
                        Program.OutputMatrix(matrixA); // Метод вывода матрицы.
                        Console.WriteLine("\n");
                        Program.OutputMatrix(matrixB);
                        Console.WriteLine("\n");
                        Program.OutputMatrix(matrixC);
                        break;

                    case 3:
                        negativeA = Matrixs.MultiplyNegativeElements(matrixA); // Метод произведения отрицательных элементов матриц(без вывода).
                        negativeB = Matrixs.MultiplyNegativeElements(matrixB);
                        negativeC = Matrixs.MultiplyNegativeElements(matrixC);
                        Console.WriteLine("Произведения посчитаны.");
                        break;

                    case 4:
                        negativeA = Matrixs.MultiplyNegativeElements(matrixA, negativeA); // Операция произведения отрицательных элементов матриц(с выводом).
                        Console.WriteLine(Matrixs.ToString(negativeA, matrixA[0]));
                        negativeB = Matrixs.MultiplyNegativeElements(matrixB, negativeB);
                        Console.WriteLine(Matrixs.ToString(negativeB, matrixB[0]));
                        negativeC = Matrixs.MultiplyNegativeElements(matrixC, negativeC);
                        Console.WriteLine(Matrixs.ToString(negativeC, matrixC[0]));
                        break;

                    case 5:
                        Matrixs D = new Matrixs();
                        D = matrixA + matrixB; // Операция сложения матриц.
                        D = D + matrixC;
                        if (D.Line != 0)
                        {
                            Program.OutputMatrix(D);
                        }
                        else
                        {
                            D = matrixA + matrixB;
                            if (D.Line != 0)
                            {
                                Program.OutputMatrix(D);
                            }
                            else
                            {
                                D = matrixA + matrixC;
                                if (D.Line != 0)
                                {
                                    Program.OutputMatrix(D);
                                }
                                else
                                {
                                    D = matrixB + matrixC;
                                    if (D.Line != 0)
                                    {
                                        Program.OutputMatrix(D);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Матрицы нельзя сложить.");
                                    }
                                }
                            }
                        }
                        break;

                    case 6:
                        Console.Write("\nВведите число, выше которого должно быть произведение для выполнения особого задания: ");
                        number = Program.ReadDouble();
                        if (Matrixs.MultiplyNegativeElements(matrixA) > number)
                        {
                            if (matrixC) // Проверка на наличие ненулевых элементов внутри матрицы
                            {
                                double min = matrixC[matrixC.Line - 1, 0];
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
                                while (i < matrixC.Line)
                                {
                                    j = 0;
                                    while (j < matrixC.Column)
                                    {
                                        if (matrixC[i, j] < 0)
                                        {
                                            matrixC[i, j] = matrixC[i, j] + min;
                                        }
                                        j++;
                                    }
                                    i++;
                                }
                                Console.WriteLine("\nЗадача выполнилась!\n");
                                Program.OutputMatrix(matrixC);
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
        public static double[,] InputMatrix(int line, int column)
        {
            int i = 0;
            double[,] value = new double[1000, 1000];
            while (i < line)
            {
                int j = 0;
                while (j < column)
                {
                    value[i, j] = Program.ReadDouble();
                    j++;
                }
                i++;
            }
            return value;
        }
        /// <summary>
        /// Метод создания матрица из консоли.
        /// </summary>
        public static void InputMatrix(Matrixs A)
        {
            int line, column; // Создание переменных для обозначения строчек и столбцов матриц.
            double[,] values = new double[1000, 1000]; // Создание двумерных массивов для обозначения элементов матриц.
            string name; // Создание переменной для обозначения имени матрицы.
            Console.Write("\nВведите имя матрицы: ");
            name = Console.ReadLine();
            Console.Write("\nВведите число строк для матрицы: ");
            line = Program.ReadInt();
            Console.Write("\nВведите число столбцов матрицы: ");
            column = Program.ReadInt();
            Console.Write("\nВведите значение для матрицы(запись по строке): ");
            values = Program.InputMatrix(line, column);
            Console.Write("\n---------------------------------------------------------------------------\n");
            A = new Matrixs();
            A = new Matrixs(line, column, values, name);
        }
        /// <summary>
        /// Метод вывода матрицы в консоль.
        /// </summary>
        /// <param name="A"></param>
        public static void OutputMatrix(Matrixs A)
        {
            int i = 0;
            Console.WriteLine("\n" + A[0] + ":\n");
            while (i < A.Line)
            {
                int j = 0;
                while (j < A.Column)
                {
                    Console.Write(String.Format("{0,4:0.0}", A[i, j]));
                    Console.Write(" ");
                    j++;
                }
                Console.WriteLine("\n");
                i++;
            }
        }
        /// <summary>
        /// Метод для проверки вводимого значения для вещественного числа.
        /// </summary>
        /// <returns></returns>
        public static double ReadDouble()
        {
            string numeral = Console.ReadLine();
            double value;
            while (!Double.TryParse(numeral, out value))
            {
                Console.WriteLine("Вводный данные не подходят. Введите корректное значение: ");
                numeral = Console.ReadLine();
            }
            return value;
        }
        /// <summary>
        /// Метод для проверки вводимого значения для целочисленного числа.
        /// </summary>
        /// <returns></returns>
        public static int ReadInt()
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