namespace practice_2.Actions;

public class GetStudentsWithIdealWeightAction : ConsoleActionAbstract
{
    public GetStudentsWithIdealWeightAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers)
    {
        var students = _fileWriter.ReadStudents();

        var studentsWithIdealWeight = students.Where(student => student.Height - 110 == student.Weight).ToArray();
        
        consoleHelpers.PrintFormattedTableHeader(new string[] {"Name", "Surname", "Height", "Weight", "Passport series", "Passport number", "Student Id"});
        consoleHelpers.PrintLine();
        
        foreach (var student in studentsWithIdealWeight)
        {
            consoleHelpers.PrintFormattedTableRow(student);
        }
    }
}