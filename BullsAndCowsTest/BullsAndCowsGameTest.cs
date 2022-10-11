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

        [Fact]
        public void Should_return_error_message_when_input_guess_number_is_wrong()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.Equal("Wrong Input, input again", game.Guess("1A23"));
            Assert.Equal("Wrong Input, input again", game.Guess("1123"));
            Assert.Equal("Wrong Input, input again", game.Guess("12345"));
        }

        [Fact]
        public void Should_return_guess_result_when_input_guess_number()
        {
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(s => s.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(secretGenerator.Object);

            Assert.Equal("1A0B", game.Guess("1567"));
            Assert.Equal("0A2B", game.Guess("2478"));
            Assert.Equal("1A2B", game.Guess("0324"));
            Assert.Equal("0A0B", game.Guess("5678"));
            Assert.Equal("0A4B", game.Guess("4321"));
            Assert.Equal("4A0B", game.Guess("1234"));
        }
    }
}
