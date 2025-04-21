using System;
using System.Reflection;

// defining custom Attribute -> Runnable
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute {

}

public class DemoA {

    [Runnable]
    public void Greet(){
        Console.WriteLine("Hi from DemoA.Greet().");
    }

    public void NotToRun(){
        Console.WriteLine("This will not run.");
    }
}

public class DemoB {
    [Runnable]
    public void DisplayTime(){
        Console.WriteLine($"Time : {DateTime.Now.ToShortTimeString()}");
    }

    [Runnable]
    public void RandomNumber(){
        Console.WriteLine($"Random Number : {new Random().Next(1,100)}");
    }
}

public class Program {
    static void Main(){
        Console.WriteLine("Looking for methods with [Runnable] attribute...\n");

        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach(var type in types){
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach(var method in methods){
                if (method.GetCustomAttribute(typeof(RunnableAttribute))!=null)
                {
                    object? instance = null;

                    if (!method.IsStatic)
                    {
                        instance = Activator.CreateInstance(type);
                    }

                    method.Invoke(instance,null);
                    Console.WriteLine();
                }
            }
        }

        Console.WriteLine("Finished executing [Runnable] methods.");

    }
}