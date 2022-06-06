using Token.Management.Domain.Base;

namespace Token.Infrastructure;

public class SerialNumberHelper
{
    /// <summary>
    ///     分页数据增加序号
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataList"></param>
    /// <param name="indexPage"></param>
    /// <param name="indexSize"></param>
    /// <returns></returns>
    public static IList<T> GetList<T>(IList<T> dataList, int indexPage, int indexSize) where T : SerialNumberEntity
    {
        int i = (indexPage - 1) * indexSize + 1;
        dataList.ToList().ForEach(a => a.Key = i++);
        return dataList;
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataList"></param>
    /// <param name="indexPage"></param>
    /// <param name="indexSize"></param>
    /// <returns></returns>
    public static List<T> GetList<T>(List<T> dataList, int indexPage, int indexSize) where T : SerialNumberEntity
    {
        int i = (indexPage - 1) * indexSize + 1;
        dataList.ToList().ForEach(a => a.Key = i++);
        return dataList;
    }
}
