namespace practice_2.models;

public class SoftwareDeveloper
{
    public SoftwareDeveloper(string firstName, string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }

    public string FirstName { get; }
    
    public string SecondName { get; }
}