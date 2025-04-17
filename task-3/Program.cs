using System;
using System.Collections.Generic;
public class Program {

    static void Main(string[] args){
        List<string> tasks = new List<string>();
        string command = "";

        Console.WriteLine("Welcome to the Task Manager");
        Console.WriteLine("Available Commands : add, remove, show, quit");

        while (command != "quit")
        {
            Console.Write("\nEnter Command : ");
            command = Console.ReadLine().Trim().ToLower();

            switch (command)
            {
                case "add":
                    Console.Write("\nEnter the task to add : ");
                    string taskToAdd = Console.ReadLine().Trim();
                    if (taskToAdd!="")
                    {
                        tasks.Add(taskToAdd);
                        Console.WriteLine($"Task : {taskToAdd} added successfully.");
                    }
                    break;

                case "remove":
                    Console.Write("\nEnter the task to remove : ");
                    string taskToRemove = Console.ReadLine().Trim();
                    if (taskToRemove!="")
                    {
                        tasks.Remove(taskToRemove);
                        Console.WriteLine($"Task : {taskToRemove} removed successfully.");
                    }
                    break;

                case "show":
                    if (tasks.Count>0)
                    {
                        Console.WriteLine("Your Tasks : ");
                        for(int i=0; i<tasks.Count; i++){
                            Console.WriteLine($"{i+1}. {tasks[i]}");
                        }
                    }else{
                        Console.WriteLine("There are no tasks to display.");
                    }
                    break;

                case "quit":
                    Console.WriteLine("Quiting Program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Unkown command. Try Again ...");
                    break;
            }
        }
    }
}

