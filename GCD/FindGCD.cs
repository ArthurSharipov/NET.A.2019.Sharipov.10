using System;

namespace GCD
{
    public class FindGCD
    {
        /// <summary>
        /// Searches for the greatest common divisor.
        /// </summary>
        /// <param name="gcdFunc"></param>
        /// <param name="nums"></param>
        /// <returns>The greatest common divisor.</returns>
        private long GCD(Func<long, long, long> gcdFunc, params long[] nums)
        {
            long gcd = gcdFunc(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = gcdFunc(gcd, nums[i]);
            }
            return gcd;
        }

        /// <summary>
        /// Calculates the greatest common divisor by the Euclid algorithm with two input parameters.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The greatest common divisor.</returns>
        public long SearchByEuclid(long x, long y)
        {
            if (x == 0 || y == 0)
                throw new ArgumentException();

            while (x != y)
            {
                if (x > y)
                {
                    long temp = x;
                    x = y;
                    y = temp;
                }
                y = y - x;
            }
            return x; ;
        }

        /// <summary>
        /// Works with a set of input parameters.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>The greatest common divisor.</returns>
        public long SearchByEuclid(params long[] nums) => GCD(SearchByEuclid, nums);

        /// <summary>
        /// Works with a set of input parameters.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>The greatest common divisor.</returns>
        public long SearchByStein(params long[] nums) => GCD(SearchByStein, nums);

        /// <summary>
        /// Calculates the greatest common divisor by the Stein algorithm with two input parameters.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The greatest common divisor.</returns>
        public long SearchByStein(long x, long y)
        {
            long gcd = 0;

            if (x == 0 || y == 0)
                throw new ArgumentException();
            else if (x == y)
                gcd = x;

            if (gcd != 0)
                return gcd;

            if ((x & 1) == 0)
                gcd = ((y & 1) == 0)
                    ? SearchByStein(x >> 1, y >> 1) << 1
                    : SearchByStein(x >> 1, y);
            else
                gcd = ((y & 1) == 0)
                    ? SearchByStein(x, y >> 1)
                    : SearchByStein(y, x > y ? x - y : y - x);
            return gcd;
        }

    }
}