using System;

public class Stack
{
    private ListNode1 _head;
    public void Add(int value)
    {
        ListNode1 node = new ListNode1(value);
        if (_head == null)
        {
            _head = node;
        }
        else
        {
            node.Next = _head;
            _head = node;
        }
    }
    public bool Remove(int value)
    {
        ListNode1 current_node = _head;
        if (_head == null)
        {
            return false;
        }
        if (_head.Value == value)
        {
            _head = _head.Next;
            return true;
        }
        while (current_node != null)
        {
            if (current_node.Next.Value == value)
            {
                current_node.Next = current_node.Next.Next;
                return true;
            }
            current_node = current_node.Next;
        }
        return false;
    }

    public void Clear()
    {
        ListNode1 current_node = _head;
        while (current_node != null)
        {
            ListNode1 next = current_node.Next;
            current_node.Next = null;
            current_node = next;
        }
    }

    public void Print()
    {
        ListNode1 current_node = _head;
        while (current_node != null)
        {
            Console.Write((current_node.Value)+" ");
            current_node= current_node.Next;
        }
    }
}