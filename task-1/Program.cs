Console.WriteLine("Factorial App");
Console.Write("Enter a positive integer : ");

string input = Console.ReadLine();

if (int.TryParse(input, out int number) && number >=0)
{
    int result = factorial(number);
    Console.WriteLine($"The factorial of {number} is {result}");
}else{
    Console.WriteLine("Invalid Input");
}

static int factorial(int num){
    if(num==0 || num==1) return num;
    else return num * factorial(num-1);
}