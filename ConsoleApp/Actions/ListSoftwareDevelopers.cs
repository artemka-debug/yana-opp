using practice_2.models;

namespace practice_2.Actions;

public class ListSoftwareDevelopersAction : ConsoleActionAbstract
{
    public ListSoftwareDevelopersAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers)
    {
        var softwareDevelopers = _fileWriter.ReadSoftwareDevelopers();
        
        consoleHelpers.PrintFormattedTableHeader(new string[] {"Name", "Surname"});
        consoleHelpers.PrintLine();
        
        foreach (var softwareDeveloper in softwareDevelopers)
        {
            consoleHelpers.PrintFormattedTableRow(softwareDeveloper);
        }
    }
}