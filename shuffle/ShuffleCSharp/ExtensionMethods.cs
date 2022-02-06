namespace mszcool.samples.algorithms;

using System.Security.Cryptography;

public static class ArrayExtensionMethods
{
    public static void ShuffleArray(this System.Array toShuffle)
    {
        var rnd = new byte[32 / 8];                 // We target a 32-bit integer value.
        var rng = RandomNumberGenerator.Create();   // We use the Cryptographic random number generator instead of System.Random.
        
        // Walk through the array using the optimized Fisher-Yates algorithm.
        for(int i = (toShuffle.Length - 1); i > 0; i--)
        {
            // Pick the next element
            rng.GetNonZeroBytes(rnd);
            // Converting the result into a positive value using "Math.Abs()"
            var rndIdx = System.Math.Abs(
                            System.BitConverter.ToInt32(rnd) % i);

            // Next we swap the currently last (represented by i) element with the random one.
            toShuffle.SwapElements(rndIdx, i);
        }
    }

    public static void SwapElements(this System.Array targetArray, int idx1, int idx2)
    {
        var temp = targetArray.GetValue(idx1);
        targetArray.SetValue(targetArray.GetValue(idx2), idx1);
        targetArray.SetValue(temp, idx2);
    }

    public static void PrintArray(this System.Array targetArray, System.IO.TextWriter sw, string separator = ", ")
    {
        var printed = 0;
        var iterator = targetArray.GetEnumerator();
        while(iterator.MoveNext())
        {
            sw.Write(iterator.Current.ToString());
            printed++;

            if (printed < targetArray.Length)
                sw.Write(separator);
        }
    }
}