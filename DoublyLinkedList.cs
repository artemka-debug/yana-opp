using System.Collections;

namespace practice_2;
// create two direction linked list

public class DoublyLinkedList : IDoubleLinkedList, IEnumerable<Student>
{
    private Node head = null;
    public Node Head => head;
    
    private Node tail = null;
    public Node Tail => Tail;

    public DoublyLinkedList FindStudentsByTask()
    {
        var list = new DoublyLinkedList();

        for (int i = 0; i < Size(); i++) 
        {
            var student = Get(i);
            if (student.AverageMark > 4 && student.StudyingYear == 1)
            {
                list.Add(student);
            }
        }

        return list;
    }
    
    public IEnumerator<Student> GetEnumerator()
    {
        Node current = tail;
        while (current != null)
        {
            yield return current.Student;
            current = current.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public Student this[int i]
    {
        get => Get(i);
        set => Change(value, i);
    }

    public void Add(Student student)
    {
        if (head == null)
        {
            head = new Node(student, null, null);
            tail = head;
            return;
        }

        Node newNode = new Node(student, null, tail);
        tail.Next = newNode;
        tail = newNode;
    }
    
    public void AddFirst(Student student)
    {
        if (head == null)
        {
            head = new Node(student, null, null);
            tail = head;
            return;
        }

        Node newNode = new Node(student, head, null);
        head.Previous = newNode;
        head = newNode;
    }
    
    public void Remove(int index)
    {
        VerifyIndex(index);

        if (Size() == 1)
        {
            head = null;
            tail = null;
            return;
        }

        if (index == 0)
        {
            head = head.Next;
            head.Previous = null;
            return;
        }

        if (index == Size() - 1)
        {
            tail = tail.Previous;
            tail.Next = null;
            return;
        }

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        current.Previous.Next = current.Next;
        current.Next.Previous = current.Previous;
    }
    
    public void RemoveTail()
    {
        if (tail == null)
        {
            throw new Exception("Cannot remove tail from empty list");
        }

        tail = tail.Previous;
        tail.Next = null;
    }
    
    public void Change(Student student, int index)
    {
        if (head == null)
        {
            throw new Exception("Cannot change from empty list");
        }

        VerifyIndex(index);

        Node current = head;
        int currentIndex = 0;
        
        while (current != null)
        {
            if (currentIndex == index)
            {
                current.Student = student;
                return;
            }
            
            currentIndex++;
            current = current.Next;
        }
    }
    
    public Student Get(int index)
    {
        if (head == null)
        {
            throw new Exception("Cannot get from empty list");
        }

        VerifyIndex(index);

        Node current = head;
        int currentIndex = 0;
        
        while (current != null)
        {
            if (currentIndex == index)
            {
                return current.Student;
            }
            
            currentIndex++;
            current = current.Next;
        }
        
        return null;
    }
    
    public int Size()
    {
        int size = 0;
        Node current = head;
        
        while (current != null)
        {
            size++;
            current = current.Next;
        }
        
        return size;
    }
    
    public DoublyLinkedList GetInRange(int start, int end)
    {
        VerifyIndex(start);
        VerifyIndex(end);
        
        if (start > end)
        {
            throw new Exception("Start index cannot be greater than end index");
        }
        
        DoublyLinkedList result = new DoublyLinkedList();
        
        Node current = head;
        int currentIndex = 0;
        
        while (current != null)
        {
            if (currentIndex >= start && currentIndex <= end)
            {
                result.Add(current.Student);
            }
            
            currentIndex++;
            current = current.Next;
        }
        
        return result;
    }
    
    private void VerifyIndex(int index)
    {
        if (index < 0 || index >= Size())
        {
            throw new Exception("Index out of range");
        }
    }
}
