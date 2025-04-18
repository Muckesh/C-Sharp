public class EventHandlers
{
    public static void FirstHandler(object sender, EventArgs e)
    {
        Console.WriteLine("FirstHandler: The counter reached the threshold!");
    }
    
    public static void SecondHandler(object sender, EventArgs e)
    {
        Console.WriteLine("SecondHandler: Threshold achieved. Taking action...");
    }
    
    public static void ThirdHandler(object sender, EventArgs e)
    {
        Console.WriteLine("ThirdHandler: Event processed successfully.");
    }
}