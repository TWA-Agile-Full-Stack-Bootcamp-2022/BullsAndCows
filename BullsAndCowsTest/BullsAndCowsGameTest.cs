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
        public void Should_generate_secret_when_game_init()
        {
            //given
            var mockGenerator = new Mock<ISecretGenerator>();
            const string secret = "Secret";
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            //when
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //then
            Assert.Equal(secret, game.GetSecret());
        }

        [Fact]
        public void Should_return_0A0B_when_guess_given_input5678_and_secret_1234()
        {
            //given
            var mockGenerator = new Mock<ISecretGenerator>();
            const string secret = "1234";
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            var guess = game.Guess("5678");
            Assert.Equal("0A0B", guess);
        }
    }
}