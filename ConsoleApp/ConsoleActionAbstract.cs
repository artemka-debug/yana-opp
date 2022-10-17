using practice_2.is_ops;

namespace practice_2;

public abstract class ConsoleActionAbstract
{
    public string Name { get; }

    public int Index { get; }

    protected readonly FileWriter _fileWriter = new FileWriter();
    
    protected ConsoleActionAbstract(string name, int index)
    {
        this.Name = name;
        this.Index = index;
    }
    
    public abstract void Execute(ConsoleHelpers consoleHelpers);
}