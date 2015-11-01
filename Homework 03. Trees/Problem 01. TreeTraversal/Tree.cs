namespace Problem_01.TreeTraversal
{
    using System;

    public class Tree<T> //Shout-out to whom ever wrote the demo :)
    {
        private TreeNode<T> root;

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.Root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }


        public TreeNode<T> Root
        {
            get { return this.root; }
            private set { this.root = value; }
        }
    }
}

