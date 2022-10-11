using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly ISecretGenerator secretGenerator;
        private readonly string screit;

        public BullsAndCowsGame(ISecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.screit = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var secret = this.screit.ToCharArray();
            var inputNumbers = guess.ToCharArray();
            var match = 0;
            for (var i = 0; i < secret.Length; i++)
            {
                for (var j = 0; j < inputNumbers.Length; j++)
                {
                    if (inputNumbers[j] == secret[i] && i == j)
                    {
                        match += 1;
                    }
                }
            }

            return match + "A" + "0B";
        }

        public string GetSecret()
        {
            return this.screit;
        }
    }
}