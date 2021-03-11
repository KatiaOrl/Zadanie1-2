using System;

namespace Zadanie1_2
{
    // Бинарное дерево
    public class BinaryTree<T> where T : IComparable {
        // Корень бинарного дерева
        public BinaryTreeNode<T> RootNode { get; set; }
        private int _count = 0;
        public int Count() { return _count; }

        // Добавление нового узла в бинарное дерево
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null) {
            if (RootNode == null) {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }
        
        // Добавление данных в бинарное дерево
        public BinaryTreeNode<T> Add(T data) {
            _count++;
            return Add(new BinaryTreeNode<T>(data));
        }
        
        // Поиск узла по значению
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = data.CompareTo(startWithNode.Data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }
        
        // Удаление узла бинарного дерева
        public void Remove(BinaryTreeNode<T> node) {
            if (node == null) {
                return;
            }
            _count--;
            var currentNodeSide = node.NodeSide;
            //если у узла нет подузлов, можно его удалить
            if (node.LeftNode == null && node.RightNode == null) {
                if (currentNodeSide == Side.Left) {
                    node.ParentNode.LeftNode = null;
                }else {
                    node.ParentNode.RightNode = null;
                }
            }
            //если нет левого, то правый ставим на место удаляемого 
            else if (node.LeftNode == null) {
                if (currentNodeSide == Side.Left) {
                    node.ParentNode.LeftNode = node.RightNode;
                }else {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            //если нет правого, то левый ставим на место удаляемого 
            else if (node.RightNode == null) {
                if (currentNodeSide == Side.Left) {
                    node.ParentNode.LeftNode = node.LeftNode;
                }else{
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            //если оба дочерних присутствуют, 
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else {
                switch (currentNodeSide) {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }
        
        // Удаление узла дерева
        public void Remove(T data) {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }
        
        // Есть ли узел с данным значением в дереве
        public bool Contains(T data) {
            return FindNode(data) != null;
        }
        
        //Удаляет все узлы дерева.
        public void Clear() {
            RootNode = null;
            _count = 0;
        }
        
        // Вывод бинарного дерева
        public void PrintTree() {
            PrintTree(RootNode);
        }

        // Вывод бинарного дерева начиная с указанного узла
        private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null) {
            if (startNode != null) {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }
        
    }
}