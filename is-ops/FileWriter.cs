using practice_2.is_ops.writers;
using practice_2.models;

namespace practice_2.is_ops;

public class FileWriter
{
    
    private readonly StudentFileWriter _studentFileWriter = new StudentFileWriter();
    private readonly LibrarianWriter _librarianWriter = new LibrarianWriter();
    private readonly SoftwareDeveloperWriter _softwareDeveloperWriter = new SoftwareDeveloperWriter();
 
    public void Write(Student obj)
    {
        _studentFileWriter.Write(obj);
    }
    
    public void Write(Librarian obj)
    {
        _librarianWriter.Write(obj);
    }
    
    public void Write(SoftwareDeveloper obj)
    {
        _softwareDeveloperWriter.Write(obj);
    }
    
    public Student[] ReadStudents()
    {
        return _studentFileWriter.ReadAll();
    }
    
    public Librarian[] ReadLibrarians()
    {
        return _librarianWriter.ReadAll();
    }
    
    public SoftwareDeveloper[] ReadSoftwareDevelopers()
    {
        return _softwareDeveloperWriter.ReadAll();
    }
}