using System;
using System.Collections.Specialized;
using System.Diagnostics.Metrics;

namespace Diego_Practice
{
    public static class Excercises
    {
        /*
            In this problem we consider unsigned 30-bit integers, i.e. all integers B such that 0 ≤ B < 230.

            We say that integer A conforms to integer B if, in all positions where B has bits set to 1, A has
            corresponding bits set to 1.

            For example:

            00 0000 1111 0111 1101 1110 0000 1111(BIN) = 16,244,239 conforms to
            00 0000 1100 0110 1101 1110 0000 0001(BIN) = 13,032,961, but
            11 0000 1101 0111 0000 1010 0000 0101(BIN) = 819,399,173 does not conform to
            00 0000 1001 0110 0011 0011 0000 1111(BIN) = 9,843,471.

            Write a function:

            class Solution { public int solution(int A, int B, int C); }

            that, given three unsigned 30-bit integers A, B and C, returns the number of unsigned 30-bit integers
            conforming to at least one of the given integers.

            For example, for integers:

            A = 11 1111 1111 1111 1111 1111 1001 1111(BIN) = 1,073,741,727,
            B = 11 1111 1111 1111 1111 1111 0011 1111(BIN) = 1,073,741,631, and
            C = 11 1111 1111 1111 1111 1111 0110 1111(BIN) = 1,073,741,679,

            the function should return 8, since there are 8 unsigned 30-bit integers conforming to A, B or C,
            namely:

            11 1111 1111 1111 1111 1111 0011 1111(BIN) = 1,073,741,631,
            11 1111 1111 1111 1111 1111 0110 1111(BIN) = 1,073,741,679,
            11 1111 1111 1111 1111 1111 0111 1111(BIN) = 1,073,741,695,
            11 1111 1111 1111 1111 1111 1001 1111(BIN) = 1,073,741,727,
            11 1111 1111 1111 1111 1111 1011 1111(BIN) = 1,073,741,759,
            11 1111 1111 1111 1111 1111 1101 1111(BIN) = 1,073,741,791,
            11 1111 1111 1111 1111 1111 1110 1111(BIN) = 1,073,741,807,
            11 1111 1111 1111 1111 1111 1111 1111(BIN) = 1,073,741,823.

            Write an efficient algorithm for the following assumptions:

            A, B and C are integers within the range [0..1,073,741,823].

        */
        public static int CountConformingBitmasks(int INT1, int INT2, int INT3)
        {
            if (INT1 == 0 || INT2 == 0 || INT3 == 0)
                return Convert.ToInt32(Math.Pow(2, 30));

            List<int> result = new List<int>();
            List<string> entry = new List<string>();

            string BIT1 = Convert.ToString(INT1, 2);
            string BIT2 = Convert.ToString(INT2, 2);
            string BIT3 = Convert.ToString(INT3, 2);


            entry.Add(BIT1);
            entry.Add(BIT2);
            entry.Add(BIT3);

            foreach (string BIT in entry)
            {
                var _aBIT = BIT.ToArray();
                var _combinations = Array.FindAll(_aBIT, element => element == '0').Count();
                if (_combinations == 0)
                {
                    result.Add(Convert.ToInt32(new string(BIT), 2));
                    continue;
                }

                for (double i = 0; i < Math.Pow(2, _combinations); i++)
                {
                    var number = BIT.ToArray();
                    string BITnumbtry = Convert.ToString(Convert.ToInt32(i), 2);
                    var index = number.Length;
                    for (int subindex = 0; subindex < BITnumbtry.Length; subindex++)
                    {
                        index = Array.LastIndexOf(number, '0', index - 1);
                        number[index] = BITnumbtry.ToArray()[BITnumbtry.Length - 1 - subindex];
                    }
                    var number_ = Convert.ToInt32(new string(number), 2);
                    Console.WriteLine(number_);
                    if (!result.Contains(number_))
                        result.Add(number_);
                }
            }
            var test = result.Count();
            return (result.Count());
        }

        /*

            A positive integer N is given. The goal is to find the highest power of 2 that divides N.
            In other words, we have to find the maximum K for which N modulo 2^K is 0.

            For example, given integer N = 24 the answer is 3, because 2^3 = 8 is the highest
            power of 2 that divides N.

            Write a function:

            class Solution { public int solution(int N); }

            that, given a positive integer N, returns the highest power of 2 that divides N.
            For example, given integer N = 24, the function should return 3, as explained above.

            Assume that:

            N is an integer within the range [1..1,000,000,000].

            In your solution, focus on correctness. The performance of your solution will not be the focus
            of the assessment.
        */
        public static int Problem1(int N)
        {
            if (N == 1)
            {
                return 0;
            }
            var max = Math.Truncate(Math.Sqrt(N));
            int result =0;
            while (max>0)
            {
                var left = N % Math.Pow(2, max);
                if ( left > 0)
                {
                    max--;
                    continue;
                }
                else
                {
                    result = Convert.ToInt32(max);
                    break;
                }
                    
            }
            return result;
        }
    }


}