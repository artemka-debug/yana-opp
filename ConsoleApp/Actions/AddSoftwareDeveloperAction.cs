using practice_2.models;

namespace practice_2.Actions;

public class AddSoftwareDeveloperAction : ConsoleActionAbstract
{
    public AddSoftwareDeveloperAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers)
    {
        var firstName = consoleHelpers.GetStringWithMessage("Enter first name: ");
        var secondName = consoleHelpers.GetStringWithMessage("Enter second name: ");
        
        var softwareDeveloper = new SoftwareDeveloper(firstName, secondName);
        _fileWriter.Write(softwareDeveloper); 
    }
}