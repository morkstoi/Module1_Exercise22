using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Exercise_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создадим массив случайных чисел. Введите, пожалуйста, размер массива, который нам нужно создать.");
            int arrayLen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[] arrayWithRandom = new int[arrayLen];

            Random random = new Random();
            for (int i = 0; i < arrayLen; i++)
            {
                arrayWithRandom[i] = random.Next(0, 100);
            }
            Console.WriteLine("Ваш массив, сформированный из случайных чисел:");
            for (int i = 0; i < arrayLen; i++)
            {
                Console.WriteLine(arrayWithRandom[i]);
            }
            Console.WriteLine();
            Console.WriteLine("А теперь найдем сумму чисел массива и его максимальное число при помощи цепочку методов.");

            Action<object> action = new Action<object>(CalculateSumFromArray);
            Task task1 = new Task(action, arrayWithRandom);

            Action<Task, object> actionTask = new Action<Task, object>(FindMaxFromArray);
            Task task2 = task1.ContinueWith(actionTask, arrayWithRandom);
            task1.Start();

            Console.ReadKey();
        }

        static void CalculateSumFromArray(object arrayObject)
        {
            int[] array = (int[])arrayObject;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("Сумма чисел в вашем массиве равна {0}.", sum);
        }


        static void FindMaxFromArray(Task task, object arrayObject)
        {
            int[] array = (int[])arrayObject;
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine("Максимальное число в вашем массиве равно {0}.", max);
        }
    }
}