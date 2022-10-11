using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            var digits = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var secret = string.Empty;
            var random = new Random();
            for (var i = 0; i < 4; i++)
            {
                var next = random.Next(digits.Count);
                secret += digits[next].ToString();
                digits.RemoveAt(next);
            }

            return secret;
        }
    }
}