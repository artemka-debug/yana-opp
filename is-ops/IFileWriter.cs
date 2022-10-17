namespace practice_2.is_ops;

public interface IFileWriter<T>
{
    public T[] ReadAll();
    public void Write(T data);
}