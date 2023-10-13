using BullsAndCowsTest;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private const int MaxAttemtTimes = 6;
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue { get; set; } = true;
        public int AttemtTimes { get; set; } = 0;

        public string Guess(string guessNumbers)
        {
            AttemtTimes++;
            if (guessNumbers.Distinct().Count() != SecretGenerator.MaxSize)
            {
                throw new WrongInputException();
            }

            int bullCount = 0;
            int cowCount = 0;
            int guessNumberIndex = 0;
            guessNumbers.ToImmutableList().ForEach(guessNumber =>
                {
                    int matchedSceretNumberIdex = secret.IndexOf(guessNumber);
                    if (matchedSceretNumberIdex >= 0)
                    {
                        if (matchedSceretNumberIdex == guessNumberIndex)
                        {
                            bullCount++;
                        }
                        else
                        {
                            cowCount++;
                        }
                    }

                    guessNumberIndex++;
                });
            if (bullCount == SecretGenerator.MaxSize || AttemtTimes.Equals(MaxAttemtTimes))
            {
                CanContinue = false;
            }

            return bullCount + "A" + cowCount + "B";
        }
    }
}