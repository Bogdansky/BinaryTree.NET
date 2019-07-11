using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class BinaryTree<T> where T: IComparable<T>
    {
        private Node<T> root;

        public int Size { get; private set; }

        #region Add and Set

        public bool SetRoot(T value)
        {
            if (root is null)
            {
                root = new Node<T>
                {
                    Value = value
                };
                Size++;
            }
            return root != null;
        }

        public Node<T> GetRoot()
        {
            return root;
        }

        public bool AppendNode(T value)
        {
            if (root != null)
            {
                bool added = root.Add(value);
                if (added)
                {
                    Size++;
                }
                return added;
            }
            return SetRoot(value);
        }
        #endregion

        #region Search
        // поиск в ширину
        public Node<T> BreadthFirstSearch(T value)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                Node<T> node = queue.Dequeue();
                if (node.Value.CompareTo(value) == 0)
                {
                    return node;
                }
                else
                {
                    queue.Enqueue(node.LeftNode);
                    queue.Enqueue(node.RightNode);
                }
            }
            return null;
        }

        // поиск в глубину
        public Node<T> DepthFirstSearch(T value)
        {
            return DepthFirstSearch(value, root);
        }

        private Node<T> DepthFirstSearch(T value, Node<T> currentNode)
        {
            if (currentNode is null)
            {
                return currentNode;
            }
            var result = currentNode.Value.CompareTo(value);
            switch(result)
            {
                case 0: return currentNode;
                case 1: return DepthFirstSearch(value, currentNode.RightNode);
                default: return DepthFirstSearch(value, currentNode.LeftNode);
            }
        }
        #endregion

        #region Research
        public List<T> InOrderResearch()
        {
            List<T> nodes = new List<T>();
            if (root is null)
            {
                return null;
            }
            InOrderResearch(root, ref nodes);
            return nodes;
        }
        public void InOrderResearch(Node<T> root, ref List<T> nodes)
        {
            if (root is null)
            {
                return;
            }
            InOrderResearch(root.LeftNode, ref nodes);
            nodes.Add(root.Value);
            InOrderResearch(root.RightNode, ref nodes);
        }

        public void PreOrderResearch(Node<T> currentNode, ref List<T> nodes)
        {
            if (currentNode is null)
            {
                return;
            }
            nodes.Add(currentNode.Value);
            PreOrderResearch(currentNode.LeftNode, ref nodes);
            PreOrderResearch(currentNode.RightNode, ref nodes);
        }

        #endregion
    }
}
