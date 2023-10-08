/*
1 3 5 7 9
-- [1,3,5,7,9]
exchange 1
-- [5,7,9,1,3]
max odd
-- 2
min even
-- No matches
first 2 odd
-- [5,7]
last 2 even
-- []
exchange 3
-- [3,5,7,9,1]
end
 */
internal class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        string commands;
        while ((commands = Console.ReadLine()) != "end")
        {
            string[] arguments = commands.Split();
            
            switch (arguments[0])
            {
                case "exchange":
                    int index = int.Parse(arguments[1]);
                    numbers = Exchange(numbers, index);
                    // Split the array and exchange the parts
                    break;
                case "max":
                    string maxType = arguments[1];
                    PrintMaxNumber(numbers, maxType);
                    break;
                case "min":
                    string minType = arguments[1];
                    PrintMinNumber(numbers, minType);
                    break;
                case "first":
                    int firstLength = int.Parse(arguments[1]);
                    string firstType = arguments[2];
                    PrintFirstElements(numbers, firstLength, firstType);
                    break;
                case "last":
                    int lastLength = int.Parse(arguments[1]);
                    string lastType = arguments[2];
                    PrintLastElements(numbers, lastLength, lastType);
                    break;
            }
        }
        // END while

        Console.WriteLine($"[{string.Join(", ", numbers)}]");
    }

    static int[] Exchange(int[] numbers, int index)
    {
        if (CheckForOutOfBound(numbers, index))
        {
            Console.WriteLine("Invalid index");
            return numbers;
        }

        int[] changedArray = new int[numbers.Length];
        int changedArrayIndex = 0;
        
        for (int i = index + 1; i < numbers.Length; i++)
        {
            changedArray[changedArrayIndex] = numbers[i];
            changedArrayIndex++;
        }

        for (int i = 0; i <= index; i++)
        {
            changedArray[changedArrayIndex] = numbers[i];
            changedArrayIndex++;
        }

        return changedArray;
    }

    static void PrintMaxNumber(int[] numbers, string type)
    {
        int maxIndex = -1;
        int maxNumber = 0;

        for(int i = 0; i < numbers.Length; i++)
        {
            if (IsOddOrEven(numbers[i], type))
            {
                if (numbers[i] >= maxNumber)
                {
                    maxNumber = numbers[i];
                    maxIndex = i;
                }
            }
        }

        PrintIndex(maxIndex);
    }

    static void PrintMinNumber(int[] numbers, string type)
    {
        int minIndex = -1;
        int minNumber = int.MaxValue;

        for(int i = 0; i < numbers.Length; i++)
        {
            if (IsOddOrEven(numbers[i], type))
            {
                if (numbers[i] <= minNumber)
                {
                    minNumber = numbers[i];
                    minIndex = i;
                }
            }
        }

        PrintIndex(minIndex);
    }
    static void PrintFirstElements(int[] numbers, int count, string type)
    {
        if (count > numbers.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        string firstElements = "";
        int elementCount = 0;
        
        for (int i = 0; i < numbers.Length ;i++)
        {
            if (IsOddOrEven(numbers[i], type))
            {
                firstElements += $"{numbers[i]}, ";
                elementCount++;
                if (elementCount >= count)
                {
                    break;
                }
            }
        }

        Console.WriteLine($"[{firstElements.Trim(' ', ',')}]");
    }
    static void PrintLastElements(int[] numbers, int count, string type)
    {
        if (count > numbers.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        string lastElements = "";
        int elementCount = 0;

        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            if (IsOddOrEven(numbers[i], type))
            {
                lastElements = $"{numbers[i]}, " + lastElements;
                elementCount++;
                if (elementCount >= count)
                {
                    break;
                }
            }
        }

        Console.WriteLine($"[{lastElements.Trim(' ', ',')}]");
    }
    static bool CheckForOutOfBound(int[] numbers, int index)
    {
        return index < 0 || index >= numbers.Length;
    }
    static void PrintIndex(int maxIndex)
    {
        if (maxIndex != -1)
        {
            Console.WriteLine(maxIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
    static bool IsOddOrEven(int number, string type)
    {
        return (type == "odd" && number % 2 != 0) ||
               (type == "even" && number % 2 == 0);
    }

}
