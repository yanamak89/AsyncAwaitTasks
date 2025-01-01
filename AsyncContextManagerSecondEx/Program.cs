using AsyncContextManagerSecondEx;

class Program
{
    static async Task Main(string[] args)
    {
        SynchronizationContext.SetSynchronizationContext(new CustomSynchronizationContext());
        Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}, " +
                          $"Name: {Thread.CurrentThread.Name}, " +
                          $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");

        await CalculateFactorialAsunc(5);
    }

    static async Task CalculateFactorialAsunc(int number)
    {
        Console.WriteLine($"Before await: ThreadID: {Thread.CurrentThread.ManagedThreadId}, " +
                          $"Name: {Thread.CurrentThread.Name}, " +
                          $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");

        await Task.Run(() =>
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"Factorial of {number} is {factorial}");
                Console.WriteLine($"In Task: ThreadID: {Thread.CurrentThread.ManagedThreadId}, " +
                                  $"Name: {Thread.CurrentThread.Name}, " +
                                  $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
            }
        }).ConfigureAwait(false);
        Console.WriteLine($"After await: ThreadID: {Thread.CurrentThread.ManagedThreadId}, " +
                          $"Name: {Thread.CurrentThread.Name}, " +
                          $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");

    }
}