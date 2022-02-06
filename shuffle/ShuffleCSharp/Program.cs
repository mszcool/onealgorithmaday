using mszcool.samples.algorithms;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Generating array with sorted elements...");

var arrayWithCards = new int[52];
for(int i = 0; i < arrayWithCards.Length; i++)
{
    arrayWithCards[i] = i + 1;
}
arrayWithCards.PrintArray(System.Console.Out);

// The alogorithm is implemented in the extension method for the array
arrayWithCards.ShuffleArray();

// Now, output the results:
Console.WriteLine("\n\nResults of shuffled array:");
arrayWithCards.PrintArray(Console.Out);
Console.WriteLine("");