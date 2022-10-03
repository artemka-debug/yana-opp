namespace practice_2;

public class ShowStudentTableByTaskAction : ConsoleActionAbstract
{
    public ShowStudentTableByTaskAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(DoublyLinkedList list)
    {
        var studentsByTask = list.FindStudentsByTask();
        var studentsCount = studentsByTask.Size();

        if (studentsCount == 0)
        {
            Console.WriteLine("There are no students that match task conditions");
            return;
        }
        
        Console.WriteLine("Students in the list:");
        PrintLine();
        PrintFormattedTableHeader(false);
        PrintLine();
        
        for (int i = 0; i < studentsCount; i++)
        {
            PrintFormattedTableRow(list[i]);
        }
        
        PrintLine();
    }
}