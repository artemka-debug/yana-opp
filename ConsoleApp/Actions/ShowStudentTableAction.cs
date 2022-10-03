namespace practice_2;

public class ShowStudentTableAction : ConsoleActionAbstract
{
    public ShowStudentTableAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(DoublyLinkedList list)
    {
        var studentsCount = list.Size();

        if (studentsCount == 0)
        {
            Console.WriteLine("There are no students in the list");
            return;
        }
        
        Console.WriteLine("Students in the list:");
        PrintLine();
        PrintFormattedTableHeader();
        PrintLine();
        
        for (int i = 0; i < studentsCount; i++)
        {
            PrintFormattedTableRow(i + 1, list[i]);
        }
        
        PrintLine();
    }
}