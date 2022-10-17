using practice_2.models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace practice_2.is_ops.writers;

public class LibrarianWriter : IFileWriter<Librarian>
{
    private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "librarians.txt");
    
    public Librarian[] ReadAll()
    {
        if (!File.Exists(_filePath))
        {
            return Array.Empty<Librarian>();
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
        
        Librarian[] result = new Librarian[100];
        var current = 0;

        foreach (var line in json.Split("\n"))
        {
            if (line.StartsWith("Librarian") || line.Trim() == "")
            {
                continue;
            }
            
            result[current++] = JsonSerializer.Deserialize<Librarian>(line, options);
        }
        
        return result.Take(current).ToArray();
    }

    public void Write(Librarian data)
    {
        var json = JsonSerializer.Serialize(data);
        var metadata = $"{data.GetType().Name} {data.FirstName}{data.SecondName}\n";

        using FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write);
        fs.Write(Encoding.ASCII.GetBytes(metadata), 0, metadata.Length);
        fs.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
    }
}