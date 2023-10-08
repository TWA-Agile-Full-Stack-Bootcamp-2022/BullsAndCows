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
