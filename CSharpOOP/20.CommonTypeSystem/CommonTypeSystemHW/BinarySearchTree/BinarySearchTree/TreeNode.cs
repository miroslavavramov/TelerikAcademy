namespace BinarySearchTree
{
    using System;

    class TreeNode<TKey, TValue>
        where TKey : IComparable
    {
        public TreeNode(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
        
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public TreeNode<TKey, TValue> LeftChild { get; set; }

        public TreeNode<TKey, TValue> RightChild { get; set; }
        
        public override string ToString()
        {
            return string.Format("KEY: {0} VALUE: {1}", this.Key, this.Value);
        }

        public override bool Equals(object obj)
        {
            return obj == null ? 
                false : this.Key.CompareTo((obj as TreeNode<TKey, TValue>).Key) == 0;
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode() ^ this.Value.GetHashCode();
        }
    }
}
