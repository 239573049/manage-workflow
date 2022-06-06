namespace Token.ManagementApi.Host.Module;

public class PagingModelView<T> where T : class
{
    public PagingModelView(T data, int count)
    {
        Data = data;
        Count = count;
    }

    public int Count { get; set; }
    public T? Data { get; set; }

}
