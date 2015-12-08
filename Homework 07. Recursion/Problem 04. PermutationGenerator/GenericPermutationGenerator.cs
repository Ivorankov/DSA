namespace Problem_04.PermutationGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    class GenericPermutationGenerator
    {

        public static List<List<T>> GeneratePermutations<T>(List<T> items)
        {
            // Make an array to hold the
            // permutation we are building.
            T[] current_permutation = new T[items.Count];

            // Make an array to tell whether
            // an item is in the current selection.
            bool[] in_selection = new bool[items.Count];

            // Make a result list.
            List<List<T>> results = new List<List<T>>();

            // Build the combinations recursively.
            PermuteItems<T>(items, in_selection,
                current_permutation, results, 0);

            // Return the results.
            return results;
        }

        private static void PermuteItems<T>(List<T> items, bool[] inSelection,
                                           T[] currentPermutation,
                                           List<List<T>> results,
                                           int nextPosition)
        {
            // See if all of the positions are filled.
            if (nextPosition == items.Count)
            {
                // All of the positioned are filled.
                // Save this permutation.
                results.Add(currentPermutation.ToList());
            }
            else
            {
                // Try options for the next position.
                for (int i = 0; i < items.Count; i++)
                {
                    if (!inSelection[i])
                    {
                        // Add this item to the current permutation.
                        inSelection[i] = true;
                        currentPermutation[nextPosition] = items[i];

                        // Recursively fill the remaining positions.
                        PermuteItems<T>(items, inSelection,
                            currentPermutation, results,
                            nextPosition + 1);

                        // Remove the item from the current permutation.
                        inSelection[i] = false;
                    }
                }
            }
        }
    }
}
