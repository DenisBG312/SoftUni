namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
                int n = int.Parse(Console.ReadLine());
                int sumVowels = 0;
                int sumConsonant = 0;
                int sum = 0;
                string vowels = "EeUuIiOoAa";

                int[] arrayOfSums = new int[n];

                for (int i = 0; i < n; i++)
                {
                    string name = Console.ReadLine();
                    for (int j = 0; j < name.Length; j++)
                    {
                        char currentLetter = name[j];

                        if (vowels.Contains(currentLetter))
                        {
                            sumVowels += currentLetter * name.Length;
                        }
                        else
                        {
                            sumConsonant += currentLetter / name.Length;
                        }
                    }

                    sum = sumVowels + sumConsonant;
                    arrayOfSums[i] = sum;

                    sumVowels = 0;
                    sumConsonant = 0;
                    sum = 0;

                }

                Array.Sort(arrayOfSums);
                for (int i = 0; i < arrayOfSums.Length; i++)
                {
                    Console.WriteLine(arrayOfSums[i]);
                }
        }
    }
}
