using BullsAndCows;
using Moq;
using System.Linq;
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
        public void Should_return_4_digits_different_numbers_when_generate_secret()
        {
            // Case for Secret Generator, should be 4 digits different
            // Given
            var secretGenerator = new SecretGenerator();
            // when
            string secretGenerated = secretGenerator.GenerateSecret();
            // then
            Assert.Equal(SecretGenerator.MaxSize, secretGenerated.Distinct().Count());
        }

        [Theory]
        [InlineData("5671", "1234", "0A1B")]
        [InlineData("5621", "1234", "0A2B")]
        [InlineData("5321", "1234", "0A3B")]
        [InlineData("4321", "1234", "0A4B")]
        public void Should_return_the_right_cows_when_guess_given_matching_digits_but_in_different_position(string guessNumber, string secretGiven, string answerExpected)
        {
            // Case for Cows only
            // Given
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(genrator => genrator.GenerateSecret()).Returns(secretGiven);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            // when
            string answer = game.Guess(guessNumber);
            // then
            Assert.Equal(answerExpected, answer);
        }

        [Theory]
        [InlineData("1678", "1234", "1A0B")]
        [InlineData("1278", "1234", "2A0B")]
        [InlineData("1238", "1234", "3A0B")]
        [InlineData("1234", "1234", "4A0B")]
        public void Should_return_the_right_bulls_when_guess_given_matching_digits_are_in_their_right_position(string guessNumber, string secretGiven, string answerExpected)
        {
            // Case for Bulls only
            // Given
            // when
            // then
        }

        [Theory]
        [InlineData("1567", "1234", "1A0B")]
        [InlineData("2478", "1234", "0A2B")]
        [InlineData("0324", "1234", "1A2B")]
        public void Should_return_the_right_bulls_and_cows_when_guess_matching_digits_both_in_right_or_diffent__position(string guessNumber, string secretGiven, string answerExpected)
        {
            // Case for Cows and Bulls
            // Given
            // when
            // then
        }

        [Fact]
        public void Should_return_0A0B_when_guess_given_all_wrong_number()
        {
            // Case for All wrong number
            // Given
            // when
            // then
        }

        [Theory]
        [InlineData("1123")]
        [InlineData("12")]
        public void Should_throw_WrongInputException_when_guess_given_a_not_valid_input_gusess_number(string notValidGuessNumber)
        {
            // Case for Wrong Input Exception
            // Given
            // when
            // then
        }

        [Fact]
        public void Should_can_NOT_continue_when_guess_all_correct()
        {
            // Case for Game finished by all correct
            // Given
            // when
            // then
        }

        [Fact]
        public void Should_can_NOT_continue_when_guess_6_times()
        {
            // Case for Game finished by arrive maximum attempts
            // Given
            // when
            // then
        }
    }
}
