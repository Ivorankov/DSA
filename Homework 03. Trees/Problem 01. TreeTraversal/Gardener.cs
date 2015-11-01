namespace Problem_01.TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Gardener
    {
        static void Main()
        {

            var tree =
                new Tree<int>(3,
                    new Tree<int>(5,
                        new Tree<int>(0),
                        new Tree<int>(1,
                            new Tree<int>(5),
                            new Tree<int>(2)),
                        new Tree<int>(6)),
                    new Tree<int>(2,
                        new Tree<int>(4)),
                    new Tree<int>(10,
                        new Tree<int>(11,
                            new Tree<int>(13),
                            new Tree<int>(14))),
                    new Tree<int>(9));


            var treeLeafs = ReadLeafs(tree.Root);
            Console.WriteLine("Leaf nodes");
            treeLeafs.ForEach(x => Console.WriteLine(x.Value));

            var middleTreeNodes = ReadMiddleNodes(tree.Root);
            Console.WriteLine("Middle nodes");
            middleTreeNodes.ForEach(x => Console.WriteLine(x.Value));

            var deepestBranch = tree.Root.Depth;
            Console.WriteLine("Deepest branch");
            Console.WriteLine("Max depth: " + (deepestBranch.Count - 1));
            deepestBranch.ForEach(x => Console.WriteLine(x.Value + " "));

            Console.WriteLine("Subtrees with given sum of theyr nodes");
            var treeCollection = FindTreesWithGivenSum(tree.Root, 7);
            foreach (var subtree in treeCollection)
            {
                Console.WriteLine(subtree.Value);
                for (int i = 0; i < subtree.ChildrenCount; i++)
                {
                    Console.Write(subtree.GetChild(i).Value + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Paths in tree with given sum");
            var pathCollection = FindAllPathsWithGivenSum(tree.Root, 8);
            foreach (var subPath in pathCollection)
            {
                foreach (var path in subPath)
                {
                    Console.Write(path + " - ");
                }
                Console.WriteLine();
            }
        }

        private static List<TreeNode<int>> ReadLeafs(TreeNode<int> tree)
        {
            List<TreeNode<int>> result = new List<TreeNode<int>>();
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                TreeNode<int> currentNode = stack.Pop();

                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<int> childNode = currentNode.GetChild(i);
                    stack.Push(childNode);
                }

                if (currentNode.ChildrenCount == 0)
                    result.Add(currentNode);
            }

            return result;
        }

        private static List<TreeNode<int>> ReadMiddleNodes(TreeNode<int> tree)
        {
            List<TreeNode<int>> result = new List<TreeNode<int>>();
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                TreeNode<int> currentNode = stack.Pop();

                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<int> childNode = currentNode.GetChild(i);
                    stack.Push(childNode);
                }

                if (currentNode.ChildrenCount != 0 && currentNode.Value != tree.Value)
                    result.Add(currentNode);
            }

            return result;
        }

        private static List<TreeNode<int>> FindTreesWithGivenSum(TreeNode<int> tree, int targetSum)
        {
            var treeCollection = new List<TreeNode<int>>();
            var resultSum = 0;
            for (int i = 0; i < tree.ChildrenCount; i++)
            {
                resultSum += tree.GetChild(i).Value;
            }

            if (resultSum == targetSum)
            {
                treeCollection.Add(tree);
            }

            for (int i = 0; i < tree.ChildrenCount; i++)
            {
                treeCollection.AddRange(FindTreesWithGivenSum(tree.GetChild(i), targetSum));
            }

            return treeCollection;
        }

        private static List<List<string>> FindAllPathsWithGivenSum(TreeNode<int> tree, int targetSum)
        {
            var pathCollection = new List<List<string>>();
            var currentSum = tree.Value;
            for (int i = 0; i < tree.ChildrenCount; i++)
            {
                var currentPath = new List<string>();
                currentPath.Add(tree.Value.ToString());
             currentPath.Add(tree.GetChild(i).Value.ToString());   
                currentSum += tree.GetChild(i).Value;

                if (currentSum == targetSum)
                {
                    pathCollection.Add(currentPath);
                }
                else if (currentSum > targetSum)
                {
                    var firstElement = currentPath.First();
                    currentSum -= int.Parse(firstElement);
                    currentPath.Remove(firstElement);
                }
                FindTreesWithGivenSum(tree.GetChild(i), targetSum);
            }

            return pathCollection;
        }
    }
}
