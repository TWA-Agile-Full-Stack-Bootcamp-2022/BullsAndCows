using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly ISecretGenerator secretGenerator;
        private readonly string screit;
        public BullsAndCowsGame(ISecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.screit = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            throw new NotImplementedException();
        }

        public string GetSecret()
        {
            return this.screit;
        }
    }
}