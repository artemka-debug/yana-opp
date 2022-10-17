using practice_2.models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace practice_2.is_ops.writers;

public class SoftwareDeveloperWriter : IFileWriter<SoftwareDeveloper>
{
    private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "software-developers.txt");
    
    public SoftwareDeveloper[] ReadAll()
    {
        if (!File.Exists(_filePath))
        {
            return Array.Empty<SoftwareDeveloper>();
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
        
        SoftwareDeveloper[] result = new SoftwareDeveloper[100];
        var current = 0;

        foreach (var line in json.Split("\n"))
        {
            if (line.StartsWith("SoftwareDeveloper") || line.Trim() == "")
            {
                continue;
            }
            
            result[current++] = JsonSerializer.Deserialize<SoftwareDeveloper>(line, options);
        }
        
        return result.Take(current).ToArray();
    }

    public void Write(SoftwareDeveloper data)
    {
        var json = JsonSerializer.Serialize(data);
        var metadata = $"{data.GetType().Name} {data.FirstName}{data.SecondName}\n";

        using FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write);
        fs.Write(Encoding.ASCII.GetBytes(metadata), 0, metadata.Length);
        fs.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
    }
}