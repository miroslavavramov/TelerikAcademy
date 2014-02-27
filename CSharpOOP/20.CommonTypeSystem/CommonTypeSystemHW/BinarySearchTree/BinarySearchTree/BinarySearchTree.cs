namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    class BinarySearchTree<TKey, TValue>
        where TKey : IComparable
    {
        public TreeNode<TKey, TValue> Root { get; set; }

        public void AddNode(TKey key, TValue value)
        {
            TreeNode<TKey, TValue> newNode = new TreeNode<TKey, TValue>(key, value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                TreeNode<TKey, TValue> focusNode = Root;

                TreeNode<TKey, TValue> parent;

                while (true)
                {
                    parent = focusNode;

                    if (key.CompareTo(focusNode.Key) < 0)   // means key is less than focusNode.Key
                    {
                        focusNode = focusNode.LeftChild;

                        if (focusNode == null)  //focusNode has no left child
                        {
                            parent.LeftChild = newNode;
                            break;
                        }
                    }
                    else
                    {
                        focusNode = focusNode.RightChild;

                        if (focusNode == null)   //focusNode has no right child
                        {
                            parent.RightChild = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public void RemoveNode(TKey key)
        {
            TreeNode<TKey, TValue> focusNode = this.Root;
            TreeNode<TKey, TValue> parent = this.Root;

            bool isALeftChild = true;

            while (focusNode.Key.CompareTo(key) != 0)
            {
                parent = focusNode;

                if (key.CompareTo(focusNode.Key) < 0)
                {
                    isALeftChild = true;
                    focusNode = focusNode.LeftChild;
                }
                else
                {
                    isALeftChild = false;
                    focusNode = focusNode.RightChild;
                }

                if (focusNode == null)
                {
                    throw new KeyNotFoundException(string.Format("No node has a key of {0}", key));
                }
            }

            if (focusNode.LeftChild == null && focusNode.RightChild == null)
            {
                if (focusNode == Root)
                {
                    Root = null;
                }
                else if (isALeftChild)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }
            }
            else if (focusNode.RightChild == null)
            {
                if (focusNode == Root)
                {
                    Root = focusNode.LeftChild;
                }
                else if (isALeftChild)
                {
                    parent.LeftChild = focusNode.LeftChild;
                }
                else
                {
                    parent.RightChild = focusNode.LeftChild;
                }
            }
            else if (focusNode.LeftChild == null)
            {
                if (focusNode == Root)
                {
                    Root = focusNode.RightChild;
                }
                else if (isALeftChild)
                {
                    parent.LeftChild = focusNode.RightChild;
                }
                else
                {
                    parent.RightChild = focusNode.LeftChild;
                }
            }
            else
            {
                TreeNode<TKey, TValue> replacement = GetReplacementNode(focusNode);

                if (focusNode == Root)
                {
                    Root = replacement;
                }
                else if (isALeftChild)
                {
                    parent.LeftChild = replacement;
                }
                else
                {
                    parent.RightChild = replacement;
                }

                replacement.LeftChild = focusNode.LeftChild;
            }
        }

        private TreeNode<TKey, TValue> GetReplacementNode(TreeNode<TKey, TValue> replacedNode)
        {
            TreeNode<TKey, TValue> replacementParent = replacedNode;
            TreeNode<TKey, TValue> replacement = replacedNode;

            TreeNode<TKey, TValue> focusNode = replacedNode.RightChild;

            while (focusNode != null)
            {
                replacementParent = replacement;
                replacement = focusNode;
                focusNode = focusNode.LeftChild;
            }

            if (replacement != replacedNode.RightChild)
            {
                replacementParent.LeftChild = replacement.RightChild;
                replacement.RightChild = replacedNode.RightChild;
            }

            return replacement;
        }

        public TreeNode<TKey, TValue> FindNode(TKey key)
        {
            TreeNode<TKey, TValue> focusNode = Root;

            while (!focusNode.Key.Equals(key))
            {
                if (key.CompareTo(focusNode.Key) < 0)
                {
                    focusNode = focusNode.LeftChild;
                }
                else
                {
                    focusNode = focusNode.RightChild;
                }

                if (focusNode == null)  // node not found(reached a leaf)
                {
                    throw new KeyNotFoundException(string.Format("No node has a key of {0}", key));
                }
            }

            return focusNode;
        }

        public void PreOrderTraverseTree(TreeNode<TKey, TValue> focusNode)
        {
            if (focusNode != null)
            {
                Console.WriteLine(focusNode);

                PreOrderTraverseTree(focusNode.LeftChild);

                PreOrderTraverseTree(focusNode.RightChild);
            }
        }

        public void PostOrderTraverseTree(TreeNode<TKey, TValue> focusNode)
        {
            if (focusNode != null)
            {
                PostOrderTraverseTree(focusNode.LeftChild);

                PostOrderTraverseTree(focusNode.RightChild);

                Console.WriteLine(focusNode);
            }
        }

        public void InOrderTraverseTree(TreeNode<TKey, TValue> focusNode)   
        {
            if (focusNode != null)
            {
                InOrderTraverseTree(focusNode.LeftChild);

                Console.WriteLine(focusNode);

                InOrderTraverseTree(focusNode.RightChild);

            }
        }

        //TODO: Implement ICloneable

        //TODO: Implement IEnumerable<T>
    }
}
