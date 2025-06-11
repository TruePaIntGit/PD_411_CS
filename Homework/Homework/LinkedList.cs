using System;
using System.Collections;

public class LinkedList : IEnumerable, IDisposable
{
    private ListNode _head;
    private ListNode _tail;

    public ListNode Head => _head;
    public ListNode Tail => _tail;

    public void AddLast(int value)
    {
        var node = new ListNode(value);

        if (_head == null)
        {
            _head = _tail = node;
        }
        else
        {
            _tail.Next = node;
            node.Previous = _tail;
            _tail = node;
        }
    }

    public void Add(int value)
    {
        AddLast(value);
    }

    public IEnumerator GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current;
            current = current.Next;
        }
    }

    public void Clear()
    {
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            current.Previous = null;
            current.Next = null;
            current = next;
        }

        _head = _tail = null;
    }

    public void Dispose()
    {
        Clear();
        GC.SuppressFinalize(this);
    }

    ~LinkedList()
    {
        Console.WriteLine("Список удален сборщиком мусора");
    }
}
