using practice_2.models;

namespace practice_2.Actions;

public class ListLibrariansAction : ConsoleActionAbstract
{
    public ListLibrariansAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers)
    {
        var librarians = _fileWriter.ReadLibrarians();
        
        consoleHelpers.PrintFormattedTableHeader(new string[] {"Name", "Surname"});
        consoleHelpers.PrintLine();
        
        foreach (var librarian in librarians)
        {
            consoleHelpers.PrintFormattedTableRow(librarian);
        }
    }
}