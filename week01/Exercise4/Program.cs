// using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userInput = -1;
        while (userInput != 0) 
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }
        
        int sum = 0;
        int largestNumber = numbers[0];
        int smallestNumber = numbers[0];
        foreach (int num in numbers)
        {
            sum += num;
            if (num > largestNumber) 
            {
                largestNumber = num;
            }         
            if (num > 0)   {
                if (num < smallestNumber)
                {
                    smallestNumber = num;
                }
            }
        }

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestNumber}");
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach(int num in numbers) 
        {
            Console.WriteLine(num);
        }
    }
}