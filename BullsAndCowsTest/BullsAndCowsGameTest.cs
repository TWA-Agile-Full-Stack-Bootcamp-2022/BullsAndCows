using System;
using BullsAndCows;
using Xunit;

// 1. given 输入位数不够的数字 12 when 调用verifyInput then 返回 Wrong Input, input again
// 2. given 输入存在重复数字的数字 1123 when 调用verifyInput then 返回 Wrong Input, input again
// 3. given input 1234 and secretNumber is 1234 when countBulls then return 4
// 4. given input 4321 and secretNumber is 1234 when countCows then return 4
// 5. given input 5678 and secretNumber is 1234 when getAnswer then return '0A0B'
// 6. given input 0324 and secretNumber is 1234 when getAnswer then return '1A2B'
// 7. given answer 4A0B and input 1234 when parseGuessLog then return GuessLog
// 8. given when 调用 createSecret then 返回4位不重复的数字
// 9. given secretNumber is 1234 and input 0324 when guess then print Meaning of Answer and waiting for next input
// 10. given secretNumber is 1234 and input 1234 when guess then print guessing history

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        private static readonly int[] SecretNumbers = { 1, 2, 3, 4 };

        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4_when_countBulls_given_input_1234_and_secretNumber_is_1234()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var countBulls = game.CountBulls("1234", SecretNumbers);
            Assert.Equal(4, countBulls.Count);
        }

        [Fact]
        public void Should_return_4_when_countCows_given_input_4321_and_secretNumber_is_1234()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var countBulls = game.CountCows("4321", SecretNumbers);
            Assert.Equal(4, countBulls.Count);
        }

        [Fact]
        public void Should_return_0A0B_when_getAnswer_given_input_5678_and_secretNumber_is_1234()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var guessLog = game.GetAnswer("5678", SecretNumbers);
            Assert.Equal("0A0B", guessLog.GetAnswer());
        }

        [Fact]
        public void Should_return_1A2B_when_getAnswer_given_input_0324_and_secretNumber_is_1234()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var guessLog = game.GetAnswer("0324", SecretNumbers);
            Assert.Equal("1A2B", guessLog.GetAnswer());
        }

        [Fact]
        public void Should_return_wrong_input_when_guess_given_12()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var output = game.Guess("12");
            Assert.Equal("Wrong Input, input again", output);
        }

        [Fact]
        public void Should_return_wrong_input_when_guess_given_1123()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var output = game.Guess("2311");
            Assert.Equal("Wrong Input, input again", output);
        }

        [Fact]
        public void Should_CanContinue_is_true_when_guess_given_secretNumber_is_1234_and_input_0324()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            game.Guess("0324");
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_CanContinue_is_false_when_guess_given_secretNumber_is_1234_and_input_0324()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            game.Guess("1234");
            Assert.False(game.CanContinue);
        }
    }
}