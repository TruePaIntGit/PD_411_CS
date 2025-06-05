using System;
using System.Security.Cryptography.X509Certificates;

namespace BinaryTreeProject
{
    class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    class BinarySearchTree
    {
        private Node root;

        // Вставка нового элемента
        public void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private Node InsertRec(Node current, int value)
        {
            if (current == null)
                return new Node(value);

            if (value < current.Value)
                current.Left = InsertRec(current.Left, value);
            else if (value > current.Value)
                current.Right = InsertRec(current.Right, value);

            return current;
        }

        // Поиск минимального значения
        public int? Min()
        {
            if (root == null) return null;
            Node current = root;
            while (current.Left != null)
                current = current.Left;
            return current.Value;
        }

        // Поиск максимального значения
        public int? Max()
        {
            if (root == null) return null;
            Node current = root;
            while (current.Right != null)
                current = current.Right;
            return current.Value;
        }

        // Глубина дерева
        public int Depth()
        {
            return GetDepth(root);
        }

        private int GetDepth(Node node)
        {
            if (node == null)
                return 0;

            int leftDepth = GetDepth(node.Left);
            int rightDepth = GetDepth(node.Right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        // Удаление узла с заданным значением
        public bool Erase(int value)
        {
            bool result = false;
            root = DeleteRec(root, value, ref result);
            return result;
        }

        private Node DeleteRec(Node current, int value, ref bool deleted)
        {
            if (current == null) return null;

            if (value < current.Value)
                current.Left = DeleteRec(current.Left, value, ref deleted);
            else if (value > current.Value)
                current.Right = DeleteRec(current.Right, value, ref deleted);
            else
            {
                deleted = true;

                // Узел с одним или без потомков
                if (current.Left == null)
                    return current.Right;
                else if (current.Right == null)
                    return current.Left;

                // Узел с двумя потомками: возьмём минимум из правого поддерева
                current.Value = MinValue(current.Right);
                current.Right = DeleteRec(current.Right, current.Value, ref deleted);
            }

            return current;
        }

        private int MinValue(Node node)
        {
            int min = node.Value;
            while (node.Left != null)
            {
                min = node.Left.Value;
                node = node.Left;
            }
            return min;
        }

        // Полная очистка дерева
        public void Clear()
        {
            root = null;
        }

        // Для отладки: вывод дерева (обход в прямом порядке)
        public void PrintInOrder()
        {
            InOrderTraversal(root);
            Console.WriteLine();
        }

        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversal(node.Right);
            }
        }

        private void InOrderToList(Node node, List<int> list)
        {
            if (node != null)
            {
                InOrderToList(node.Left, list);
                list.Add(node.Value);
                InOrderToList(node.Right, list);
            }
        }

        private Node BuildBalancedTree(List<int> values, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            Node node = new Node(values[mid]);

            node.Left = BuildBalancedTree(values, start, mid - 1);
            node.Right = BuildBalancedTree(values, mid + 1, end);

            return node;
        }

        // Балансировка дерева
        public void Balance()
        {
            List<int> values = new List<int>();
            InOrderToList(root, values);

            root = BuildBalancedTree(values, 0, values.Count - 1);
        }

        // Графическое представление дерева с ветвями и узлами
        public void PrintTree()
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пустое.");
                return;
            }

            PrintTreeRec(root, "", "", true);
        }

        private void PrintTreeRec(Node node, string indent, string prefix, bool isTail)
        {
            if (node != null)
            {
                Console.Write(indent);
                Console.Write(isTail ? "└── " : "├── ");
                Console.WriteLine(prefix + node.Value);

                string newIndent = indent + (isTail ? "    " : "│   ");

                if (node.Right != null)
                {
                    PrintTreeRec(node.Right, newIndent, "R: ", node.Left == null);
                }

                if (node.Left != null)
                {
                    PrintTreeRec(node.Left, newIndent, "L: ", true);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(51);

            Console.WriteLine("In-order обход дерева:");
            tree.PrintInOrder(); // 20 30 40 50 51 60 70

            Console.WriteLine("Минимум: " + tree.Min()); // 20
            Console.WriteLine("Максимум: " + tree.Max()); // 70
            Console.WriteLine("Глубина дерева: " + tree.Depth()); // 4


            Console.WriteLine("Глубина до балансировки: " + tree.Depth());
            tree.PrintTree();
            tree.Balance();
            Console.WriteLine("Глубина после балансировки: " + tree.Depth());
            tree.PrintTree();

            Console.WriteLine("Удаляем 20");
            tree.Erase(20);
            tree.PrintInOrder(); // 30 40 50 51 60 70

            Console.WriteLine("Очищаем дерево");
            tree.Clear();
            tree.PrintInOrder(); // Пусто

        }
    }
}