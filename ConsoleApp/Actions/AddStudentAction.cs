using practice_2.models;

namespace practice_2.Actions;

public class AddStudentAction : ConsoleActionAbstract
{
    public AddStudentAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers)
    {
        var firstName = consoleHelpers.GetStringWithMessage("Enter first name: ");
        var secondName = consoleHelpers.GetStringWithMessage("Enter second name: ");

        var height = consoleHelpers.GetNumberWithMessage("Enter your height: ");
        var weight = consoleHelpers.GetNumberWithMessage("Enter your weight: ");
        
        var studentId = consoleHelpers.GetStringWithMessage("Enter student id: ");
        var passportSeries = consoleHelpers.GetStringWithMessage("Enter passport series: ");
        var passportNumber = consoleHelpers.GetStringWithMessage("Enter passport number: ");
        
        var student = new Student(firstName, secondName, height, weight, studentId, passportSeries, passportNumber);
        _fileWriter.Write(student);
    }
}