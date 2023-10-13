using System;
using System.Linq;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public const int MaxSize = 4;

        public virtual int[] GenerateSecret()
        {
            Random random = new Random();
            int[] digits = Enumerable.Range(1, 10).ToArray();
            int[] secretNumbers = new int[4];
            for (int rangeSize = digits.Length - 1, secretIndex = 0; secretIndex < MaxSize; secretIndex++, rangeSize--)
            {
                int randomIndex = random.Next(0, rangeSize);
                secretNumbers[secretIndex] = digits[randomIndex];
                digits[randomIndex] = digits[rangeSize];
            }

            return secretNumbers;
        }
    }
}