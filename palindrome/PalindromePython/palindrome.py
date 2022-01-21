#
# Main function with the palindrome check
#

from pydoc import text


def main():
    
    # First, we need to let the user enter the string
    print("Palindrome check for python!")
    print("Please enter a string to validate: ")
    strInput = input()
    if (not validateStringInput(strInput)):
        print("Invalid string entered. Please enter a string longer than one character!")
        exit(-1)
    print("Do you want to consider whitespaces (y/n)?")
    considerWsInput = input()
    if (not validateYesNo(considerWsInput)):
        print("You need to enter 'y' or 'n' only for this input!")
        exit(-1)

    # Next, we validate the string and return the results.
    print("Validating string '%s'..." % strInput)
    considerWs = True if considerWsInput == "y" else False
    isPalindrome = ValidateIsPalindromeString(strInput, considerWs)
    isPalindromeString = "is" if isPalindrome else "is not"
    print("The string %s %s palindrome!" % (strInput, isPalindromeString))

def validateStringInput(toValidate):
    if (not isinstance(toValidate, str)):
        return False
    if (len(toValidate) <= 1):
        return False
    if (toValidate.isspace()):
        return False
    return True

def validateYesNo(toValidate):
    if(not isinstance(toValidate, str)):
        return False
    toValidate = toValidate.lower()
    if (toValidate != "y" and toValidate != "n"):
        return False
    return True

def ValidateIsPalindromeString(toValidate, considerWhitespaces):

    toValidateUse = ""

    # If whitespaces are not considered, we need to remove them
    if (not considerWhitespaces):
        noSpaces = toValidate.strip()
        for ch in toValidate:
            if (not ch.isspace()):
                toValidateUse = toValidateUse.join(ch)
    else:
        toValidateUse = toValidate

    # Next, let's reverse the original string
    reversedString = "".join(reversed(toValidateUse))
    if (reversedString.lower() == toValidateUse.lower()):
        return True

    return False

if __name__ == "__main__":
    main()