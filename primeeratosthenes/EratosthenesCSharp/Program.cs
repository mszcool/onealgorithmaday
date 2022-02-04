const int STATE_UNTOUCHED = 0;
const int STATE_PRIME = 1;
const int STATE_STRIKED = 2;

System.Console.WriteLine("Please enter the maximum number up to which you want to get all prime numbers: ");
var numberMaxToValidateInput = System.Console.ReadLine();
var numberMaxToValidate = 0;
if (!int.TryParse(numberMaxToValidateInput, out numberMaxToValidate))
{
    LogMessageToConsole($"Please enter a valid integer number. You entered '{numberMaxToValidateInput}' which is not a valid number!");
    System.Environment.Exit(-1);
}
if (numberMaxToValidate <= 3)
{
    LogMessageToConsole("Please enter a positive number larger than 3, there's no point in doing the sieve for numbers that are primes, only!");
    System.Environment.Exit(-1);
}

// Next start the validation for the Prime number.
int numPrimes = 0;
var result = FindPrimesBySieve(numberMaxToValidate);

LogMessageToConsole($"Primes found up to the number {numberMaxToValidate}:");
var resultEnumerator = result.GetEnumerator();
while(resultEnumerator.MoveNext())
{
    numPrimes++;
    Console.Write($"{resultEnumerator.Current} ");
}

Console.WriteLine();
LogMessageToConsole($"Found {numPrimes} number of primes within the maximum number of {numberMaxToValidate}!");

//
// Function with the core algorithm.
// Details about the sieve of eratosthenes can be found here:
//   https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
//
static IEnumerable<int> FindPrimesBySieve(int num)
{
    // For implementing the algorithm, we use a marker array with specific values per element:
    // 0 = untouched (default)
    // 1 = prime
    // 2 = striked out due to being a product value of a previous prime number
    // Since 1 is a prime number and won't be used for the sieve since every number is a product
    // of the number 1, we can skip it in our considerations.
    var markerArray = new short[num - 1];

    // The number 1 is a prime but not considered in our array.
    yield return 1;

    // The first prime is 
    for(int i = 0; i < markerArray.Length; i++)
    {
        // If the current element is an untouched element, that is not striked out, it must be
        // a prime number. Note that an array in C# gets initialized with 0, by default. We defined
        // STATE_UNTOUCHED as 0.
        if (markerArray[i] == STATE_UNTOUCHED)
        {
            // Not striked out means this is a prime number.
            markerArray[i] = STATE_PRIME;

            // Now strike out all products of that number. Remember that the actual number is
            // '+ 2' since we did not consider 0 and 1 in our array.
            var currentNum = i + 2;
            yield return currentNum;
            for(int j = i + currentNum; j < markerArray.Length; j += currentNum)
            {
                markerArray[j] = STATE_STRIKED;
            }
        }
    }
}

//
// Helper function for simple, console-based logging.
//
static void LogMessageToConsole(string message, MessageType messageType = MessageType.Info)
{
    var currentColor = System.Console.ForegroundColor;
    try
    {
        if (messageType == MessageType.Error)
            System.Console.ForegroundColor = System.ConsoleColor.Red;
        System.Console.WriteLine(message);
    }
    finally
    {
        System.Console.ForegroundColor = currentColor;
    }
}

public enum MessageType
{
    Info,
    Error
}