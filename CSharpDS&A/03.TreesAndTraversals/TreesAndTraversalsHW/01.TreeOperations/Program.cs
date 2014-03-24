namespace TreeOperations
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));

            var tree = TreeExtensions.ParseInputTree();
            
            //a) Find root node
            var root = TreeExtensions.GetRootNode(tree);
            Console.WriteLine("Root node : {0}", root);

            //b) Find leaf nodes
            Console.WriteLine("Leaf nodes : {0}", string.Join(", ", TreeExtensions.GetLeafNodes(tree)));

            //c) Find middle nodes
            Console.WriteLine("Middle nodes : {0}", string.Join(", ", TreeExtensions.GetMiddleNodes(tree)));

            //d) Find longest path from root
            Console.WriteLine("Longest path from root : {0} vertexes", TreeExtensions.GetLongestPath(root));

            //e) Find all paths in the tree with given sum S of their nodes
            const int TargetPathSum = 5;
            var pathsFound = TreeExtensions.GetPathsWithSum(tree, TargetPathSum);

            foreach (var path in pathsFound)
            {
                Console.WriteLine("Path found[target sum={0}]: {1}", TargetPathSum, string.Join("+", path));
            }

            //f) Find all subtrees with given sum S of their nodes
            const int TargetSubtreeSum = 6;
            var subtreesFound = TreeExtensions.GetSubtreesWithSum(tree, TargetSubtreeSum);

            foreach (var subtree in subtreesFound)
            {
                Console.WriteLine("Subtree found[target sum={0}]: {1}", TargetSubtreeSum, string.Join("+", subtree));
            }
        }
    }
}
