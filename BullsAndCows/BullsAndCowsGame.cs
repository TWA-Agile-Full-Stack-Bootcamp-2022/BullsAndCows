using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        public const int MaxGuessTime = 6;
        private const int SecretLength = 4;
        private readonly SecretGenerator secretGenerator;
        private string secret = string.Empty;
        private int guessTime = 0;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            CanContinue = true;
        }

        public bool CanContinue { get; set; }

        public string Guess(string guess)
        {
            if (CheckGuessTime())
            {
                CanContinue = false;
                return "Exceeding max guess times";
            }

            if (!CheckGuess(guess))
            {
                return "Wrong Input, input again";
            }

            if (secret.Length == 0)
            {
                secret = secretGenerator.GenerateSecret();
            }

            guessTime++;

            var counts = CountBullsAndCows(guess);
            return $"{counts[0]}A{counts[1]}B";
        }

        private bool CheckGuessTime()
        {
            return guessTime >= 6;
        }

        private bool CheckGuess(string guess)
        {
            if (guess.Length != SecretLength)
            {
                return false;
            }

            if (!guess.All(char.IsDigit))
            {
                return false;
            }

            var set = new HashSet<char>(guess.ToCharArray());
            return set.Count == SecretLength;
        }

        private List<int> CountBullsAndCows(string guess)
        {
            var counts = new List<int>();
            var guessArray = guess.ToCharArray();
            var secretArray = secret.ToCharArray();
            var countBulls = 0;
            var countCows = 0;

            for (var i = 0; i < SecretLength; i++)
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