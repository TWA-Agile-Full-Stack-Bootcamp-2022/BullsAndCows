using BullsAndCowsTest;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        private bool canContinue = true;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue { get => canContinue; set => canContinue = value; }

        public string Guess(string guessNumbers)
        {
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
            if (bullCount == SecretGenerator.MaxSize)
            {
                CanContinue = false;
            }

            return bullCount + "A" + cowCount + "B";
        }
    }
}