
public class ListNode1
{
    public int Value { get; set; }
    public ListNode1 Next { get; set; }
    public ListNode1()
    {
        Next = null!;
    }
    public ListNode1(int value)
    {
        Value = value;
        Next = null!;
    }
}

public class ListNode
{
    public int Value { get; set; }
    public ListNode Next { get; set; }
    public ListNode Previous { get; set; }

    public ListNode(int value)
    {
        Value = value;
        Next = null!;
        Previous = null!;
    }
}