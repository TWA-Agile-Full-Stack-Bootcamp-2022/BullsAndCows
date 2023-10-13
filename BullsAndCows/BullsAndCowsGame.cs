using System;
using System.Collections.Immutable;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            string answer = "0A";
            int cowCount = 0;
            guess.ToImmutableList().ForEach(guessNumber =>
                {
                    if (secret.Contains(guessNumber))
                    {
                        cowCount++;
                    }
                });
            return answer + cowCount + "B";
        }
    }
}