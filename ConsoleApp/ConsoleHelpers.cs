namespace practice_2;

public class ConsoleHelpers
{
    private int tableWidth = 100;
    
    protected int GetValidNumberFromConsole(string message, int[] validNumbers)
    {
        int number = 0;
        bool isValid = false;
        
        do {
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out number) && validNumbers.Contains(number);
            if (isValid)
            {
                return number;
            }
            Console.WriteLine(message);
        } while (!isValid);

        return number;
    }
    
    protected void PrintFormattedTableRow(Student student)
    {
        PrintRow(
            student.Name.ToString(), 
            student.StudyingYear.ToString(), 
            student.AverageMark.ToString()
        );
    }
    
    protected void PrintFormattedTableHeader(bool useIndex = true)
    {
        var headers = useIndex ? 
            new string[] { "Index", "Name", "Year", "Average Mark" } : 
            new string[] { "Name", "Year", "Average Mark" };
        
        PrintRow(headers);
    }
    
    protected void PrintFormattedTableRow(int index, Student student)
    {
        PrintRow(
            index.ToString(), 
            student.Name.ToString(), 
            student.StudyingYear.ToString(), 
            student.AverageMark.ToString()
        );
    }
    
    protected void PrintLine()
    {
        Console.WriteLine(new string('-', tableWidth));
    }

    private void PrintRow(params string[] columns)
    {
        int width = (tableWidth - columns.Length) / columns.Length;
        string row = "|";

        foreach (string column in columns)
        {
            row += AlignCentre(column, width) + "|";
        }

        Console.WriteLine(row);
    }

    private string AlignCentre(string text, int width)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }

        return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
    }
}