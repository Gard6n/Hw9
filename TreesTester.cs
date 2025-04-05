namespace prove_09;

public static class TreesTester {
    /// <summary>
    /// Entry point for the Prove 9 tests
    /// </summary>
    public static void Run() {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        BinarySearchTree tree = new BinarySearchTree();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        // After implementing 'no duplicates' rule,
        // this next insert will have no effect on the tree.
        // TODO Problem 1
        tree.Insert(7);
        tree.Insert(4);
        tree.Insert(10);
        tree.Insert(1);
        tree.Insert(6);
        Console.WriteLine(tree.ToString()); // 1, 3, 4, 5, 6, 7, 10

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        Console.WriteLine(tree.Contains(3)); // True
        Console.WriteLine(tree.Contains(2)); // False
        Console.WriteLine(tree.Contains(7)); // True
        Console.WriteLine(tree.Contains(6)); // True
        Console.WriteLine(tree.Contains(9)); // False

        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        foreach (var value in tree.Reverse()) {
            Console.WriteLine(value); // 10, 7, 6, 5, 4, 3, 1
        }

        Console.WriteLine("\n=========== PROBLEM 4 TESTS ===========");
        Console.WriteLine(tree.GetHeight()); // 3
        tree.Insert(6);
        Console.WriteLine(tree.GetHeight()); // 3
        tree.Insert(12);
        Console.WriteLine(tree.GetHeight()); // 4

        Console.WriteLine("\n=========== PROBLEM 5 TESTS ===========");
        var tree1 = CreateTreeFromSortedList(new[] { 10, 20, 30, 40, 50, 60 });
        var tree2 = CreateTreeFromSortedList(Enumerable.Range(0, 127).ToArray()); // 2^7 - 1 nodes
        var tree3 = CreateTreeFromSortedList(Enumerable.Range(0, 128).ToArray()); // 2^7 nodes
        var tree4 = CreateTreeFromSortedList(new[] { 42 });
        var tree5 = CreateTreeFromSortedList(Array.Empty<int>());
        Console.WriteLine(tree1.GetHeight()); // 3
        Console.WriteLine(tree2.GetHeight()); // 7 .. any higher and its not balanced
        Console.WriteLine(tree3.GetHeight()); // 8 .. any higher and its not balanced
        Console.WriteLine(tree4.GetHeight()); // 1
        Console.WriteLine(tree5.GetHeight()); // 0
    }

    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 used.
    /// </summary>
    private static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers) {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst) {
    // Base case: If the sublist is empty (first > last), return
    if (first > last)
        return;
    
    // Find the middle index
    int middle = (first + last) / 2;
    
    // Insert the middle value into the BST
    bst.Insert(sortedNumbers[middle]);
    
    // Recursively insert the middle value from the left half
    InsertMiddle(sortedNumbers, first, middle - 1, bst);
    
    // Recursively insert the middle value from the right half
    InsertMiddle(sortedNumbers, middle + 1, last, bst);
}
}