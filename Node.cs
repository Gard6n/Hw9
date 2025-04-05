namespace prove_09;

public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
    if (value < Data) {
        // Insert to the left
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else if (value > Data) {
        // Insert to the right
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }

}
    public bool Contains(int value) {
    // If the value equals the current node's data, we found it
    if (value == Data)
        return true;
    
    // If value is less than current node's data, search left subtree
    if (value < Data)
        return Left != null && Left.Contains(value);
    
    // If value is greater than current node's data, search right subtree
    return Right != null && Right.Contains(value);
}

    public int GetHeight() {
    // Base case: if this is a leaf node (no children)
    if (Left == null && Right == null)
        return 1;
    
    // Get the height of left subtree (0 if there is no left child)
    int leftHeight = (Left == null) ? 0 : Left.GetHeight();
    
    // Get the height of right subtree (0 if there is no right child)
    int rightHeight = (Right == null) ? 0 : Right.GetHeight();
    
    // Return 1 (for this node) plus the maximum height of either subtree
    return 1 + Math.Max(leftHeight, rightHeight);
}
}