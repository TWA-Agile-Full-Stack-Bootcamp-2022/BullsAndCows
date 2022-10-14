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
        public void Should_return_error_message_when_input_guess_number_is_wrong(string guess)
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.Equal("Wrong Input, input again", game.Guess(guess));
        }

        [Theory]
        [InlineData("1567", "1A0B")]
        [InlineData("2478", "0A2B")]
        [InlineData("0324", "1A2B")]
        [InlineData("5678", "0A0B")]
        [InlineData("4321", "0A4B")]
        [InlineData("1234", "4A0B")]
        public void Should_return_guess_result_when_input_guess_number(string guess, string result)
        {
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(s => s.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(secretGenerator.Object);

            Assert.Equal(result, game.Guess(guess));
        }

        [Fact]
        public void Should_guess_at_most_6_times()
        {
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(s => s.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(secretGenerator.Object);

            for (var count = 0; count < BullsAndCowsGame.MaxGuessTime; count++)
            {
                game.Guess("4321");
            }

            Assert.Equal("Exceeding max guess times", game.Guess("4321"));
            Assert.False(game.CanContinue);
        }
    }
}