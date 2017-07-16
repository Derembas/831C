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
            for(int i=0; i < k; i++) { Marks[i] = Convert.ToInt32(marks[i]); }

            // Заполняем массив баллов из памяти
            string[] remembered= Console.ReadLine().Split(' '); // Баллы в памяти
            int[] Remembered = new int[n];
            for (int i = 0; i < n; i++) { Remembered[i] = Convert.ToInt32(remembered[i]); }

            List<int> Answers =new List<int>();
            for (int i=0; i<k;i++)
            {
                
                List<int> CurMass = AllStages(Marks, i, Remembered[0]);
                int CurAns = CurMass.First()- Marks[0];
                bool Next=true;
                for(int j=0; j<n; j++)
                {
                    if (!CurMass.Remove(Remembered[j]))
                    {
                        Next = false;
                        break;
                    }
                }
                if (Next) { Answers.Add(CurAns); }
            }
            Console.WriteLine(Answers.Distinct().Count());
            Console.ReadLine();
        }

        // Функция создания массива оценок
        private static List<int> AllStages(int[] Marks, int Place, int Point)
        {
            int Size = Marks.Count();
            int[] Stages = new int[Size];
            Stages[Place] = Point;
            for (int i = Place + 1; i < Size; i++) { Stages[i] = Stages[i - 1] + Marks[i]; }
            for (int i = Place - 1; i >= 0; i--) { Stages[i] = Stages[i + 1] - Marks[i+1]; }
            return Stages.ToList();
        }
    }
}
