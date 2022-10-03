namespace practice_2;

public interface IDoubleLinkedList
{
    public DoublyLinkedList FindStudentsByTask();
    public IEnumerator<Student> GetEnumerator();
    public void Add(Student student);
    public void AddFirst(Student student);
    public void RemoveTail();
    
    public void Remove(int index);
    public void Change(Student student, int index);
    public int Size();
    public DoublyLinkedList GetInRange(int start, int end);
}