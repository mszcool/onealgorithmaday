# Simple String Pattern Match

Pattern matching is a very common scenario amongst many different types of use cases. Today, often pattern matching is implemented through regular expressions. Most programming languages and runtimes do offer decent libraries. Still, understanding pattern matching algorithms might help for data processing logic in data pipeline scenarios. In addition, string pattern matching is a nice example to illustrate recursive algorithms in more complex scenarios that are harder to understand and implement with iterative approaches (despite the fact of recursions not being the most efficient way for implementing algorithms in many cases). In this example, the goal was to implement the functionality without the use of pattern matching libraries and functions offered by the runtimes/frameworks (such as `System.Text.RegularExpressions.Regex` in `C# / .NET`).

First, let's define the specification of the algorithm: write an algorithm which validates a string against a pattern string where the pattern string can be composed of characters, digitis and the joker signs `*` and `?`. The joker `*` represents any character between `0` and `n` occurrances while the joker `?` represents any single character in a string. All characters in the pattern string that are not joker signs need to match corresponding characters in the string to be validated. The following table shows examples:

| String           | Pattern        | Match yes/no |
| ---------------- | -------------- | ------------ |
| ABC              | ABC            | yes          |
| ABC              | A*             | yes          |
| ABCCCCCDE        | A*D?           | yes          |
| ABCCCCCDEEEF     | AB*DE?F        | no           |
| ABCCCCCDDDEEEFF  | AB*CCD?DEEEFF  | yes          |
| ABCCCCCDDDEEEFF  | A*F            | yes          |
| ABCCCCCDDDEEEFF  | A*G            | no           |

Ambiguous patterns should not be allowed. I.e., a pattern string containing a `*` followed by a `?` or vice versa leaves room for interpretation of how long the string represented by a `*` in the pattern can be. Hence, we avoid such scenarios.

A simple algorithm to perform pattern matching can be implemented as follows:

1. Iterate character by character through the string and pattern-string.
2. If characters in the string and pattern string do match, we're fine and move on with validating the next character.
3. If a character in the target string does not match a character in the pattern string and if the pattern character is not a joker, the string does not match the pattern and we stop with further processing.
4. If the character in the target string does not match a character in the pattern string and if the character in the pattern string is a `?`-joker, we move on to the next character.
5. If the character in the pattern string is a `*`-joker, we move on in the target string until we find a pattern that matches the next sequence in the pattern string that follows the `*`-joker in it.
  * If the string ends before that happens and there are more characters in the pattern-string, we don't have a match.
  * If the string ends before that happens, but there are no more characters in the pattern-string, as well, we do have a match.
  * As soon as we found a sequence in the string that matches the next sequence in the pattern-string, we continue with the validation at that position by validating character-by-character as we started in step 1.

The last point is an obvious indicator of the recursion. Also the iteration on the first step can be one, although not necessarily that obvious, yet.  