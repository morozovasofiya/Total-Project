using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломный_проект__функции_
{
    class Program
    {
        //1. function for average ratio
        //2. function for weight ratio
        //3. function for selection of points
        //4. function to check if a point is in an area
        //____________
        //1
        public static double Average_Ratio(double[] mas)
        {
            double Sum_Ratio = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                Sum_Ratio += mas[i];
            }
            double average_ratio = Sum_Ratio / mas.Length;
            return average_ratio;
        }
        //2
        public static double[,] Weight_Ratio(double[] Array_Ratio, double[] Array_Distance)
        {
            int count_R = 0;
            int count_D = 0;
            double Total_Value = Average_Ratio(Array_Ratio);
            for (int i = 0; i < Array_Ratio.Length; i++)
            {
                if (Array_Ratio[i] > Total_Value)
                {
                    count_R++;
                    count_D++;
                }
            }
            double[] new_arrayR = new double[count_R];
            double[] new_arrayD = new double[count_D];
            int i_new = 0;
            for (int i = 0; i < Array_Ratio.Length; i++)
            {
                if (Array_Ratio[i] > Total_Value)
                {
                    new_arrayR[i_new] = Array_Ratio[i];
                    i_new++;
                }
            }
            int j_new = 0;
            for (int i = 0; i < Array_Distance.Length; i++)
            {
                if (Array_Ratio[i] > Total_Value)
                {
                    new_arrayD[j_new] = Array_Distance[i];
                    j_new++;
                }
            }
            foreach (int i in new_arrayD)
            {
                Console.WriteLine("-------------");
                Console.WriteLine(i);
                Console.WriteLine("-------------");
            }
            double[,] Array_RatioDistance = new double[2, count_R];
            for (int i = 0; i < new_arrayR.Length; i++)
            {
                Array_RatioDistance[0, i] = new_arrayR[i]; //
                Array_RatioDistance[1, i] = new_arrayD[i];
            }

            return Array_RatioDistance;
        }
        //3
        //public static List<string> Selection_of_Points(double Radius, )
        //_________________________
        public static void Output(double[,] array)
        {
            Console.WriteLine("count = {0}", array.Length);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < array.Length / 2; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public static void Output(double[] array)
        {
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
        //4 - для одной точки

        /*public static bool Point_Check(double x, double y, double x_point, double y_point, int S) //x, y - координаты местонахождения пользователя, x_point, y_point - координаты отобранной точки (из двумерного массива) (x_end, y_end - ?)
        {
            bool check = false;
            if ((x_point > y) && (y_point > y) && (Math.Pow(x_point - x, 2) + Math.Pow(y_point - y, 2) <= S * S))
            {
                check = true;
            }
            return check;
        }*/
        public static double[,] Point_Check(double x, double y, double x_point, double y_point, int S, double[,] array, double[] Array_Ratio) //x, y - координаты местонахождения пользователя, x_point, y_point - координаты отобранной точки (из двумерного массива) (x_end, y_end - ?)
        { //array - двумерный массив координат
            int count_R = 0;
            double Total_Value = Average_Ratio(Array_Ratio);
            for (int i = 0; i < Array_Ratio.Length; i++)
            {
                if (Array_Ratio[i] > Total_Value)
                {
                    count_R++;
                }
            }
            double[,] ArrayOfCoordinates = new double[2, count_R];
            int i_new = 0;
            foreach (int i in array)
            {
                if ((x_point > y) && (y_point > y) && (Math.Pow(x_point - x, 2) + Math.Pow(y_point - y, 2) <= S * S))
                {
                    ArrayOfCoordinates[0, i_new] = array[0, i];
                    ArrayOfCoordinates[1, i_new] = array[1, i];
                    i_new++;
                }
            }
            return ArrayOfCoordinates;
        }
        public static double[,] ArrayOfCoordinates(double[] Array_Ratio, double[,] array, double x, double y, double x_point, double y_point, int S) //возвращает двумерный массив координат
        { //array - двумерный массив координат
            double[,] TotalArrayOfCoordinates = Point_Check(x, y, x_point, y_point, S, array, Array_Ratio);
            int count_R = 0;
            double Total_Value = Average_Ratio(Array_Ratio);
            for (int i = 0; i < Array_Ratio.Length; i++)
            {
                if (Array_Ratio[i] > Total_Value)
                {
                    count_R++;
                }
            }
            double[,] new_arrayCoordinates = new double[2, count_R];
            int i_new = 0;
            for (int i = 0; i < TotalArrayOfCoordinates.Length; i++)
            {
                if (Array_Ratio[i] > Total_Value)
                {
                    new_arrayCoordinates[0, i_new] = TotalArrayOfCoordinates[0, i];
                    new_arrayCoordinates[1, i_new] = TotalArrayOfCoordinates[1, i];
                    i_new++;
                }
            }
            return new_arrayCoordinates;
        }
        public static double[,] ArrayOfCoordinates1(double[] Array_Ratio, double[] Array_Distance, double[,] Array_Coordinates, int S)
        { //нужен минимальный коэффицент
            int k = 0;
            double x = 15.98;
            double y = 85.14;
            double x_point = 190.87;
            double
            double coefficent_min = Average_Ratio(Array_Ratio) / S;
            for (int i = 0; i < Array_Ratio.Length; i++)
            {
                if (Array_Ratio[i] / Array_Distance[i] > coefficent_min)
                {
                    k++;
                }
            }
            double[,] new_ArrayCoordinates = new double[2, k];
            int i_new = 0;
            for (int i = 0; i < new_ArrayCoordinates.Length; i++)
            {
                if (Array_Ratio[i] / Array_Distance[i] > coefficent_min)
                {
                    new_ArrayCoordinates[0, i_new] = Array_Coordinates[0, i];
                    new_ArrayCoordinates[1, i_new] = Array_Coordinates[1, i];
                    i_new++;
                }
            }
            return new_ArrayCoordinates;
        }
        static void Main()
        {
            int S = 500; //расстояние уклона
            double[] array = new double[5] { 3.5, 6, 7, 8, 2 }; //рейтинг
            double[] array2 = new double[5] { 7, 10, 11, 12, 7 }; //расстояние
            double[,] array3 = new double[2, 5] { { 3.45, 3.46, 5.98, 56.91, 56.82 }, { 5.78, 2.98, 4.9, 32.35, 12.97 } };
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            //double[] array2 = new double[5] { 0.5, 0.1, 0.3, 0.2, 0.44 };
            
            Console.WriteLine("-----------------");
            Console.WriteLine(Average_Ratio(array));
            Output(ArrayOfCoordinates1(array, array2, array3, S));
            Output(ArrayOfCoordinates(array, ArrayOfCoordinates1(array, array2, array3, S), ))
            Console.WriteLine("-----------------");
            foreach (int i in array2)
            {
                Console.WriteLine(i);
            }
            Output(Weight_Ratio(array, array2));
            /*Total_Array = Weight_Ratio(array, array2);
            foreach (int i in Total_Array)
            {
                int point = Total_Array[0, i];
            }*/
            Console.ReadKey();
        }
    }
}
