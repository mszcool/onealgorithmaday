# Sieve of Eratosthenes

The sieve of eratosthenes is an algorithm for identifying prime numbers. It essentially uses an array as a baseline in which each element of the array represents a number. It works by navigating through the array and striking out all numbers which are products of multiplications from earlier numbers starting with the first prime number after 1, which is 2:

* It strikes out all products of 2 (which are 4, 6, 8, 10 etc.).
* After that, it goes to the next prime, which is 3, and strikes out all products not striked, yet (9, 15, 21 etc.)
* After that, it goes to the next prime (aka next element in the array not striked, yet) and strikes out all of its products.
  * That is 5 in our example.
  * It strikes all products of 5 which are not striked out, yet.
  * i.e., these are 25, 35, 45 etc.
* This process is continued until all elements of the array have been processed.

More information about the algorithm can be found here: https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes

The following, animated give illustrates, how the algorithm works:

![Sieve of Eratosthenes Illustration](https://upload.wikimedia.org/wikipedia/commons/b/b9/Sieve_of_Eratosthenes_animation.gif)