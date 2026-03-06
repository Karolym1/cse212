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
        // 1. Create a new array that has exactly 'length' spaces.
        // 2. Start a loop at index 0 and continue until the last index in the array.
        // 3. For each index, calculate the multiple by multiplying 'number' by (index + 1).
        //    This works because the first value should be 1 times the number, the second value
        //    should be 2 times the number, and so on.
        // 4. Store each calculated multiple into the matching position in the array.
        // 5. After the loop is finished, return the completed array.

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
        // 1. Figure out where the list should be split by subtracting amount from data.Count.
        //    Everything after that split point will move to the front of the list.
        // 2. Copy the last 'amount' values into a temporary list.
        // 3. Copy the values from the beginning of the list up to the split point into a second temporary list.
        // 4. Clear the original list because we are going to rebuild it in rotated order.
        // 5. Add the values from the last part first, since rotating right moves those items to the front.
        // 6. Add the values from the first part after that.
        // 7. When both parts have been added back, the original list has been rotated to the right.

        int splitIndex = data.Count - amount;

        List<int> endPart = data.GetRange(splitIndex, amount);
        List<int> firstPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(endPart);
        data.AddRange(firstPart);
    }
}