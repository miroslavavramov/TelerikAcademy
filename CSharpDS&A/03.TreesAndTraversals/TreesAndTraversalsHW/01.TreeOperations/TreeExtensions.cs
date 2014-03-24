namespace TreeOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TreeExtensions
    {
        public static Node[] ParseInputTree()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            var tree = new Node[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                tree[i] = new Node(i);
            }

            for (int i = 0; i < nodesCount - 1; i++)
            {
                int[] parentChildPair = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();

                int parentValue = parentChildPair[0];
                int childValue = parentChildPair[1];

                tree[parentValue].AddChild(tree[childValue]);
                tree[childValue].Parent = tree[parentValue];
            }

            return tree;
        }

        public static Node GetRootNode(Node[] tree)  //a)
        {
            foreach (var node in tree)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("Provided tree doesn't contain a root node.");
        }

        public static IEnumerable<Node> GetLeafNodes(Node[] tree)  //b)
        {
            var leafNodes = new List<Node>();

            foreach (var node in tree)
            {
                if (!node.HasChildren)
                {
                    leafNodes.Add(node);
                }
            }

            return leafNodes;
        }

        public static IEnumerable<Node> GetMiddleNodes(Node[] tree) //c)
        {
            var middleNodes = new List<Node>();

            foreach (var node in tree)
            {
                if (node.HasChildren && node.Parent != null)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        public static int GetLongestPath(Node root)     //d)
        {
            if (!root.HasChildren)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, GetLongestPath(node));
            }

            return maxPath + 1;
        }

        public static ICollection<Stack<int>> GetPathsWithSum(Node[] tree, int targetSum)  //e)
        {
            var pathsFound = new List<Stack<int>>();

            foreach (var node in tree)
            {
                pathsFound.AddRange
                    (TraversePathsFromNode(node, targetSum, new List<Stack<int>>(), new Stack<int>()));
            }

            return pathsFound;
        }

        public static ICollection<List<int>> GetSubtreesWithSum(Node[] tree, int targetSum)    //d)
        {
            var subtreesFound = new List<List<int>>();

            foreach (var node in tree)
            {
                var subtree = (TraverseSubtreeFromNode(node, new List<int>()));
                subtree.Add(node.Value);

                if (CheckIfSumEqualsTarget(subtree, targetSum))
                {
                    subtreesFound.Add(subtree);
                }
            }

            return subtreesFound;
        }

        private static List<int> TraverseSubtreeFromNode(Node root, List<int> currentSubtree)   //pre-order traversal (DFS)
        {
            foreach (var node in root.Children)
            {
                TraverseSubtreeFromNode(node, currentSubtree);
                currentSubtree.Add(node.Value);
            }

            return currentSubtree;
        }

        private static ICollection<Stack<int>> TraversePathsFromNode(
            Node root, int targetSum, 
            ICollection<Stack<int>> pathsFound, Stack<int> currentPath
            )   //pre-order traversal (DFS)
        {
            currentPath.Push(root.Value);

            if (CheckIfSumEqualsTarget(currentPath, targetSum))
            {
                pathsFound.Add(new Stack<int>(currentPath));
            }

            foreach (var node in root.Children)
            {
                TraversePathsFromNode(node, targetSum, pathsFound, currentPath);
                currentPath.Pop();
            }

            return pathsFound;
        }

        private static bool CheckIfSumEqualsTarget(IEnumerable<int> bond, int targetSum)
        {
            int sum = 0;

            foreach (var nodeValue in bond)
            {
                sum += nodeValue;
            }

            return sum == targetSum;
        }
    }
}
