//
// Initially, we'll ask the user to enter a string!
//
try{
    System.Console.WriteLine("Please enter a string: ");
    var stringToValidateInput = Console.ReadLine();
    if (string.IsNullOrEmpty(stringToValidateInput) || stringToValidateInput.Length <= 1)
    {
        LogMessageToConsole("Invalid string entered. Please enter a string that is longer than one character!", MessageType.Error);
        System.Environment.Exit(-1);
    }

    System.Console.WriteLine("Please enter a pattern string. Note that '*' represents multiple characters and '?' represents a single character!");
    var stringPatternToValidateInput = Console.ReadLine();
    if (string.IsNullOrEmpty(stringPatternToValidateInput))
    {
        LogMessageToConsole("You need to enter a pattern string to validate the source string, against!", MessageType.Error);
        System.Environment.Exit(-1);
    }

    // Now inform the user about the check.
    LogMessageToConsole($"Validating string '{stringToValidateInput}' against pattern '{stringPatternToValidateInput}'...");
    var isMatch = ValidateStringAgainstPattern(stringToValidateInput, stringPatternToValidateInput);
    var isMatchText = isMatch ? "matches" : "does NOT match";
    LogMessageToConsole($"String '{stringToValidateInput}' {isMatchText} the pattern {stringPatternToValidateInput}!");
}
catch(Exception ex)
{
    LogMessageToConsole($"Failed pattern matching due to {ex.GetType().Name}: {ex.Message}");
}

//
// Implementation of the algorithm as recursion
//
static bool ValidateStringAgainstPattern(string str, string patternString)
{
    // The pattern string should not contain two joker signs followed by each other as this would
    // lead to ambiguous patterns.
    var ambiguousPattern = patternString.Contains("**");
    ambiguousPattern |= patternString.Contains("*?");
    ambiguousPattern |= patternString.Contains("?*");
    if (ambiguousPattern)
    {
        throw new System.ArgumentException("Ambiguous pattern string passed in!", nameof(patternString));
    }

    // Now we can perform the validation
    return ValidateStringAgainstPatternRecursiveIndex(str, patternString, 0, 0);
}

static bool ValidateStringAgainstPatternRecursiveIndex(string str, string patternString, int strIdx, int patternIdx)
{
    // Validate if the current character matches the pattern string.
    if ((str[strIdx] == patternString[patternIdx]) || (patternString[patternIdx] == '?'))
    {
        if ( ((strIdx + 1) < str.Length) && (patternIdx + 1) < patternString.Length)
            return ValidateStringAgainstPatternRecursiveIndex(str, patternString, strIdx + 1, patternIdx + 1);
        else if ((strIdx + 1) == str.Length && (patternIdx + 1) == patternString.Length)
            return true;
        else
            return false;
    }
    else if(patternString[patternIdx] == '*')
    {
        // Find the next pattern in string after the *-joker that matches. If none matches, then the pattern does not match.
        while (strIdx < str.Length)
        {
            if (ValidateStringAgainstPatternRecursiveIndex(str, patternString, strIdx, patternIdx + 1))
                return true;
            else
                strIdx++;
        }
        return false;
    }
    else
    {
        // No match found, neither through joker nor through direct comparison - must be a none-match
        return false;
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