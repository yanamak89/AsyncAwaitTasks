using AsyncContextManager;

class Program
{
    static async Task Main(string[] args)
    {
        SynchronizationContext.SetSynchronizationContext(new CustomSynchronizationContext());
        Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}, " +
                          $"Name: {Thread.CurrentThread.Name}, " +
                          $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
        await CalculateFactorialAsync(5);
    }

    static async Task CalculateFactorialAsync(int number)
    {
        Console.WriteLine($"Before await: ThreadID: {Thread.CurrentThread.ManagedThreadId}, " +
                          $"Name: {Thread.CurrentThread.Name}, " +
                          $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
        await Task.Run(() =>
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial *= i;
            Console.WriteLine($"Factorial of {number} is {factorial}");
        });

        Console.WriteLine($"After await: ThreadID: {Thread.CurrentThread.ManagedThreadId}, " +
                          $"Name: {Thread.CurrentThread.Name}, " +
                          $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");   
    }
}