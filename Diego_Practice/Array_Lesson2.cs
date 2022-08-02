using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Linq;
namespace Diego_Practice
{
    public static class Array_Lesson2
    {
      /*An array A consisting of N integers is given.Rotation of the array means that each element is shifted right by one index, 
        and the last element of the array is moved to the first place.For example, the rotation of array A = [3, 8, 9, 7, 6]
        is [6, 3, 8, 9, 7] (elements are shifted right by one index and 6 is moved to the first place).

        The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.
        Write a function:
        class Solution { public int[] solution(int[] A, int K); }
        that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.
        For example, given
        A = [3, 8, 9, 7, 6]
        K = 3
        the function should return [9, 7, 6, 3, 8]. Three rotations were made:
        [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
        [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
        [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]
        For another example, given
        A = [0, 0, 0]
        K = 1
        the function should return [0, 0, 0]
        Given
        A = [1, 2, 3, 4]
        K = 4
        the function should return [1, 2, 3, 4]
        Assume that:
        N and K are integers within the range [0..100];
        each element of array A is an integer within the range[−1, 000..1, 000].

        In your solution, focus on correctness.The performance of your solution will not be the focus of the assessment. */
        //OBSERVATION NEED TO TAKE IN TO ACCOUNT EMPTY ARRAYS AND OVERSIZE REQUESTS !!!!!
        public static int[] CyclicRotation(int[] enteredArray, int numberOfMovements)
        {
            int length = enteredArray.Length;
            int[] result = new int[length];
            int startOld;
            if ((numberOfMovements % length)> 0 && numberOfMovements> length)
            {
                int newMovements = numberOfMovements % length;
                startOld = length -1 - newMovements;
                for (int i = 0; i<length; i++)
                {
                    startOld = startOld>length-1? startOld + i: startOld-length;
                    result[i] = enteredArray[startOld];
                }
            }
            else
            {
                int newMovements = numberOfMovements % length;
                startOld = length -1 - numberOfMovements;
                for (int i = 0; i < length; i++)
                {
                    startOld = startOld + 1;
                    startOld = (startOld >=(length))? (startOld - length):(startOld);
                    Console.Write(startOld);
                    result[i] = enteredArray[startOld];
                }
            }
            return result;
        }
        /*  A non-empty array A consisting of N integers is given.The array contains an odd number of elements, 
            and each element of the array can be paired with another element that has the same value, except for 
            one element that is left unpaired.
            For example, in array A such that:
            A[0] = 9  A[1] = 3  A[2] = 9
            A[3] = 3  A[4] = 9  A[5] = 7
            A[6] = 9
            the elements at indexes 0 and 2 have value 9,
            the elements at indexes 1 and 3 have value 3,
            the elements at indexes 4 and 6 have value 9,
            the element at index 5 has value 7 and is unpaired.
            Write a function:
            class Solution { public int solution(int[] A); }
            that, given an array A consisting of N integers fulfilling the above conditions, returns the value of
            the unpaired element.

            For example, given array A such that:

            A[0] = 9  A[1] = 3  A[2] = 9
            A[3] = 3  A[4] = 9  A[5] = 7
            A[6] = 9
        
            the function should return 7, as explained in the example above.
            Write an efficient algorithm for the following assumptions:

            N is an odd integer within the range [1..1,000,000];
            each element of array A is an integer within the range[1..1, 000, 000, 000];
            all but one of the values in A occur an even number of times.
        */
        public static int OddOcurrencesInArray(int[] Array)
        {
            var test = Array.GroupBy(grp => grp).Select(grp => new
            {
                Value = grp.Key,
                Count = grp.Count()
            });

            var result = test.Where(element => element.Count % 2 > 0).FirstOrDefault();

            return result.Value;
        }

        public static int OddOcurrencesInArray_woLINQ(int[] Array)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i=0; i<Array.Length;i++)
            {
                if (result.ContainsKey(Array[i]))
                {
                    result[Array[i]] = result[Array[i]] +1 ;
                    if (result[Array[i]] % 2 == 0)
                    {
                        result.Remove(Array[i]);
                    }
                }
                else
                {
                    result[Array[i]] = 1;
                }
            }
            var key = result.Keys;
            int answer = 0;
            foreach (var k in key)
            {
                answer = k;
                break;
            }

            return answer;
        }
    }
}

