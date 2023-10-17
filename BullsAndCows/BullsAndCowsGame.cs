using System;

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
            if (!ValidInput(guess))
            {
                return "Wrong Input, input again";
            }

            return guess;
        }

        private bool ValidInput(string guess)
        {
            if (guess.Length != 4)
            {
                return false;
            }

            return true;
        }
    }
}