using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _831C
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Input = Console.ReadLine().Split(' ');
            int k = Convert.ToByte(Input[0]); // Количество судей
            int n = Convert.ToByte(Input[1]); // Количество оценок
            string[] marks = Console.ReadLine().Split(' '); // Все проставленные оценки

            // Заполняем массив оценок
            int[] Marks = new int[k];
            for(int i=0; i < k; i++) { Marks[i] = Convert.ToByte(marks[i]); }

            // Заполняем массив баллов из памяти
            string[] remembered= Console.ReadLine().Split(' '); // Баллы в памяти
            int[] Remembered = new int[n];
            for (int i = 0; i < n; i++) { Remembered[i] = Convert.ToByte(remembered[i]); }

            int Answer = 0;
            for (int i=0; i<=k;i++)
            {
                int[] CurMass = AllStages(Marks, i, Remembered[0]);
                bool Next=true;
                for(int j=0; j<=n; j++)
                {
                    Next = CheckMark(Remembered[j], ref CurMass);
                    if (!Next) { break; }
                }
                if (Next) { Answer++; }
            }

            Console.WriteLine(Answer);
            Console.ReadLine();
        }

        // Функция создания массива оценок
        private static int[] AllStages(int[] Marks, int Place, int Point)
        {
            int Size = Marks.Count();
            int[] Stages = new int[Size];
            Stages[Place] = Point;
            for (int i = Point+1; i < Size; i++) { Stages[i] = Stages[i - 1] + Marks[i]; }
            for (int i = Point - 1; i >= 0; i--) { Stages[i] = Stages[i + 1] - Marks[i]; }
            return Stages;
        }

        // Функция поиска оценки в массиве
        private static bool CheckMark(int Mark, ref int[] AllStages)
        {
            int Size = AllStages.Count();
            for(int i=0;i<=Size;i++)
            {
                if (AllStages[i] == Mark)
                {
                    AllStages = DelPos(i, AllStages);
                    return true;
                }
            }
            return false;
        }

        // Удаление позиции из массива
        private static int[] DelPos(int Position, int[] AllStages)
        {
            int Size = AllStages.Count()-1;
            int[] NewMass = new int[Size];
            for(int i=0; i< Position; i++) { NewMass[i] = AllStages[i]; }
            for (int i = Position; i < Size; i++) { NewMass[i] = AllStages[i+1]; }
            return NewMass;
        }


    }
}
