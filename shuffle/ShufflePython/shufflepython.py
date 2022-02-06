import math
import os
import struct

#
# Main program for prime validation
#

def main():

    # First, generate an array with numbers. Note that the second parameter
    # is used as the index-bound, not the number of elements (hence 53 instead of 52)
    sortedArray = list(range(1, 53, 1))
    print("Generated the following array:")
    PrintArray(sortedArray)
    
    print("Now shuffling the array...\n")
    ShuffleArray(sortedArray)
    print("Shuffled array:")
    PrintArray(sortedArray)

#
# Algorithm encapsulation...
#
def ShuffleArray(theArray):
    # Go through the array from last to first element
    i = len(theArray) - 1
    while ( i > 0 ):
        # In python, the following method generates cryptographically secure random numbers, apparently.
        # An alternative is 'import random' and 'random.SystemRandom'
        randBytes = os.urandom(4)
        randIndex = abs(struct.unpack('i', randBytes)[0])
        
        SwapElements(theArray, randIndex % i, i)
        i -= 1

def SwapElements(theArray, idx1, idx2):
    temp = theArray[idx1]
    theArray[idx1] = theArray[idx2]
    theArray[idx2] = temp

def PrintArray(theArray):
    printCount = 0
    arrayLength = len(theArray)
    for x in theArray:
        print("%s" % x, end = "")
        printCount += 1
        if (printCount < arrayLength):
            print(", ", end = "")

if __name__ == "__main__":
    main()