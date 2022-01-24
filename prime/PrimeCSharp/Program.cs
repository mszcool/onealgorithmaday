System.Console.WriteLine("Please enter a number to validate: ");
var numberToValidateInput = System.Console.ReadLine();
var numberToValidate = 0;
if (!int.TryParse(numberToValidateInput, out numberToValidate))
{
    LogMessageToConsole($"Please enter a valid integer number. You entered '{numberToValidateInput}' which is not a valid number!");
    System.Environment.Exit(-1);
}
if (numberToValidate <= 0)
{
    LogMessageToConsole("Please enter a positive number!");
    System.Environment.Exit(-1);
}

// Next start the validation for the Prime number.
var result = ValidatePrime(numberToValidate);
var isPrimeText = result.Item1 ? "is a" : "is not a";
var divisorText = !result.Item1 ? $" since it can be divided evenly by {result.Item2}" : ""; 
LogMessageToConsole($"The number '{numberToValidate}' {isPrimeText} prime number{divisorText}!");

//
// Function with the core algorithm.
// A prime is a number that can be evenly divided through itself and 1, only!
// The numbers 1, 2, 
//
static (bool, int) ValidatePrime(int num)
{
    // The numbers 1, 2 and 3 are prime numbers.
    if (num <= 3 && num > 0) return (true, 0);

    // Even numbers are definitely not prime numbers.
    if (num % 2 == 0) return (false, 2);

    // If none of the shortcuts worked, then we need to check all numbers up to the
    // sqare root of the number. After the square root, no further, evenly possible divisor
    // will be possible to find, hence we can stop there. We round up to be on the safe side.
    var maxCheck = System.Convert.ToInt32(System.Math.Sqrt(num)) + 1;
    for (int i = 3; i <= maxCheck; i += 2)
    {
        // We can skip all even numbers since we verified division by 2, already.
        if (num % i == 0) return (false, i);
    }

    return (true, 0);
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