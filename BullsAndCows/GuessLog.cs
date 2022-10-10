using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class GuessLog : Exception
    {
        private readonly string answer;
        private readonly string input;
        private readonly string meaningOfAnswer;

        public GuessLog(string input, string answer, string meaningOfAnswer)
        {
            this.answer = answer;
            this.input = input;
            this.meaningOfAnswer = meaningOfAnswer;
        }

        public override string ToString()
        {
            return this.input + "\t" + this.answer + "\t" + this.meaningOfAnswer;
        }

        public string GetAnswer()
        {
            return answer;
        }

        public string GetInput()
        {
            return input;
        }

        public string GetMeaningOfAnswer()
        {
            return meaningOfAnswer;
        }
    }
}