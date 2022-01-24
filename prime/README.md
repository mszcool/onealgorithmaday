# Prime number check

Prime numbers are numbers which can be evenly divided by itself and 1, only. Such numbers are of essential use in cryptography and are an integral part of encryption algorithms such as RSA. A typical algorithm for verifying, if a number is a prime number works as follows:

* If the number is 1, 2 or 3, the number is a prime as those can be divided by themselves and 1, only.
* If the number can be evenly divided by 2 and is larger than 3, it is not a prime.
* For the rest, we need to find an uneven divisor through which the number can be defined.
  * If we cannot find one, the number is a prime.
  * If we can find one, the number is NOT a prime.
  * A simple optimization of the algorithm is to run at max up to `num/2` since after that, there's for sure no number higher than `num/2` through which the number can be evenly divided.
  * A further optimization is to just validate up to the sqare root since after that, there are repetitions of factors of previous divisions and hence we won't find any new data points after that threshold.

Note: 0 is not a prime, regardless of how we look at it. The simplest view is that 0 can be divided through any number with an even result (which is 0) and hence is not a prime.