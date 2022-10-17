namespace practice_2.Actions;

public class RemoveSoftwareDeveloperAction : ConsoleActionAbstract
{
    public RemoveSoftwareDeveloperAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers)
    {
        var firstName = consoleHelpers.GetStringWithMessage("Enter first name: ");
        var secondName = consoleHelpers.GetStringWithMessage("Enter second name: ");
        
        _fileWriter.RemoveSoftwareDevelopers(firstName, secondName); 
    }
}