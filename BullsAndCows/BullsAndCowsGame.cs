using System;
using System.Collections.Generic;
using System.Linq;

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
            if (!guess.Length.Equals(4) || HasDuplicateNumber(guess))
            {
                return "Wrong Input, input again";
            }

            return "null";
        }

        public List<int> CountBulls(string s, int[] secretNumbers)
        {
            var charArray = s.ToCharArray();
            List<int> bulls = new List<int>();
            for (int i = 0; i < charArray.Length; i++)
            {
                var item = int.Parse(charArray[i].ToString());
                if (secretNumbers[i].Equals(item))
                {
                    bulls.Add(item);
                }
            }

            return bulls;
        }

        public List<int> CountCows(string s, int[] secretNumbers)
        {
            var charArray = s.ToCharArray();
            List<int> cows = new List<int>();
            for (int i = 0; i < charArray.Length; i++)
            {
                var item = int.Parse(charArray[i].ToString());
                if (secretNumbers.Contains(item))
                {
                    cows.Add(item);
                }
            }

            return cows;
        }

        public GuessLog GetAnswer(string input, int[] secretNumbers)
        {
            List<int> bulls = CountBulls(input, secretNumbers);
            List<int> cows = CountCows(input, secretNumbers).FindAll(e => !bulls.Contains(e));

            return ParseGuessLog(input, bulls, cows, secretNumbers.Length);
        }

        public GuessLog ParseGuessLog(string input, List<int> countBulls, List<int> countCows, int maxLength)
        {
            return new GuessLog(input, countBulls.Count + "A" + countCows.Count + "B",
                ParseMeaningOfAnswer(countBulls, countCows, maxLength));
        }

        public string ParseMeaningOfAnswer(List<int> countBulls, List<int> countCows, int maxLength)
        {
            if (countBulls.Count.Equals(maxLength))
            {
                return "all correct";
            }

            if (countCows.Count.Equals(maxLength))
            {
                return "all in wrong positions";
            }

            if (countCows.Count.Equals(0) && countBulls.Count.Equals(0))
            {
                return "all wrong";
            }

            return "x";
        }

        private bool HasDuplicateNumber(string guess)
        {
            for (int i = 0; i < 3; i++)
            {
                if (guess.LastIndexOf(guess.Substring(i, 1), StringComparison.Ordinal) > i)
                {
                    return true;
                }
            }

            return false;
        }
    }
}