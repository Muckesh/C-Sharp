using EventCounter;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Event Counter Application");
        Console.WriteLine("-------------------------");
        
        // Create a counter with threshold of 5
        var counter = new Counter(5);
        
        // Subscribe to the event with multiple handlers
        counter.ThresholdReached += EventHandlers.FirstHandler;
        counter.ThresholdReached += EventHandlers.SecondHandler;
        counter.ThresholdReached += EventHandlers.ThirdHandler;
        
        // Increment the counter (this will eventually trigger the event)
        Console.WriteLine("Press any key to increment the counter (press 'ctrl+c' to quit)...");
        
        while (true)
        {
            Console.ReadLine();
            counter.Increment();
        }
    
    }
}

