import math

#
# Main program for prime validation
#

def main():

    # First ask for a number to validate
    print("Prime number valiation in python!")
    print("Please enter a number to validate: ")
    strInputNr = input()
    if (not strInputNr.isnumeric()):
        print("Error: please enter an integer number without commas!")
        exit(-1)
    numToCheck = int(strInputNr)
    if (numToCheck <= 0):
        print("Please enter number larger than 0 since 0 is not a prinme!")
        exit(-1)
    
    # Next, run the prime validation
    primeResult = ValidatePrime(numToCheck)
    isPrimeText = "is a" if primeResult[0] else "is not a"
    divisorText = ("".join([" and can be divided by ", str(primeResult[1])])) if not primeResult[0] else ""

    print("The number %s %s prime%s!" % (numToCheck, isPrimeText, divisorText))

#
# Algorithm encapsulation...
#
def ValidatePrime(num):

    # Numbers 1, 2 and 3 are prime numbers
    if (num > 0 and num <= 3): return (True, 0)

    # If the number can be divided by 2 then it is not a prime.
    if (num % 2 == 0): return (False, 2)

    # Next check the number up to the square root of itself since after that we'll not find any
    # divisors to check the number, anymore.
    upLim = int(math.sqrt(num)) + 1
    for x in range(3, upLim, 2):
        if num % x == 0:
            return (False, x)

    return (True, 0);

if __name__ == "__main__":
    main()