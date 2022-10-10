using System;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual int[] GenerateSecret()
        {
            return new int[] { 1, 2, 3, 4 };
        }
    }
}