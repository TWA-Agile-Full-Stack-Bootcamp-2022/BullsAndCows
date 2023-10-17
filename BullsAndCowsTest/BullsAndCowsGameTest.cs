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
    }
}
