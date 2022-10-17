namespace practice_2.models;

public class Librarian {
    public Librarian(string firstName, string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }

    public string FirstName { get; }
    
    public string SecondName { get; }
}