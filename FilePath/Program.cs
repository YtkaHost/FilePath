using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select task (1, 2, 3):");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Task1();
                break;
            case "2":
                Task2();
                break;
            case "3":
                Task3();
                break;
            default:
                Console.WriteLine("Wrong choice");
                break;
        }
    }

    static void Task1()
    {
        Console.WriteLine("Enter the path to the file:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine("File content:");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("File not found");
        }
    }

    static void Task2()
    {
        Console.WriteLine("Enter array elements separated by a space:");
        string input = Console.ReadLine();
        int[] array = input.Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Select an operation: \n1 - Save array to file \n2 - Load array from file");
        string choice = Console.ReadLine();

        string filePath = "array.txt";

        if (choice == "1")
        {
            File.WriteAllLines(filePath, array.Select(x => x.ToString()));
            Console.WriteLine("Array saved to file");
        }
        else if (choice == "2")
        {
            if (File.Exists(filePath))
            {
                int[] loadedArray = File.ReadAllLines(filePath).Select(int.Parse).ToArray();
                Console.WriteLine("Array loaded from file:");
                Console.WriteLine(string.Join(" ", loadedArray));
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
        else
        {
            Console.WriteLine("Wrong choice");
        }
    }

    static void Task3()
    {
        Random random = new Random();
        int[] numbers = Enumerable.Range(0, 10000).Select(n => random.Next(0, 10000)).ToArray();

        string evenFilePath = "even_numbers.txt";
        string oddFilePath = "odd_numbers.txt";

        int[] evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
        int[] oddNumbers = numbers.Where(x => x % 2 != 0).ToArray();

        File.WriteAllLines(evenFilePath, evenNumbers.Select(x => x.ToString()));
        File.WriteAllLines(oddFilePath, oddNumbers.Select(x => x.ToString()));

        Console.WriteLine("Even numbers are saved to the file:" + evenFilePath);
        Console.WriteLine("Odd numbers are saved to the file:" + oddFilePath);

        Console.WriteLine("Number of even numbers:" + evenNumbers.Length);
        Console.WriteLine("Number of odd numbers: " + oddNumbers.Length);
    }
}
