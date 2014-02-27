namespace BinarySearchTree
{
    using System;

    class Test
    {
        static void Main()
        {
            BinarySearchTree<int, string> myTree = new BinarySearchTree<int, string>();

            myTree.AddNode(50, "Strawberry");
            myTree.AddNode(25, "Cranberry");
            myTree.AddNode(30, "Blackberry");
            myTree.AddNode(15, "Raspberry");
            myTree.AddNode(2, "Blueberry");
            myTree.AddNode(18, "Grape");
            myTree.AddNode(30, "Melon");
            myTree.AddNode(75, "Watermelon");
            myTree.AddNode(70, "Apple");
            myTree.AddNode(85, "Orange");

            //myTree.PostOrderTraverseTree(myTree.Root);
            //myTree.PreOrderTraverseTree(myTree.Root);
            //myTree.InOrderTraverseTree(myTree.Root);

            Console.WriteLine("Node with key of 25: {0}\n", myTree.FindNode(25));
            
            myTree.RemoveNode(25);

            Console.WriteLine("After removing the node with key of 25: ");  //see image
            myTree.PreOrderTraverseTree(myTree.Root);

            Console.WriteLine(myTree.FindNode(15).Equals(myTree.FindNode(2)));
        }
    }
}
