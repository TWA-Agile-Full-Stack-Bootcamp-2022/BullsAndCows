using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private int guessTimes = 0;
        private string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
        }

        public bool CanContinue => guessTimes < 6;

        public string Guess(string guess)
        {
            if (!ValidInput(guess))
            {
                return "Wrong Input, input again";
            }

            if (guessTimes == 0)
            {
                secret = secretGenerator.GenerateSecret();
            }

            string answer = Answer(guess);
            guessTimes = answer == "4A0B" ? 6 : guessTimes + 1;
            return answer;
        }

        private string Answer(string guess)
        {
            var matchTimes = 0;
            var samePosition = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    samePosition++;
                }

                for (int j = 0; j < secret.Length; j++)
                {
                    if (guess[i] == secret[j])
                    {
                        matchTimes++;
                    }
                }
            }

            matchTimes -= samePosition;
            return samePosition + "A" + matchTimes + "B";
        }

        private bool ValidInput(string guess)
        {
            if (guess.Length != 4)
            {
                return false;
            }

            for (int i = 0; i < 4; i++)
            {
                if (!char.IsDigit(guess[i]))
                {
                    return false;
                }

                if (guess.IndexOf(guess[i]) != i)
                {
                    return false;
                }
            }

            return true;
        }
    }
}