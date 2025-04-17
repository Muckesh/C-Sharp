using System;
using System.Collections.Generic;
using System.Linq;

class Student {
    public string Name {
        get;
        set;
    }

    public double Grade {
        get;
        set;
    }

    public int Age {
        get;
        set;
    }

}


public class Program {
    static void Main(string[] args){
        List<Student> students = new List<Student>{
            new Student{ Name = "Alexander", Grade = 85.5, Age=21},
            new Student{ Name= "Tom Cruise", Grade = 92, Age= 19},
            new Student{ Name = "Juice Wrld", Grade=76, Age=20},
            new Student{ Name = "Stacy", Grade = 88, Age=25},
            new Student{ Name = "Victor", Grade= 67.5, Age=23},
        };

        Console.WriteLine("\nAll Students ");
        foreach(var s in students){
            Console.WriteLine($"Name : {s.Name} - Grade : {s.Grade} - Age : {s.Age}.");
        }

        Console.Write("\nEnter Grade Threshold : ");
        string input = Console.ReadLine();

        double threshold = Convert.ToDouble(input);
        // Filtering
        var highScorers = students.Where(student => student.Grade > threshold);
        // Where(...) -> used to filter items
        // student => student.Grade > 80 -> lambda expression

        // Sorting
        var sorted = highScorers.OrderBy(student => student.Name);
        // var highScorers = students.Where(student => student.Grade > threshold).OrderBy(s => s.Name);

        // OrderBy(...) -> used to sort items
        
        var sortedDesc = highScorers.OrderByDescending(student => student.Grade);

        Console.WriteLine("\nHigh Scorers with Grade > Threshold");
        foreach(var s in highScorers){
            Console.WriteLine($"Name : {s.Name} - Grade : {s.Grade} - Age : {s.Age}.");
        }


        Console.WriteLine("\nHigh Scorers sorted by Name");
        foreach(var s in sorted){
            Console.WriteLine($"Name : {s.Name} - Grade : {s.Grade} - Age : {s.Age}.");
        }

        Console.WriteLine("\nHigh Scorers sorted by Grade in Descending Order");
        foreach(var s in sortedDesc){
            Console.WriteLine($"Name : {s.Name} - Grade : {s.Grade} - Age : {s.Age}.");
        }
    }
}