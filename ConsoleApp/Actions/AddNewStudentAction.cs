namespace practice_2;

public class AddNewStudentAction : ConsoleActionAbstract
{
    public AddNewStudentAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(DoublyLinkedList list)
    {
        Console.WriteLine($"Executing action {Name}");
        StudentName studentName = GetStudentName();
        int year = GetStudyingYear();
        int averageMark = GetAverageMark();
        
        list.Add(new Student(studentName, year, averageMark));
        Console.WriteLine($"\nStudent {studentName} added to the list");
    }
    
    private int GetAverageMark()
    {
        Console.WriteLine("Enter average mark(1-5): ");
        return GetValidNumberFromConsole(
            "Enter valid average mark", 
            Enumerable.Range(1, 5).ToArray()
        );
    }
    
    private StudentName GetStudentName()
    {
        Console.WriteLine("Select student name: ");
        var studentNames = Enum.GetValues(typeof(StudentName)).Cast<StudentName>().ToArray();

        for (int i = 0; i < studentNames.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {studentNames.ElementAt(i)}");
        }

        var studentIndex = GetValidNumberFromConsole(
            "Enter valid student name index", 
            Enumerable.Range(1, studentNames.Count()).ToArray()
            );
        
        return studentNames.ElementAt(studentIndex - 1);
    }
    
    private int GetStudyingYear()
    {
        Console.WriteLine("Enter studying year(1-4): ");
        return GetValidNumberFromConsole(
            "Enter valid studying year", 
            Enumerable.Range(1, 4).ToArray()
        );
    }
}