namespace practice_2.models;

public class Student
{
    public Student(string firstName, string secondName, double height, double weight, string studentId, string passportSeries, string passportNumber)
    {
        FirstName = firstName;
        SecondName = secondName;
        Height = height;
        Weight = weight;
        StudentId = studentId;
        PassportSeries = passportSeries;
        PassportNumber = passportNumber;
    }

    public string FirstName { get; }
    
    public string SecondName { get; }
    
    public double Height { get; }
    
    public double Weight { get; }
    
    public string StudentId { get; }
    
    public string PassportSeries { get; }
    
    public string PassportNumber { get; }
}