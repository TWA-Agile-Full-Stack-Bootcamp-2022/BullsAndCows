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
            throw new NotImplementedException();
        }

        public int CountBulls(string s, int[] secretNumbers)
        {
            var charArray = s.ToCharArray();
            int count = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (secretNumbers[i].Equals(int.Parse(charArray[i].ToString())))
                {
                    count++;
                }
            }

            return count;
        }

        public int CountCows(string s, int[] secretNumbers)
        {
            var charArray = s.ToCharArray();
            int count = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (secretNumbers.Contains(int.Parse(charArray[i].ToString())))
                {
                    count++;
                }
            }

            return count;
        }

        public string GetAnswer(string s, int[] secretNumbers)
        {
            return CountBulls(s, secretNumbers) + "A" + CountCows(s, secretNumbers) + "B";
        }
    }
}