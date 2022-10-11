using System;

namespace BullsAndCows
{
    public class SecretGenerator : ISecretGenerator
    {
        public string GenerateSecret()
        {
            return "1234";
        }
    }
}