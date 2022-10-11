using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            if (!CheckGuess(guess))
            {
                return "Wrong Input, input again";
            }

            throw new NotImplementedException();
        }

        public bool CheckGuess(string guess)
        {
            if (guess.Length != 4)
            {
                return false;
            }

            if (!guess.All(char.IsDigit))
            {
                return false;
            }

            HashSet<char> set = new HashSet<char>(guess.ToCharArray());
            if (set.Count != 4)
            {
                return false;
            }

            return true;
        }
    }
}