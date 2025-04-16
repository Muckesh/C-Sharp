using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        string input = Console.ReadLine();

        // Try to parse input to integer
        if (int.TryParse(input, out int number) && number >= 0)
        {
            int result = CalculateFactorial(number);
            Console.WriteLine($"Factorial of {number} is: {result}");
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a non-negative integer.");
        }
    }
    static int CalculateFactorial(int n)
    {
        int factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}
