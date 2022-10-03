namespace practice_2;

public class Program
{
    public static void Main()
    {
        var studentsList = new DoublyLinkedList();
        var consoleApp = new ConsoleApp(studentsList);

        consoleApp.Run();
    }
}
