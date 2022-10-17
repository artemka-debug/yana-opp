using practice_2.models;

namespace practice_2;

public class ConsoleHelpers
{
    private int tableWidth = 100;
    
    public double GetValidNumberFromConsole(string message, double[] validNumbers)
    {
        double number = 0;
        bool isValid = false;
        
        do {
            string input = Console.ReadLine();
            isValid = double.TryParse(input, out number) && (validNumbers.Length == 0 || validNumbers.Contains(number));
            if (isValid)
            {
                return number;
            }
            Console.WriteLine(message);
        } while (!isValid);

        return number;
    }
    
    public string GetStringWithMessage(string message)
    {
        Console.Write(message);
        var result = Console.ReadLine();
        
        return result ?? string.Empty;
    }
    
    public double GetNumberWithMessage(string message)
    {
        Console.Write(message);
        return GetValidNumberFromConsole("Invalid number", Array.Empty<double>());
    }
    
    public void PrintFormattedTableRow(Student student)
    {
        PrintRow(
            student.FirstName,
            student.SecondName, 
            student.Height.ToString(),
            student.Weight.ToString(),
            student.PassportNumber,
            student.PassportSeries,
            student.StudentId
        );
    }
    
    public void PrintFormattedTableRow(Librarian librarian)
    {
        PrintRow(
            librarian.FirstName, 
            librarian.SecondName
        );
    }
    
    public void PrintFormattedTableRow(SoftwareDeveloper softwareDeveloper)
    {
        PrintRow(
            softwareDeveloper.FirstName, 
            softwareDeveloper.SecondName
        );
    }
    
    public void PrintFormattedTableHeader(string[] headers)
    {
        PrintRow(headers);
    }
    
    public void PrintLine()
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