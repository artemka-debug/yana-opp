namespace practice_2;

public class RemoveStudentAction : ConsoleActionAbstract
{
    public RemoveStudentAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(DoublyLinkedList list)
    {
        if (list.Size() == 0)
        {
            Console.WriteLine("Cannot delete from an empty list");
            return;
        }
        
        var studentIndex = GetStudentIndex(list.Size());
        list.Remove(studentIndex - 1);
    }

    private int GetStudentIndex(int maxIndex)
    {
        Console.WriteLine("Enter index of student you want to delete: ");
        return GetValidNumberFromConsole(
            "Enter valid student index", 
            Enumerable.Range(1, maxIndex).ToArray()
        );
    }
}