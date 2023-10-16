using BullsAndCows;
using Xunit;
using Moq;

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

        [Fact]
        public void Should_return_wrong_input_when_input_length_is_not_4()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            var output = game.Guess("12");

            Assert.Equal("Wrong Input, input again", output);
        }

        [Fact]
        public void Should_return_wrong_input_when_input_is_not_all_digital()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            var output = game.Guess("1a23");

            Assert.Equal("Wrong Input, input again", output);
        }

        [Fact]
        public void Should_return_wrong_input_when_input_digital_is_repeat()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            var output = game.Guess("1123");

            Assert.Equal("Wrong Input, input again", output);
        }

        [Theory]
        [InlineData("1567", "1A0B")]
        [InlineData("2478", "0A2B")]
        [InlineData("0324", "1A2B")]
        [InlineData("1234", "4A0B")]
        public void Should_return_bulls_and_cows_when_guess_number(string guessInput, string guessResult)
        {
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(x => x.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            var result = game.Guess(guessInput);

            Assert.Equal(guessResult, result);
        }

        [Fact]
        public void Should_can_not_continue_when_guess_6_times()
        {
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(x => x.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            for (int i = 0; i < 6; i++)
            {
                game.Guess("5678");
            }

            Assert.False(game.CanContinue);
        }
    }
}
