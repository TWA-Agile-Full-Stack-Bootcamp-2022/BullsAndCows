using BullsAndCows;
using Xunit;
using System.Linq;

namespace SecretGeneratorTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_create_SecretGenerator()
        {
            var secretGenerator = new SecretGenerator();
            Assert.NotNull(secretGenerator);
        }

        [Fact]
        public void Should_generate_secret()
        {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();
            Assert.NotNull(secret);
            Assert.Equal(4, secret.Length);
        }

        [Fact]
        public void Should_secret_only_contain_digital()
        {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();
            Assert.True(int.TryParse(secret, out _));
        }

        [Fact]
        public void Should_not_duplicate_digital_in_secret()
        {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();
            Assert.Equal(4, secret.Length);
            Assert.Equal(4, secret.ToCharArray().Distinct().Count());
        }
    }
}