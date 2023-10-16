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
    }
}
