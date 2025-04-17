Console.WriteLine("Factorial App");
Console.WriteLine("Enter a positive integer :");
// int number = int.Parse(Console.ReadLine());
int number = Convert.ToInt32(Console.ReadLine());

double fact = 1;

for (int i = 1; i <= number; i++)
{
    fact *= i;
}

Console.WriteLine($"The Factorial of {number} is {fact}.");