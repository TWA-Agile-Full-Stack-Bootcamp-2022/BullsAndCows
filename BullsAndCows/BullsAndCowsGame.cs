using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        private int guessTimes = 0;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => guessTimes < 6;

        public string Guess(string guess)
        {
            if (guess.Length != 4 || !guess.All(char.IsDigit) || guess.Distinct().Count() != 4)
            {
                return "Wrong Input, input again";
            }

            guessTimes++;

            var bullsCount = 0;
            var cowsCount = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    bullsCount++;
                }
                else if (secret.Contains(guess[i]))
                {
                    cowsCount++;
                }
            }

            return $"{bullsCount}A{cowsCount}B";
        }
    }
}