#
# Main function with the simple pattern check
#
def main():
    
    # First, we need to let the user enter the string
    print("String pattern check with python!")
    print("Please enter a string to validate: ")
    strInput = input()
    if (not validateStringInput(strInput)):
        print("Invalid string entered. Please enter a string longer than one character!")
        exit(-1)
    print("What pattern do you want to check, against? Use * for multiple joker characters and ? for single joker characters.")
    strPattern = input()
    if (not validatePattern(strPattern)):
        print("Ambiguous pattern entered. If * is followed by ? or ? is followed by *, the pattern is ambiguous!")
        exit(-1)

    # Next, we validate the string and return the results.
    print("Validating string '%s'..." % strInput)
    isMatch = ValidateStringAgainstPattern(strInput, strPattern)
    isMatchString = "MATCHES" if isMatch else "does NOT MATCH"
    print("The string %s %s the pattern %s!" % (strInput, isMatchString, strPattern))

def validateStringInput(toValidate):
    if (not isinstance(toValidate, str)):
        return False
    if (len(toValidate) <= 1):
        return False
    if (toValidate.isspace()):
        return False
    return True

def validatePattern(toValidate):
    if (("*?" in toValidate) or ("?*" in toValidate)):
        return False
    return True

def ValidateStringAgainstPattern(str, strPattern):
    
    # Validate, if the first character of both strings are equal or if the first character of
    # the pattern is a single-character joker. If so, we have a match and can continue to the next item in both,
    # String and Pattern if there are more characters to validate.
    if ((str[0] == strPattern[0]) or (strPattern[0] == '?')):
        strLen = len(str)
        patternLen = len(strPattern)
        if strLen > 1 and patternLen > 1:
            return ValidateStringAgainstPattern(str[1:len(str)], strPattern[1:len(strPattern)])
        elif strLen == 1 and patternLen == 1:
            return True
        else:
            return False
    elif (strPattern[0] == '*'):
        # Joker sign for multiple characters - let's see if we find pattern matches after the Joker.
        # If we cannot find any match after the joker, the string does not match.
        while len(str) > 1:
            # The last character in the pattern string is the *-joker, hence we're good.
            if len(strPattern) <= 1:
                return True
            # If the last character is not the *-joker, then we need to see, if we can find any pattern match after the joker.
            # If so, we're good and have a matching string, but if not, we don't. We try to find any possible match after the joker
            # since the border from the joker to the next section after the joker is not easily determined (i.e. ACCCCB to match A*CB).
            if ValidateStringAgainstPattern(str, strPattern[1:len(strPattern)]):
                return True
            else:
              str = str[1:len(str)]
    else:
        return False

if __name__ == "__main__":
    main()