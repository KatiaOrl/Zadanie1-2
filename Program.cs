using System;

namespace Zadanie1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программирование в среде DOtNet");
            Console.WriteLine("Лкекция №1          Задание 1-2");
            Console.WriteLine("Бинарное дерево: заполнение, поиск, удаление элемента");
            Console.WriteLine("Выполнила: Орлова Е.В.  гр 7305");
            var binaryTree = new BinaryTree<int>();
            
            Console.WriteLine(new string('-', 40));
            //Ввод элементов списка
            Console.Write("Введите элементы для добавления в бинарное дерево: ");
            var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            
            // добавление элементов
            Console.WriteLine("Добавление элементов:");
            for (int i = 0; i < parts.Length; i++) {
                binaryTree.Add(Convert.ToInt32(parts[i]));
            }
        
            binaryTree.PrintTree();
            Console.WriteLine($"Число узлов дерева: {binaryTree.Count()}");

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Удаление узла");
            Console.Write("Введите узлы для удаления из бинарного дерева: ");
            parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            
            // удаление элементов
            Console.WriteLine("Удаление элементов:");
            for (int i = 0; i < parts.Length; i++) {
                Console.WriteLine($"Узел: {parts[i]} {(binaryTree.Contains(Convert.ToInt32(parts[i]))  ? "удален" : "отсутствует")}");
                if (binaryTree.Contains(Convert.ToInt32(parts[i]))) {
                    binaryTree.Remove(Convert.ToInt32(parts[i]));
                }
            }
            
            //binaryTree.Remove(3);
            binaryTree.PrintTree();
            Console.WriteLine($"Число узлов дерева: {binaryTree.Count()}");
            
        }
    }
}