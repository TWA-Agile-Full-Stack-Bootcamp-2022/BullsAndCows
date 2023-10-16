using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            List<int> digitals = new List<int> { 0, 2, 3, 4, 5, 6, 7, 8, 9 };

            string secret = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(0, digitals.Count);
                secret += digitals[index].ToString();
                digitals.RemoveAt(index);
            }

            return secret;
        }
    }
}