using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            Random random = new Random();

            HashSet<int> usedDigits = new HashSet<int>();
            StringBuilder secret = new StringBuilder();

            while (usedDigits.Count < 4)
            {
                int digit = random.Next(0, 10);
                if (!usedDigits.Contains(digit))
                {
                    usedDigits.Add(digit);
                    secret.Append(digit);
                }
            }

            return secret.ToString();
        }
    }
}
