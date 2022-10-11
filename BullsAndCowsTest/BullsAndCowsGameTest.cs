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
            Assert.True(game.IsCanContinue());
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

        [Fact]
        public void Should_return_1A0B_when_guess_given_input1678_and_secret_1234()
        {
            //given
            var mockGenerator = new Mock<ISecretGenerator>();
            const string secret = "1234";
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            var guess = game.Guess("1678");
            Assert.Equal("1A0B", guess);
        }

        [Fact]
        public void Should_return_1A2B_when_guess_given_input0324_and_secret_1234()
        {
            //given
            var mockGenerator = new Mock<ISecretGenerator>();
            const string secret = "1234";
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            var guess = game.Guess("0324");
            Assert.Equal("1A2B", guess);
        }

        [Fact]
        public void Should_return_wrong_input_when_guess_given_input1124_and_secret_1234()
        {
            //given
            var mockGenerator = new Mock<ISecretGenerator>();
            const string secret = "1234";
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            var guess = game.Guess("1124");
            Assert.Equal("Wrong Input, input again", guess);
        }

        [Fact]
        public void Should_return_wrong_input_when_guess_given_input12_and_secret_1234()
        {
            //given
            var mockGenerator = new Mock<ISecretGenerator>();
            const string secret = "1234";
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            var guess = game.Guess("12");
            Assert.Equal("Wrong Input, input again", guess);
        }

        [Fact]
        public void Should_set_can_be_continue_false_when_guess_given_input0324_and_secret_1234_over_6()
        {
            //given
            var mockGenerator = new Mock<ISecretGenerator>();
            const string secret = "1234";
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            for (int i = 0; i < 6; i++)
            {
                game.Guess("0324");
            }

            //then
            Assert.False(game.IsCanContinue());
        }
    }
}