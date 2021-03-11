using System;

namespace Zadanie1_2
{
    // Расположения узла относительно родителя
    public enum Side
    {
        Left,
        Right
    }
    
    // Узел бинарного дерева

    public class BinaryTreeNode<T> where T : IComparable
    {
        // Конструктор класса
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        
        // Данные которые хранятся в узле
       public T Data { get; set; }

        // Левая ветка
        public BinaryTreeNode<T> LeftNode { get; set; }

        // Правая ветка
        public BinaryTreeNode<T> RightNode { get; set; }

        // Родитель
       public BinaryTreeNode<T> ParentNode { get; set; }

        // Расположение узла относительно его родителя
        public Side? NodeSide =>
            ParentNode == null
                ? (Side?)null
                : ParentNode.LeftNode == this
                    ? Side.Left
                    : Side.Right;

        // Преобразование экземпляра класса в строку
        public override string ToString() => Data.ToString();
        
        // Сравнивает текущий узел с данным.
        // 
        // Сравнение производится по полю Data.
        // Метод возвращает 1, если значение текущего узла больше,
        // чем переданного методу, -1, если меньше и 0, если они равны
        public int CompareTo(T other) {
            return Data.CompareTo(other);
        }
    }
    
}