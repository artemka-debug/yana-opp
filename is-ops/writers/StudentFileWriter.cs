namespace practice_2.is_ops.writers;

using System.Text.Json.Serialization;
using practice_2.models;
using System.Text;
using System.Text.Json;

public class StudentFileWriter : IFileWriter<Student>
{
    private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.txt");
    
    public Student[] ReadAll()
    {
        if (!File.Exists(_filePath))
        {
            return Array.Empty<Student>();
        }
        
        using FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
        var buffer = new byte[fs.Length];
        fs.Read(buffer, 0, buffer.Length);
        
        var json = Encoding.ASCII.GetString(buffer);
        var options = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString |
                             JsonNumberHandling.WriteAsString
        };
        
        Student[] result = new Student[100];
        var current = 0;

        foreach (var line in json.Split("\n"))
        {
            if (line.StartsWith("Student") || line.Trim() == "")
            {
                continue;
            }
            
            result[current++] = JsonSerializer.Deserialize<Student>(line, options);
        }
        
        return result.Take(current).ToArray();
    }

    public void Write(Student data)
    {
        var json = $"{JsonSerializer.Serialize(data)}\n";
        var metadata = $"{data.GetType().Name} {data.FirstName}{data.SecondName}\n";

        using FileStream fs = new FileStream(_filePath, FileMode.Append, FileAccess.Write);
        fs.Write(Encoding.ASCII.GetBytes(metadata), 0, metadata.Length);
        fs.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
    }

    public void Remove(string firstName, string lastName)
    {
        if (!File.Exists(_filePath))
        {
            return;
        }
        
        using FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
        var buffer = new byte[fs.Length];
        fs.Read(buffer, 0, buffer.Length);
        
        var json = Encoding.ASCII.GetString(buffer);
        var lines = json.Split("\n");
        var removeIndex = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            if (line.Contains($"\"FirstName\":\"{firstName}\",\"SecondName\":\"{lastName}\""))
            {
                removeIndex = i;
            }
        }
        
        lines = lines.Where((_, index) => index != removeIndex - 1 && index != removeIndex).ToArray();
        json = string.Join("\n", lines);

        using StreamWriter writer = new StreamWriter(_filePath, false);
        writer.Write(json);
    }
}