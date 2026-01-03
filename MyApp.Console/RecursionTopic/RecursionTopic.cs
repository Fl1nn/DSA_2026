namespace MyApp.Console.RecursionTopic
{
    public class RecursionTopic
    {

        //time O(n) - space O(n)
        public static long CalculateFactorial(int num)
        {
            if (num < 0)
                throw new ArgumentOutOfRangeException(nameof(num));


            if (num == 0 || num == 1) return 1;

            return num * CalculateFactorial(num - 1);
        }

        public static Dictionary<long, long> memo = new();
        public static long CalculateFibonacci(long num)
        {
            if (num < 0) throw new ArgumentOutOfRangeException(nameof(num));

            if (num <= 1) return num;

            if (memo.ContainsKey(num))
            {
                return memo[num];
            }

            memo[num] = CalculateFibonacci(num - 1) + CalculateFibonacci(num - 2);

            return memo[num];
        }
    }
}
