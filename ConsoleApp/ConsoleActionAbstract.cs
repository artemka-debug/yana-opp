namespace practice_2;

public abstract class ConsoleActionAbstract : ConsoleHelpers
{
    public string Name { get; }

    public int Index { get; }

    protected ConsoleActionAbstract(string name, int index)
    {
        this.Name = name;
        this.Index = index;
    }
    
    public abstract void Execute(DoublyLinkedList list);
}