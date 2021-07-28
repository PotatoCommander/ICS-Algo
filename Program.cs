using System;
using System.Collections.Generic;

namespace ICS_Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            var listA = new List<int>();
            var listB = new List<int>();

            Console.WriteLine("-------Введите число элементов массива А");
            var aLength = int.Parse(Console.ReadLine());
            for (int i = 0; i < aLength; i++)
            {
                Console.WriteLine($"Введите {i + 1} число");
                listA.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("-------Введите число элементов массива B");
            var bLength = int.Parse(Console.ReadLine());
            for (int i = 0; i < bLength; i++)
            {
                Console.WriteLine($"Введите {i + 1} число");
                listB.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("_-_-_-Массив А-_-_-_ ");
            for (int i = 0; i < aLength; i++)
            {
                Console.Write($"{listA[i]}  ");
            }

            Console.WriteLine("\nОТВЕТ_ОТВЕТ_ОТВЕТ:");
            foreach (var item in listB)
            {
                //Calling method for every number in B array
                var list = FindSequences(0, listA, item);
                ShowAnswer(list);
            }

            for (var j = 0; j < listB.Count; j++)
            {
                var bItem = listB[j];
                var listOfSequences = FindSequences(0, listA, bItem);
                Console.WriteLine(
                    $"\n   ({j+1}). Последовательности из массива А, где А[i] >= {bItem} ({j + 1}-й элемент массива B)");
                for (var i = 0; i < listOfSequences.Count; i++)
                {
                    var sequence = listOfSequences[i];
                    Console.WriteLine($"{i + 1} - ая последовательность:");
                    foreach (var value in sequence)
                    {
                        Console.Write($"{value} ");
                    }

                    Console.WriteLine();
                }

                ShowSum(listOfSequences);
            }

            Console.ReadKey();
        }

        //Main algo
        private static List<List<int>> FindSequences(int start, List<int> array, int biggerThen)
        {
            var listOfLists = new List<List<int>>();
            while (start < array.Count)
            {
                for (var i = start; i < array.Count; i++)
                {
                    if (array[i] >= biggerThen)
                    {
                        var returnArray = new List<int>();
                        for (var j = i; j < array.Count; j++)
                        {
                            if (array[j] >= biggerThen)
                            {
                                returnArray.Add(array[j]);
                                start = j + 1;
                            }
                            else
                            {
                                break;
                            }
                        }

                        listOfLists.Add(returnArray);
                        break;
                    }

                    start = i + 1;
                }
            }

            return listOfLists;
        }

        private static void ShowSum(List<List<int>> listOfLists)
        {
            if (listOfLists.Count > 0)
            {
                var max = SumOfIntList(listOfLists[0]);
                var maxList = listOfLists[0];
                foreach (var list in listOfLists)
                {
                    var sum = SumOfIntList(list);
                    if (sum > max)
                    {
                        max = sum;
                        maxList = list;
                    }
                }

                Console.WriteLine($"Максимальная сумма: {max}.");
                Console.Write("Максимальная последовательность: ");
                foreach (var value in maxList)
                {
                    Console.Write($"{value} ");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Нет соответствий.");
            }
        }

        private static void ShowAnswer(List<List<int>> listOfLists)
        {
            if (listOfLists.Count > 0)
            {
                var max = SumOfIntList(listOfLists[0]);
                foreach (var list in listOfLists)
                {
                    var sum = SumOfIntList(list);
                    if (sum > max)
                    {
                        max = sum;
                    }
                }

                Console.Write($"{max} ");
            }
            else
            {
                Console.Write(" - ");
            }
        }

        private static int SumOfIntList(List<int> list)
        {
            var sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }

            return sum;
        }
    }
}