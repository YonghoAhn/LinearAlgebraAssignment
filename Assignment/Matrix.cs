using System;
using System.Text;

namespace Assignment
{
    /// <summary>
    /// Matrix class
    /// </summary>
    class Matrix
    {
        /// <summary>
        /// 행렬의 행을 나타냅니다. 읽기 전용
        /// </summary>
        private readonly int column = 0;
        /// <summary>
        /// 행렬의 열을 나타냅니다. 읽기 전용
        /// </summary>
        private readonly int row = 0;
        /// <summary>
        /// 행렬값을 저장합니다. 2차원 배열
        /// </summary>
        private readonly int[,] matrixData;
        /// <summary>
        /// Matrix Class Constructor
        /// </summary>
        /// <param name="column">행렬의 행</param>
        /// <param name="row">행렬의 열</param>
        public Matrix(int column, int row)
        {
            this.column = column;
            this.row = row;
            matrixData = new int[column,row];
        }
        /// <summary>
        /// 행렬에 데이터를 삽입합니다.
        /// </summary>
        /// <param name="column">데이터를 삽입할 행</param>
        /// <param name="row">데이터를 삽입할 열</param>
        /// <param name="value">입력할 데이터</param>
        /// <returns>입력 성공 여부를 반환합니다.</returns>
        public bool PutData(int column, int row, int value)
        {
            try
            {
                matrixData[column,row] = value;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 행렬의 특정 위치에 값을 더합니다.
        /// </summary>
        /// <param name="column">데이터를 더할 행</param>
        /// <param name="row">데이터를 더할 열</param>
        /// <param name="value">더할 값</param>
        public void AddData(int column, int row, int value)
        {
            PutData(column, row, GetData(column, row) + value);
        }
        /// <summary>
        /// 행렬에 데이터를 한번에 삽입합니다.
        /// </summary>
        /// <param name="values">행렬에 저장할 값을 담은 1차원 배열입니다.</param>
        /// <returns>성공여부를 반환합니다.</returns>
        public bool PutData(int[] values)
        {
            int i = 0;
            if (values.Length > column * row)
                return false;
            for (int col = 0; col < column; col++)
                for (int row = 0; row < this.row; row++)
                    matrixData[col, row] = values[i++];
            return true;
        }
        /// <summary>
        /// 행렬의 특정 위치의 데이터를 반환합니다.
        /// </summary>
        /// <param name="col">가져올 데이터의 행</param>
        /// <param name="row">가져올 데이터의 열</param>
        /// <returns>데이터를 반환합니다. 실패할 경우 -1이 반환됩니다.</returns>
        public int GetData(int col, int row)
        {
            try
            {
                return matrixData[col, row];
            } 
            catch (Exception)
            {
                return -1;
            }
        }
        /// <summary>
        /// 행렬의 합을 연산합니다.
        /// </summary>
        /// <param name="m1">행렬합을 구할 Matrix Object</param>
        /// <param name="m2">행렬합을 구할 Matrix Object</param>
        /// <returns>행렬합을 실행한 새 Matrix Object</returns>
        public static Matrix operator+ (Matrix m1, Matrix m2)
        {
            if (m1.column != m2.column || m1.row != m2.row)
                throw new ArgumentException("The matrix has different dimensions.");
            Matrix matrix = new Matrix(m1.column, m1.row);
            for (int c = 0; c < m1.column; c++)
                for (int r = 0; r < m1.row; r++)
                    matrix.PutData(c, r, m1.GetData(c, r) + m2.GetData(c, r));
            return matrix;
        }
        /// <summary>
        /// 행렬의 곱을 연산합니다.
        /// </summary>
        /// <param name="m1">행렬곱을 구할 Matrix Object</param>
        /// <param name="m2">행렬곱을 구할 Matrix Object</param>
        /// <returns>행렬곱을 실행한 새 Matrix Object</returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.row != m2.column)
                throw new ArgumentException("The matrix has different dimensions.");


            Matrix matrix = new Matrix(m1.column, m2.row);

            for (int i = 0; i < m1.column; i++)
            {
                for (int j = 0; j < m2.row; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < m1.row; k++)
                    {
                        sum += m1.GetData(i, k) * m2.GetData(k, j);
                    }
                    matrix.PutData(i, j, sum);
                }
            }
            return matrix;
        }
        /// <summary>
        /// 행렬의 스칼라곱을 연산합니다. 행렬 * 스칼라 형태로 작성하여야 합니다.
        /// </summary>
        /// <param name="m1">행렬</param>
        /// <param name="scala">스칼라</param>
        /// <returns>스칼라곱 연산 결과</returns>
        public static Matrix operator *(Matrix m1, int scala)
        {
            for (int i = 0; i < m1.column; i++)
                for (int j = 0; j < m1.row; j++)
                    m1.PutData(i, j, m1.GetData(i, j) * scala);
            return m1;
        }
        /// <summary>
        /// ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("    ");
            for (int i = 0; i < row; i++)
                stringBuilder.AppendFormat("{0,4}열", i + 1);
            stringBuilder.AppendLine();
            for (int c = 0; c < column; c++)
            {
                stringBuilder.Append($"{c + 1}행 :");
                for (int r = 0; r < row; r++)
                {
                    stringBuilder.AppendFormat("{0,5}", GetData(c, r));
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
