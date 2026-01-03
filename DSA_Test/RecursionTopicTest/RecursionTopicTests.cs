using MyApp.Console.RecursionTopic;

namespace DSA_Test.RecursionTopicTest
{
    public class RecursionTopicTests
    {
        public RecursionTopicTests()
        {
            // Ensure test isolation
            RecursionTopic.memo.Clear();
        }

        // ===================== FACTORIAL =====================

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(5, 120)]
        [InlineData(10, 3628800)]
        public void CalculateFactorial_GivenValidNumber_WhenCalled_ThenReturnsCorrectFactorial(
            int input, long expected)
        {
            // Arrange (Given)

            // Act (When)
            var result = RecursionTopic.CalculateFactorial(input);

            // Assert (Then)
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateFactorial_GivenNegativeNumber_WhenCalled_ThenThrowsArgumentOutOfRangeException()
        {
            // Arrange (Given)
            var input = -1;

            // Act (When)
            Action act = () => RecursionTopic.CalculateFactorial(input);

            // Assert (Then)
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        // ===================== FIBONACCI =====================

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        public void CalculateFibonacci_GivenValidNumber_WhenCalled_ThenReturnsCorrectFibonacci(
            long input, long expected)
        {
            // Arrange (Given)

            // Act (When)
            var result = RecursionTopic.CalculateFibonacci(input);

            // Assert (Then)
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateFibonacci_GivenNegativeNumber_WhenCalled_ThenThrowsArgumentOutOfRangeException()
        {
            // Arrange (Given)
            var input = -5;

            // Act (When)
            Action act = () => RecursionTopic.CalculateFibonacci(input);

            // Assert (Then)
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void CalculateFibonacci_GivenCachedValue_WhenCalledAgain_ThenUsesMemoizedResult()
        {
            // Arrange (Given)
            var input = 20;
            var firstCallResult = RecursionTopic.CalculateFibonacci(input);
            var memoCountAfterFirstCall = RecursionTopic.memo.Count;

            // Act (When)
            var secondCallResult = RecursionTopic.CalculateFibonacci(input);

            // Assert (Then)
            Assert.Equal(firstCallResult, secondCallResult);
            Assert.Equal(memoCountAfterFirstCall, RecursionTopic.memo.Count);
        }
    }
}
