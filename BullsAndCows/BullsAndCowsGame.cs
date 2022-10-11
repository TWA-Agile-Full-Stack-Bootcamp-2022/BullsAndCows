using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly ISecretGenerator secretGenerator;
        private readonly string screit;
        private int count;
        private bool canContinue;

        public BullsAndCowsGame(ISecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.screit = this.secretGenerator.GenerateSecret();
            this.count = 0;
            this.canContinue = true;
        }

        public string Guess(string guess)
        {
            var secret = this.screit.ToCharArray();
            var inputNumbers = guess.ToCharArray();
            var inputNumberSet = inputNumbers.ToHashSet();
            if (inputNumberSet.Count != inputNumbers.Length)
            {
                return "Wrong Input, input again";
            }

            if (inputNumbers.Length != 4)
            {
                return "Wrong Input, input again";
            }

            var match = secret.Select((t1, i) => inputNumbers.Where((t, j) => t == t1 && i == j).Count()).Sum();
            var positionErrorMatch = secret.Select((t1, i) => inputNumbers.Where((t, j) => t == t1).Count()).Sum();
            count += 1;
            if (count >= 6)
            {
                canContinue = false;
            }

            return match + "A" + (positionErrorMatch - match) + "B";
        }

        public string GetSecret()
        {
            return this.screit;
        }

        public bool IsCanContinue()
        {
            return this.canContinue;
        }
    }
}