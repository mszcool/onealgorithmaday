//
// Initially, we'll ask the user to enter a string!
//
System.Console.WriteLine("Please enter a string: ");
var stringToValidateInput = Console.ReadLine();
if (string.IsNullOrEmpty(stringToValidateInput) || stringToValidateInput.Length <= 1)
{
    LogMessageToConsole("Invalid string entered. Please enter a string that is longer than one character!", MessageType.Error);
    System.Environment.Exit(-1);
}

System.Console.WriteLine("Do you want to consider whitespaces (y/n)?");
var considerWhiteSpacesInput = Console.ReadLine();
if (string.IsNullOrEmpty(considerWhiteSpacesInput) || !(considerWhiteSpacesInput.ToLower().Equals("y") || considerWhiteSpacesInput.ToLower().Equals("n")))
{
    LogMessageToConsole("You can enter 'y' or 'n' for considering whitespaces, only!", MessageType.Error);
    System.Environment.Exit(-1);
}

// Now inform the user about the check.
LogMessageToConsole($"Validating string '{stringToValidateInput}' with whitespaces '{considerWhiteSpacesInput}'...");
var isPalindrome = ValidateStringForPalindrome(stringToValidateInput, considerWhiteSpacesInput.ToLower().Equals("y"));
var isPalindromeText = isPalindrome ? "is" : "is not";
LogMessageToConsole($"String '{stringToValidateInput}' {isPalindromeText} palindrom!");

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

//
// Implementation of the algorithm
//
static bool ValidateStringForPalindrome(string str, bool considerWhitespaces)
{
    var strToEval = str;

    // If whitespaces are not considered, remove them all.
    if (!considerWhitespaces)
    {
        var builder = new System.Text.StringBuilder();
        foreach(var c in str)
        {
            if (!Char.IsWhiteSpace(c))
                builder.Append(c);
        }
        strToEval = builder.ToString();
    }

    // Then check if the reverse is exactly the same as the regular length.
    var reverseStr = new String(strToEval.Reverse().ToArray());
    return string.Equals(strToEval, reverseStr, StringComparison.InvariantCultureIgnoreCase);
}

public enum MessageType
{
    Info,
    Error
}