class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList() { 3, 5, 8, 13, 21 };

        foreach (ListNode node in list)
        {
            Console.Write(node.Value + " ");
        }
        // Вывод: 3 5 8 13 21
    }
}