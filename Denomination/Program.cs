using System;
using System.Collections.Generic;
using System.Linq;

namespace Denomination
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] DenominationArray = { 10, 50, 100 };
            int[] targetSumArray = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

            foreach (var targetSum in targetSumArray)
            {
                List<List<int>> answerList = combinationSum(DenominationArray.ToList(), targetSum);

                Console.WriteLine("Start possible combinations for: " + targetSum);

                for (int i = 0; i < answerList.Count; i++)
                {
                    var combination = answerList[i].Select(s => s.ToString()).Aggregate((p, q) => p + ',' + q);
                    Console.WriteLine(combination);
                }
                Console.WriteLine("End Combination for:" + targetSum);
                Console.ReadKey();
            }
        }

        public static List<List<int>> combinationSum(List<int> inputArray, int targetSum)
        {
            List<List<int>> answerList = new List<List<int>>();
            List<int> tempAnswer = new List<int>();

            findCombination(answerList, inputArray, targetSum, 0, tempAnswer);
            return answerList;
        }

        static void findCombination(List<List<int>> answerList, List<int> inputList, int targetSum, int index, List<int> tempAnswer)
        {
            if (targetSum == 0)
            {
                answerList.Add(new List<int>(tempAnswer));
                return;
            }

            for (int i = index; i < inputList.Count; i++)
            {
                var leftSum = targetSum - inputList[i];
                if (leftSum >= 0)
                {
                    tempAnswer.Add(inputList[i]);
                    findCombination(answerList, inputList, leftSum, i, tempAnswer);
                    tempAnswer.Remove(inputList[i]);
                }
            }
        }

    }
}

