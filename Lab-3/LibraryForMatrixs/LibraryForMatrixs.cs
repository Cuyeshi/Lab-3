namespace LibraryForMatrixs
{
    /// <summary>
    /// Класс, в котором находятся данные косающиеся матрицы, методы и операции, совершаемые над матрицами. 
    /// </summary>
    public class Matrixs
    {
        private int[,] number = new int[1000, 1000];

        private string[] name = new string[1000]; 

        /// <summary>
        /// Переменные для хранения информации о количестве строк и столбцов. 
        /// </summary>
        public int line, column;

        /// <summary>
        /// Свойство количества строк. 
        /// </summary>
        public int Line
        {
            get 
            { 
                return line; 
            }
            set
            { 
                line = value; 
            }
        }

        /// <summary>
        /// Свойство количества столбцов. 
        /// </summary>
        public int Column
        {
            get 
            { 
                return column; 
            }
            set
            {
                column = value;
            }
        }

        /// <summary>
        /// Индексатор для доступа к значению элементов матрицы. 
        /// </summary>
        public int this[int i, int j]
        {
            get => number[i, j];
            set => number[i, j] = value;
        }

        /// <summary>
        /// Индексатор для доступа к имени матрицы. 
        /// </summary>
        public string this[int i]
        {
            get => name[0];
            set => name[0] = value;
        }

        /// <summary>
        /// Конструктор пустой матрицы.
        /// </summary>
        public Matrixs()
        {
            this.Line = 0;
            this.Column = 0;
            this[Line, Column] = 0;
            this[0] = "";
        }

        /// <summary>
        /// Конструктор матрицы по вводимым данным.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="name"></param>
        public Matrixs(int line, int column, int[,] values, string name)
        {
            this.Line = line;
            this.Column = column;
            this[0] = name;
            int stepLine = 0, stepColumn;
            while (stepLine < line)
            {
                stepColumn = 0;
                while (stepColumn < column)
                {
                    this[stepLine, stepColumn] = values[stepLine, stepColumn];
                    stepColumn++;
                }
                stepLine++;
            }
        }

        /// <summary>
        /// Операция сложения матрицы на матрицу.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrixs operator +(Matrixs A, Matrixs B)
        {
            if (A.Line == B.Line && A.Column == B.Column)
            {
                int stepLine = 0, stepColumn = 0;
                Matrixs C = new Matrixs();
                C.Line = A.Line;
                C.Column = A.Column;
                C[0] = "Result Matrix";
                while (stepLine < A.Line)
                {
                    stepColumn = 0;
                    while (stepColumn < A.Column)
                    {
                        C[stepLine, stepColumn] = A[stepLine, stepColumn] + B[stepLine, stepColumn];
                        stepColumn++;
                    }
                    stepLine++;
                }
                return C;
            }
            Matrixs D = new Matrixs();
            return D;
        }

        /// <summary>
        /// Переменная для определения ненулевого элемента внутри матрицы.
        /// </summary>
        public bool HaveNozero
        {
            get
            {
                int stepLine = 0, stepColumn = 0;
                while (stepLine < Line)
                {
                    stepColumn = 0;
                    while (stepColumn < Column)
                    {
                        if (this[stepLine, stepColumn] != 0)
                        {
                            return true;
                        }
                        stepColumn++;
                    }
                    stepLine++;
                }
                return false;
            }
        }

        /// <summary>
        /// Операция true для матрицы.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static bool operator true(Matrixs A)
        {
            return A.HaveNozero;
        }

        /// <summary>
        /// Операция false для матрицы.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static bool operator false(Matrixs A)
        {
            return !A.HaveNozero;
        }

        /// <summary>
        /// Метод для нахождения произведения отрицательных элементов матрицы без вывода результата.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int MultiplyNegativeElements(Matrixs A)
        {
            int stepLine = 0, sizeArray = 0;
            int[] negative = new int[1000];
            while (stepLine < A.Line)
            {
                int stepColumn = 0;
                while (stepColumn < A.Column)
                {
                    if (A[stepLine, stepColumn] < 0)
                    {
                        negative[sizeArray] = A[stepLine, stepColumn];
                        sizeArray++;
                    }
                    stepColumn++;
                }
                stepLine++;
            }
            if (sizeArray != 0)
            {
                int i = 0;
                int number = 1;
                while (i < sizeArray)
                {
                    number = number * negative[i];
                    i++;
                }
                return number;
            }
            else
            {
                int number = 0;
                return number;
            }

        }

        /// <summary>
        /// Метод для нахождения произведения отрицательных элементов матрицы с выводом результата
        /// </summary>
        /// <param name="A"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int MultiplyNegativeElements(Matrixs A, int number)
        {
            int stepLine = 0, sizeArray = 0;
            int[] negative = new int[1000];
            while (stepLine < A.Line)
            {
                int stepColumn = 0;
                while (stepColumn < A.Column)
                {
                    if (A[stepLine, stepColumn] < 0)
                    {
                        negative[sizeArray] = A[stepLine, stepColumn];
                        sizeArray++;
                    }
                    stepColumn++;
                }
                stepLine++;
            }

            if (sizeArray != 0)
            {
                int i = 0;
                number = 1;
                while (i < sizeArray)
                {
                    number = number * negative[i];
                    i++;
                }
                return number;
            }
            else
            {
                number = 0;
                return number;
            }
        }

        /// <summary>
        /// Метод создания строки с записью произведения отрицательных элементов. 
        /// </summary>
        public static string ToString(int number, string name)
        {
            string res = number + " - " + name + "\n";
            return res;
        }
    }
}