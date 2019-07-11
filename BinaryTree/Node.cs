using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Node<T> where T: IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }

        public bool Add(T value)
        {
            if(Value.CompareTo(default) == 0)
            {
                Value = value;
                return true;
            }
            var result = Value.CompareTo(value);
            switch(result)
            {
                case 0: return false;
                case -1:
                    {
                        if (LeftNode == null)
                        {
                            LeftNode = new Node<T> { Value = value, Parent = this };
                            return true;
                        }
                        else
                        {
                            return LeftNode.Add(value);
                        }
                    }
                default:
                    {
                        if (RightNode == null)
                        {
                            RightNode = new Node<T> { Value = value, Parent = this };
                            return true;
                        }
                        else
                        {
                            return RightNode.Add(value);
                        }
                    }
            }
        }
    }
}
