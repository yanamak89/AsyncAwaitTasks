namespace AsyncContextManager;

public class CustomSynchronizationContext : SynchronizationContext
{
    public override void Post(SendOrPostCallback d, object state)
    {
        Thread thread = new Thread(() =>
        {
            Thread.CurrentThread.Name = "CustomThread";
            d(state);
        });
        thread.Start();
    }
}