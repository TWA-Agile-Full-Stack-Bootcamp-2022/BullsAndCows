using BullsAndCows;
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
    }
}
