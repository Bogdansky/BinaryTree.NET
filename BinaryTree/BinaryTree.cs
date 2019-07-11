using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class BinaryTree
    {
        private List<Node> nodes;
        private Node top;
        private int size;
        public int Size { get; }

        public BinaryTree()
        {
            nodes = new List<Node>();
        }

        public bool SetTop(Node node)
        {
            if (top is null)
            {
                top = node;
            }
            return top != null;
        }

        public Node GetTop()
        {
            return top;
        }

        public bool AppendNode(Node node)
        {
            if (top != null)
            {
                return AppendNode(node, top);
            }
            return SetTop(node);
        }

        private bool AppendNode(Node node, Node currentNode)
        {
            if (currentNode.Value < node.Value)
            {
                return Append(node, currentNode.LeftNode);
            }
            else if (currentNode.Value > node.Value)
            {
                return Append(node, currentNode.RightNode);
            }
            else
            {
                return false;
            }
        }

        private bool Append(Node node, Node currentNode)
        {
            if (currentNode is null)
            {
                currentNode = node;
                return true;
            }
            else
            {
                return AppendNode(node, currentNode);
            }
        }

        // поиск в ширину
        public Node BreadthFirstSearch(int value)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(GetTop());
            while(queue.Count != 0)
            {
                Node node = queue.Dequeue();
                if (node.Value == value)
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
        public Node DepthFirstSearch(int value)
        {
            return DepthFirstSearch(value, GetTop());
        }

        private Node DepthFirstSearch(int value, Node currentNode)
        {
            if (currentNode is null || currentNode.Value == value)
            {
                return currentNode;
            }
            else if (currentNode.Value > value)
            {
                return DepthFirstSearch(value, currentNode.RightNode);
            }
            else
            {
                return DepthFirstSearch(value, currentNode.LeftNode);
            }
        }
    }
}
