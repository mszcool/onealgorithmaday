import math
import constants as const

#
# Main program for prime validation
#

def main():

    # First ask for a number to validate
    print("Sieve of Eratosthenes in Python!")
    print("Please enter the max number up to which you want to validate: ")
    strInputNr = input()
    if (not strInputNr.isnumeric()):
        print("Error: please enter an integer number without commas!")
        exit(-1)
    numToCheck = int(strInputNr)
    if (numToCheck <= 3):
        print("Please enter number larger than 3 since numbers between 1 and 3 are all prime numbers!")
        exit(-1)
    
    # Next, run the prime validation
    numPrimes = 0
    for p in FindPrimeNumbersBySieve(numToCheck):
        numPrimes += 1
        print(" %s " % p, end = "")
 
    print("\nNumber of primes found up to %s: %s!" % (numToCheck, numPrimes))

#
# Algorithm encapsulation...
#
def FindPrimeNumbersBySieve(num):
    
    # We create an array but we do not need an element for 1
    markerArray = [const.MARKER_UNTOUCHED] * (num - 1)

    # Then yield 1 itself since it is a prime
    yield 1

    # Now, implement the sieve by striking out all products of prime numbers.
    # Note that the first element in the array represents the number '2' for which we need
    # to start sieving by its products.
    i = 0
    while ( i < (num - 1) ):
        # Current number is a prime if not striked out.
        if ( markerArray[i] == const.MARKER_UNTOUCHED):
            # First, mark this number as a prime
            markerArray[i] = const.MARKER_PRIME
            # Next, yield that number as a prime (note that the index represents the number and we skipped 1)
            currentPrime = i + 2
            yield currentPrime
            # Now, strike out all the products for that number in the array
            j = i + currentPrime
            while ( j < (num - 1) ):
                markerArray[j] = const.MARKER_STRIKE
                j += currentPrime
        # Move to the next element
        i += 1

if __name__ == "__main__":
    main()