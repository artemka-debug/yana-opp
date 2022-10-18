namespace practice_2.is_ops;

public interface IFileWriter<T>
{
    public T[] ReadAll(); //gen. if
    public void Write(T data); 

    public void Remove(string firstName, string lastName);
}