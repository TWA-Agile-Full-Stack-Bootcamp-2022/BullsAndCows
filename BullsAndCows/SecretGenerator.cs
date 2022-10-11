using System;

namespace BullsAndCows
{
    public class SecretGenerator : ISecretGenerator
    {
        public string GenerateSecret()
        {
            var str = string.Empty;
            while (str.Length < 4)
            {
                var r = new Random();
                var i = r.Next(0, 10);
                if (!str.Contains(i.ToString()))
                {
                    str += i.ToString();
                }
            }

            return str;
        }
    }
}