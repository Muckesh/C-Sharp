using System;

public class Person {
    
    public string name;
    public int age;

    public void Introduce(){
        Console.WriteLine($"Good Morning!. Your name is {name}. You are {age} years old.");
    }
}

public class Animal {
    public string name;
    public int age;

    // constructor
    public Animal (string name, int age){
        this.name = name;
        this.age = age;
    }

    public void Introduce(){
        Console.WriteLine($"Hello!. I am a {name}. My age is {age}.");
    }

}

public class Program {
    static void Main(String[] args){
        // Person 1
        Person p1 = new Person();
        p1.name = "Alexander";
        p1.age = 24;

        p1.Introduce();

        // Person 2
        Person p2 = new Person();
        p2.name = "Tom Cruise";
        p2.age = 35;

        p2.Introduce();

        // Person 3
        Person p3 = new Person();
        p3.name = "Juice Wrld";
        p3.age = 27;

        p3.Introduce();

        // Dog
        Animal dog = new Animal("dog",5);
        dog.Introduce();

        // Cat
        Animal cat = new Animal(name: "cat", age: 3);
        cat.Introduce();
    }
}