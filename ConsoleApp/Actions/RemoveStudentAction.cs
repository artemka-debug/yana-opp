namespace practice_2.Actions;

public class RemoveStudentAction : ConsoleActionAbstract
{
    public RemoveStudentAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers)
    {
        var firstName = consoleHelpers.GetStringWithMessage("Enter first name: ");
        var secondName = consoleHelpers.GetStringWithMessage("Enter second name: ");
        
        _fileWriter.RemoveStudents(firstName, secondName); 
    }
}