// See https://aka.ms/new-console-template for more information
using Diego_Practice;



internal class Program
{
    private static void Main(string[] args)
    {
        int[] leafs = new int[] { 1, 3, 1, 4, 2, 3, 5, 4 };
        int steps = 5;
        var res = CountingElements_Lesson4.FrogRiverOne(steps, leafs);
        int[] INT = new int[] { 1023, 8184, 65472 };
        Excercises.CountConformingBitmasks(INT[0], INT[1], INT[2]);

        Excercises.Problem1(1000000);

        int test = 1041;
        Iterations_Lesson1.Binary_Gap(test);

        int[] A = new int[] { 3, 8, 9, 7, 6 };
        int K = 3;
        int[] result = Array_Lesson2.CyclicRotation(A, K);

        int[] A2 = new int[] { 9, 3, 9, 3, 9, 7, 9 };
        int response = Array_Lesson2.OddOcurrencesInArray(A2);
        int response2 = Array_Lesson2.OddOcurrencesInArray_woLINQ(A2);
    }
}