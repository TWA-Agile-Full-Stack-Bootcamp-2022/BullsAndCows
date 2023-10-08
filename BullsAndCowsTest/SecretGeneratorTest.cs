using System.Collections.Generic;
using BullsAndCows;
using Xunit;
using System.Linq;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_generate_secret_containing_4_characters()
        {
            // given
            var secretGenerator = new SecretGenerator();

            // when
            string secret = secretGenerator.GenerateSecret();

            // then
            Assert.Equal(4, secret.Length);
        }

        [Fact]
        public void Should_generate_secret_containing_4_digit_characters()
        {
            // given
            var secretGenerator = new SecretGenerator();

            // when
            string secret = secretGenerator.GenerateSecret();

            // then
            Assert.True(secret.All(char.IsDigit));
        }

        [Fact]
        public void Should_generate_secret_containing_4_different_characters()
        {
            // given
            var secretGenerator = new SecretGenerator();

            // when
            string secret = secretGenerator.GenerateSecret();

            // then
            Assert.Equal(secret.Length, new HashSet<char>(secret.ToCharArray()).Count);
        }
    }
}
