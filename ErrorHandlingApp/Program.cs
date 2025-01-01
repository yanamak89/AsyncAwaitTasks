using ErrorHandlingApp;

class Program
{
    public static void Main(string[] args)
    {
        SynchronizationContext.SetSynchronizationContext(new ErrorHandlingSynchronizationContext());
        Console.WriteLine("Starting program...");

        try
        {
            // Виклик асинхронного методу з типом void
            ThrowingAsyncVoidMethod();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception caught in Main: {e.Message}");
        }
        Thread.Sleep(1000);
        Console.WriteLine("Program completed.");
    }

    static async void ThrowingAsyncVoidMethod()
    {
        Console.WriteLine($"Throwing exception on ThreadID: {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(100);
        throw new InvalidOperationException("An error occured in async void method.");
    }
}