using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace переделанные_дипломные_функции
{
    class Program
    {
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
        public static double[,] SelectionByCoefficient(double[] Array_Ratio, double[] Array_Distance, double[,] Array_Coordinates, int S)
        {
            int k = 0;
            double coefficent_min = Average_Ratio(Array_Ratio) / S;
            for (int i = 0; i < Array_Ratio.Length; i++)
            {
                if (Array_Ratio[i] / Array_Distance[i] > coefficent_min) { k++; }
            }
            double[,] mas = new double[2, k];
            int i_new = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (Array_Ratio[i] / Array_Distance[i] > coefficent_min)
                {
                    mas[0, i_new] = Array_Coordinates[0, i];
                    i_new++;
                }
            }
            return mas;
        }
        public static double[,] Point_Check(double x, double y, double[,] Array_Coordinates, double[] Array_Ratio, int S)
        { //Array_Coordinates = SelectionByCoefficient
            int count_R = 0;
            double Total_Value = Average_Ratio(Array_Ratio);
            for (int i = 0; i < Array_Ratio.Length; i++)
            {
                if (Array_Ratio[i] > Total_Value) { count_R++; }
            }
            double[,] mas = new double[2, count_R];
            int i_new = 0;
            foreach (int i in Array_Coordinates)
            {
                if ((Array_Coordinates[0, i] > y) && (Array_Coordinates[1, i] > y) && (Math.Pow(Array_Coordinates[0, i] - x, 2) + Math.Pow(Array_Coordinates[1, i] - y, 2) <= S * S))
                {
                    mas[0, i_new] = Array_Coordinates[0, i];
                    mas[1, i_new] = Array_Coordinates[1, i];
                    i_new++;
                }
            }
            return mas;
        }
        static void Main()
        {
            int S = 500; //расстояние уклона
            double[] array = new double[5] { 3.5, 6, 7, 8, 2 }; //рейтинг
            double[] array2 = new double[5] { 7, 10, 11, 12, 7 }; //расстояние
            double[,] array3 = new double[2, 5] { { 3.45, 3.46, 5.98, 56.91, 56.82 }, { 5.78, 2.98, 4.9, 32.35, 12.97 } }; //координаты
        }
    }
}
