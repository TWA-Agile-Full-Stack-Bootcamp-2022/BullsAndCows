using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        public const int Chances = 6;

        private readonly string secret;
        private int numberOfGuesses;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            secret = secretGenerator.GenerateSecret();
            numberOfGuesses = 0;
        }

        public bool CanContinue => numberOfGuesses < Chances;

        public string Guess(string guess)
        {
            if (!CanContinue)
            {
                return "Run out of chances";
            }

            if (!IsValidGuess(guess))
            {
                return "Wrong Input, input again";
            }

            string bullsAndCows = CountBullsAndCows(guess);

            // TBC: Whether it is necessary to accumulate numberOfGuesses when the guess is correct
            // if (bullsAndCows != $"{secret.Length}A{0}B")
            // {
            numberOfGuesses++;
            // }

            return bullsAndCows;
        }

        private bool IsValidGuess(string guess) => guess.Length == secret.Length
            && guess.All(char.IsDigit)
            && new HashSet<char>(guess.ToCharArray()).Count == secret.Length;

        private string CountBullsAndCows(string guess)
        {
            int bulls = 0;
            int cows = 0;

            char[] guessArr = guess.ToCharArray();
            char[] secretArr = secret.ToCharArray();

            for (int i = 0; i < guessArr.Length; i++)
            {
                if (secretArr[i] == guessArr[i])
                {
                    bulls++;
                    continue;
                }

                if (Array.IndexOf(secretArr, guessArr[i]) >= 0)
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}
