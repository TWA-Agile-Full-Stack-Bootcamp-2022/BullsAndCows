using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret = string.Empty;

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

            if (secret.Length == 0)
            {
                secret = secretGenerator.GenerateSecret();
            }

            var counts = CountBullsAndCows(guess);
            return string.Format("{0}A{1}B", counts[0], counts[1]);
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

        private List<int> CountBullsAndCows(string guess)
        {
            var counts = new List<int>();
            var guessArray = guess.ToCharArray();
            var secretArray = secret.ToCharArray();
            var countBulls = 0;
            var countCows = 0;

            for (int i = 0; i < 4; i++)
            {
                if (guessArray[i] == secretArray[i])
                {
                    countBulls++;
                }
                else
                {
                    if (secretArray.Contains(guessArray[i]))
                    {
                        countCows++;
                    }
                }
            }

            counts.Add(countBulls);
            counts.Add(countCows);
            return counts;
        }
    }
}