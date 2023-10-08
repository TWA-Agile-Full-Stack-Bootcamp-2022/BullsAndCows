using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Theory]
        [InlineData("12")]
        [InlineData("1A23")]
        [InlineData("1123")]
        [InlineData("12345")]
        public void Should_return_error_message_when_guess_is_invalid(string guess)
        {
            // given
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            // when
            var output = game.Guess(guess);

            // then
            Assert.Equal("Wrong Input, input again", output);
        }

        [Theory]
        [InlineData("1234", "1567", "1A0B")]
        [InlineData("1234", "2478", "0A2B")]
        [InlineData("1234", "0324", "1A2B")]
        [InlineData("1234", "5678", "0A0B")]
        [InlineData("1234", "4321", "0A4B")]
        [InlineData("1234", "1234", "4A0B")]
        public void Should_return_bulls_and_cows_when_guess_is_valid(string secret, string guess, string expectedOutput)
        {
            // given
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(secretGenerator.Object);

            // when
            var output = game.Guess(guess);

            // then
            Assert.Equal(expectedOutput, game.Guess(guess));
        }

        [Theory]
        [InlineData("1234")]
        public void Should_return_error_message_when_number_of_guesses_exceeds_6(string secret)
        {
            // given
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(secretGenerator.Object);

            // when
            for (var count = 0; count < 6; count++)
            {
                game.Guess("5678");
            }

            // then
            Assert.Equal("Run out of chances", game.Guess("1234"));
        }
    }
}
