namespace practice_2;

public class ConsoleApp : ConsoleHelpers
{
    private static readonly ConsoleActionAbstract[] Actions =
    {
        new AddNewStudentAction("Add new student", 1),
        new ShowStudentTableAction("Show all students", 2),
        new RemoveStudentAction("Remove student", 3),
        new ShowStudentTableByTaskAction("Show students the excellent student on first year of study", 4)
    };

    private DoublyLinkedList list;

    public ConsoleApp(DoublyLinkedList list)
    {
        this.list = list;
    }

    public void Run()
    {
        ListActions();
    }

    private void ListActions()
    {
        Console.WriteLine("Choose action:");
        
        foreach (var action in Actions)
        {
            Console.WriteLine($"{action.Index}. {action.Name}");
        }

        WaitForAction();
    }

    private void ExecuteAction(ConsoleActionAbstract action)
    {
        action.Execute(list);
        var isActionChangedList = action.Index is 1 or 3;
        
        if (isActionChangedList)
        {
            Actions[1].Execute(list);
        }

        ListActions();
        WaitForAction();
    }
    
    private void WaitForAction()
    {
        var actionIndex = GetActionIndexFromConsole();
        ExecuteAction(Actions.ElementAt(actionIndex));
    }

    private int GetActionIndexFromConsole()
    {
        var actionIndex = GetValidNumberFromConsole(
            "Invalid action index. Please, try again.",
            Enumerable.Range(1, Actions.Count()).ToArray()
        );

        return actionIndex - 1;
    }
}