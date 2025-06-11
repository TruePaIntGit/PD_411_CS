class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList() { 3, 5, 8, 13, 21 };

        foreach (ListNode node in list)
        {
            Console.Write(node.Value + " ");
        }
        Console.WriteLine('\n');
        // Вывод: 3 5 8 13 21

        Stack st = new Stack();
        st.Add(1);
        st.Add(2);
        st.Add(3);
        st.Add(4);
        st.Add(5);
        st.Add(6);
        st.Add(7);
        st.Print();
        Console.WriteLine('\n');
        st.Remove(3);
        st.Print();
    }
}