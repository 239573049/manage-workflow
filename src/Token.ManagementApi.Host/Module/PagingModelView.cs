namespace Token.ManagementApi.Host.Module;

/// <summary>
/// 分页模型
/// </summary>
/// <typeparam name="T"></typeparam>
public class PagingModelView<T> where T : class
{

    /// <inheritdoc/>
    public PagingModelView(T data, int count)
    {
        Data = data;
        Count = count;
    }

    /// <summary>
    /// 总条数
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 分页数据
    /// </summary>
    public T? Data { get; set; }

}
