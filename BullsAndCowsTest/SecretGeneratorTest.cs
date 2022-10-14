using BullsAndCows;
using Xunit;
using static System.Console;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_generate_secret()
        {
            var secretGenerator = new SecretGenerator();

            var generateSecret = secretGenerator.GenerateSecret();

            Assert.Equal(4, generateSecret.Length);
            AssertSecretOnlyContainDigits(generateSecret);
            AssertSecretDigitsNotDuplicated(generateSecret);
        }

        private void AssertSecretOnlyContainDigits(string generateSecret)
        {
            Assert.True(int.Parse(generateSecret) > 0);
        }

        private void AssertSecretDigitsNotDuplicated(string generateSecret)
        {
            var charArray = generateSecret.ToCharArray();
            Assert.NotEqual(charArray[0], charArray[1]);
            Assert.NotEqual(charArray[0], charArray[2]);
            Assert.NotEqual(charArray[0], charArray[3]);
            Assert.NotEqual(charArray[1], charArray[2]);
            Assert.NotEqual(charArray[1], charArray[3]);
            Assert.NotEqual(charArray[2], charArray[3]);
        }
    }
}