using BullsAndCows;
using Moq;
using System;
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
        public void Should_return_Wrong_Input_when_Length_less_than_4()
        {
            var mock = new Mock<SecretGenerator>();
            BullsAndCowsGame bullsAndCowsGame = new BullsAndCowsGame(mock.Object);
            string answer = bullsAndCowsGame.Guess("123");
            Assert.Equal("Wrong Input, input again", answer);
        }

        [Fact]
        public void Should_invalid_when_input_has_nondigit()
        {
            Mock<SecretGenerator> mock = new Mock<SecretGenerator>();
            BullsAndCowsGame bullsAndCowsGame = new BullsAndCowsGame(mock.Object);
            string answer = bullsAndCowsGame.Guess("123a");
            Assert.Equal("Wrong Input, input again", answer);
        }

        [Fact]
        public void Should_invalid_when_input_has_duplication()
        {
            Mock<SecretGenerator> mock = new Mock<SecretGenerator>();
            BullsAndCowsGame bullsAndCowsGame = new BullsAndCowsGame(mock.Object);
            string answer = bullsAndCowsGame.Guess("1231");
            Assert.Equal("Wrong Input, input again", answer);
        }

        [Fact]
        public void Should_generate_secret_when_first_guess()
        {
            Mock<SecretGenerator> mock = new Mock<SecretGenerator>();
            BullsAndCowsGame bullsAndCowsGame = new BullsAndCowsGame(mock.Object);
            mock.Verify(x => x.GenerateSecret(), Times.Never);
            bullsAndCowsGame.Guess("1234");
            mock.Verify(x => x.GenerateSecret(), Times.Once);
            bullsAndCowsGame.Guess("2345");
            mock.Verify(x => x.GenerateSecret(), Times.Once);
        }

        [Fact]
        public void Should_not_able_to_continue_when_reach_max_guess_times()
        {
            Mock<SecretGenerator> mock = new Mock<SecretGenerator>();
            BullsAndCowsGame game = new BullsAndCowsGame(mock.Object);
            for (int i = 0; i < 6; i++)
            {
                Assert.True(game.CanContinue);
                game.Guess("1234");
            }

            Assert.False(game.CanContinue);
        }
    }
}
