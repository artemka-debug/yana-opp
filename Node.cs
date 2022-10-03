namespace practice_2;

public class Node 
{
    public Student Student { get; set; }
    public Node Next { get; set; }
    public Node Previous { get; set; }
    
    public Node(Student student, Node next, Node prev)
    {
        this.Student = student;
        this.Next = next;
        this.Previous = prev;
    }
}