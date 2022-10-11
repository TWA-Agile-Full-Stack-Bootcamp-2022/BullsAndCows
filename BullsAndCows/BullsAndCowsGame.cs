using System;
using System.Collections.Generic;
using System.Linq;

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
            var match = secret.Select((t1, i) => inputNumbers.Where((t, j) => t == t1 && i == j).Count()).Sum();

            return match + "A" + "0B";
        }

        public string GetSecret()
        {
            return this.screit;
        }
    }
}