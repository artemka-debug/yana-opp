namespace practice_2;

public enum StudentName {John, Paul, George, Ringo};

public class Student
{
    public StudentName Name { get; }
    public int StudyingYear { get; }
    
    public int AverageMark { get; }

    public Student(StudentName name, int studyingYear, int averageMark)
    {
        this.Name = name;
        this.StudyingYear = studyingYear;
        this.AverageMark = averageMark;
    }
}