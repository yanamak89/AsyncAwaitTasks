namespace ErrorHandlingApp;

public class ErrorHandlingSynchronizationContext : SynchronizationContext
{
    public override void Post(SendOrPostCallback d, object state)
    {
        try
        {
            d(state);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught in SynchronizatinContext: {ex.Message}");
        }
    }

    public override void Send(SendOrPostCallback d, object state)
    {
        try
        {
            d(state);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught in SynchronizationContext: {ex.Message}");

        }
    }
}