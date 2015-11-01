namespace Problem_01.TreeTraversal
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        private T value;

        private bool hasParent;

        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }

        public List<TreeNode<T>> Depth
        {
            get
            {
                List<TreeNode<T>> path = new List<TreeNode<T>>();
                foreach (TreeNode<T> node in this.children)
                {
                    List<TreeNode<T>> tmp = node.Depth;
                    if (tmp.Count > path.Count)
                        path = tmp;
                }
                path.Insert(0, this);
                return path;
            }
        }
    }
}
