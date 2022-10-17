using practice_2.models;

namespace practice_2.Actions;

public class ListStudentsAction : ConsoleActionAbstract
{
    public ListStudentsAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers)
    {
        var students = _fileWriter.ReadStudents();
        
        consoleHelpers.PrintFormattedTableHeader(new string[] {"Name", "Surname", "Height", "Weight", "Passport series", "Passport number", "Student Id"});
        consoleHelpers.PrintLine();
        
        foreach (var student in students)
        {
            consoleHelpers.PrintFormattedTableRow(student);
        }
    }
}