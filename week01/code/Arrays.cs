public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN
        // 1. Create a new array with the size equal to length.
        // 2. Loop through each index in the array.
        // 3. Multiply the number by (index + 1) to get each multiple.
        // 4. Store each multiple in the array.
        // 5. Return the completed array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN
        // 1. Find the position where the list should be split.
        //    The split point is data.Count - amount.
        // 2. Copy the last 'amount' items into a temporary list.
        // 3. Copy the first part of the list into another temporary list.
        // 4. Clear the original list.
        // 5. Add the last part first, because those move to the front.
        // 6. Add the first part after that.
        // 7. The original list is now rotated to the right.

        int splitIndex = data.Count - amount;

        List<int> endPart = data.GetRange(splitIndex, amount);
        List<int> firstPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(endPart);
        data.AddRange(firstPart);
    }
}