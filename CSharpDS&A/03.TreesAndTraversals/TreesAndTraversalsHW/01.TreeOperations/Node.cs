namespace TreeOperations
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        public Node(int value, Node parent = null)
        {
            this.Value = value;
            this.Parent = parent;
            this.Children = new List<Node>();
        }

        public int Value { get; private set; }

        public Node Parent { get; set; }

        public ICollection<Node> Children { get; private set; }

        public bool HasChildren
        {
            get
            {
                return this.Children.Count > 0;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.Parent != null;
            }
        }

        public void AddChild(Node child)
        {
            this.Children.Add(child);
        }

        public override string ToString()
        {
            var output = new System.Text.StringBuilder();

            output.Append(this.Value.ToString());

            if (this.Children.Count > 0)
            {
                output.AppendFormat("[-> {0}]", string.Join(", ", this.Children));
            }

            return output.ToString();
        }
    }
}
