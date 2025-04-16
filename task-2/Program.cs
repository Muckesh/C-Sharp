using System;

public class Person
{
    // Properties
    public string Name;
    public int Age;

    // Method
    public void Introduce()
    {
        Console.WriteLine($"Hi, I'm {Name} and I am {Age} years old.");
    }
}

class Program
{
    static void Main()
    {
        // Create first person
        Person person1 = new Person();
        person1.Name = "Alice";
        person1.Age = 25;
        person1.Introduce();

        // Create second person
        Person person2 = new Person();
        person2.Name = "Bob";
        person2.Age = 30;
        person2.Introduce();

        // Create third person
        Person person3 = new Person();
        person3.Name = "Charlie";
        person3.Age = 22;
        person3.Introduce();
    }
}
