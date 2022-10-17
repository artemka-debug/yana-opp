using practice_2.Actions;

namespace practice_2;

public class ConsoleApp
{
    private ConsoleHelpers _consoleHelpers = new ConsoleHelpers();
    private static readonly ConsoleActionAbstract[] _actions =
    {
        new GetStudentsWithIdealWeightAction("Get students with ideal weight", 1),
        new AddStudentAction("Add student", 2),
        new AddLibrarianAction("Add librarian", 3),
        new AddSoftwareDeveloperAction("Add software developer", 4),
        new ListStudentsAction("List student", 5),
        new ListLibrariansAction("List librarians", 6),
        new ListSoftwareDevelopersAction("List software developers", 7),
        new RemoveLibrarianAction("Remove librarian", 8),
        new RemoveSoftwareDeveloperAction("Remove software developer", 9),
        new RemoveStudentAction("Remove student", 10),
    };

    public void Run()
    {
        ListActions();
    }

    private void ListActions()
    {
        Console.WriteLine("Choose action:");
        
        foreach (var action in _actions)
        {
            Console.WriteLine($"{action.Index}. {action.Name}");
        }

        WaitForAction();
    }

    private void ExecuteAction(ConsoleActionAbstract action)
    {
        action.Execute(_consoleHelpers);
        ListActions();
        WaitForAction();
    }
    
    private void WaitForAction()
    {
        var actionIndex = GetActionIndexFromConsole();
        ExecuteAction(_actions.ElementAt(actionIndex));
    }

    private int GetActionIndexFromConsole()
    {
        var doubleRange = Enumerable.Range(1, _actions.Count()).ToArray().Select(x => (double)x).ToArray(); 
        
        var actionIndex = _consoleHelpers.GetValidNumberFromConsole(
            "Invalid action index. Please, try again.",
            doubleRange
        );

        return (int)actionIndex - 1;
    }
}