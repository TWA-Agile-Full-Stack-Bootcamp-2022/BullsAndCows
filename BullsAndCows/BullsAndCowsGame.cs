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

        private bool IsValidGuess(string guess) => guess.Length == secret.Length
            && guess.All(char.IsDigit)
            && new HashSet<char>(guess.ToCharArray()).Count == secret.Length;
        }
    }
}