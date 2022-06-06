using System.Security.Cryptography;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace Token.Infrastructure.Extension;

public class DESExtension:ISingletonDependency
{
    private const string Key = "TOKENKEY";

    /// <summary>
    /// DES加密
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string DESEncrypt(string value)
    {
        DESCryptoServiceProvider des = new();
        var inputByteArray = Encoding.Default.GetBytes(value);
        des.Key = Encoding.ASCII.GetBytes(Key);
        des.IV = Encoding.ASCII.GetBytes(Key);
        var ms = new MemoryStream();
        var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        var ret = new StringBuilder();
        foreach (var b in ms.ToArray())
        {
            ret.AppendFormat("{0:X2}", b);
        }
        ret.ToString();
        return ret.ToString();

    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string DESDecrypt(string value)
    {
        DESCryptoServiceProvider des = new();
        var inputByteArray = new byte[value.Length / 2];
        for (var x = 0; x < value.Length / 2; x++)
        {
            var i = Convert.ToInt32(value.Substring(x * 2, 2), 16);
            inputByteArray[x] = (byte)i;
        }
        des.Key = Encoding.ASCII.GetBytes(Key);
        des.IV = Encoding.ASCII.GetBytes(Key);
        var ms = new MemoryStream();
        var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return Encoding.Default.GetString(ms.ToArray());
    }

}
