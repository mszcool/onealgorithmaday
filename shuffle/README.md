# Shuffling an Array

Shuffling an array is often based on the [Fisher-Yates algorithm](http://www.programming-algorithms.net/article/43676/Fisher-Yates-shuffle#:~:text=Fisher-Yates%20shuffle.%20The%20Fisher-Yates%20shuffle%20%28named%20after%20Ronald,by%20this%20algorithm%20occur%20with%20the%20same%20probability.). This algorithm, on paper, works as follows:

1. Write down your elements to shuffle (aka, put them in a source array).
2. Randomly pick a number and write it into your target sequence (aka, target array).
3. Strike out the number from your source array.
4. Repeate the steps 1-3 until there's no number left.
5. Your new sequence is a randomly shuffled sequence without bias.

The algorithm above has a complexity, though: if conducted by a computer, the elements that are striked out, need to be marked or removed from the source list/array. This can be avoided by the following optimization of the algorithm:

1. Create an array with the elements you want to shuffle.
2. Start counting from the last element to the first in a counter, i.e. currentCounter.
3. Randomly pick an element of the array and swap it with the element from currentCounter.
4. Reduce currentCounter and repeate step 3 until you have reached the beginning of your array.
5. Your array is now shuffled without extra steps needed of striking out.

Essentially, the optimization leads to putting striked out elements towards the end of the array. That avoids any extra steps being needed for striking out elements by marking or removing them from the source array as explained in the original method. The website [www.programming-algorithms.net] has a great [visualization for the algorithm](http://www.programming-algorithms.net/article/43676/Fisher-Yates-shuffle#:~:text=Fisher-Yates%20shuffle.%20The%20Fisher-Yates%20shuffle%20%28named%20after%20Ronald,by%20this%20algorithm%20occur%20with%20the%20same%20probability.).