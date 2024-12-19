using System.ComponentModel;
using System.Text;

namespace Pek.DataConvertTool;

/// <summary>
/// 字符串类型数据转换类
/// </summary>
[Description("字符串类型数据转换类")]
public class StringLib
{
    /// <summary>
    /// 将字节数组转换成字符串
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="count">数量</param>
    /// <returns>转换结果</returns>
    [Description("将字节数组转换成字符串")]
    public static String GetStringFromByteArrayByBitConvert(Byte[] value, Int32 start, Int32 count) => BitConverter.ToString(value, start, count);

    /// <summary>
    /// 将字节数组转换成字符串
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <returns>转换结果</returns>
    [Description("将字节数组转换成字符串")]
    public static String GetStringFromByteArrayByBitConvert(Byte[] value) => BitConverter.ToString(value, 0, value.Length);

    /// <summary>
    /// 将字节数组转换成带编码格式字符串
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="count">数量</param>
    /// <param name="encoding">编码格式</param>
    /// <returns>转换结果</returns>
    [Description("将字节数组转换成带编码格式字符串")]
    public static String GetStringFromByteArrayByEncoding(Byte[] value, Int32 start, Int32 count, Encoding encoding) => encoding.GetString(ByteArrayLib.GetByteArrayFromByteArray(value, start, count));

    /// <summary>
    /// 将字节数组转换成带编码格式字符串
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="encoding">编码格式</param>
    /// <returns>转换结果</returns>
    [Description("将字节数组转换成带编码格式字符串")]
    public static String GetStringFromByteArrayByEncoding(Byte[] value, Encoding encoding) => encoding.GetString(ByteArrayLib.GetByteArrayFromByteArray(value, 0, value.Length));

    /// <summary>
    /// 根据起始地址和长度将字节数组转换成带16进制字符串
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="count">数量</param>
    /// <param name="segment">连接符</param>
    /// <returns>转换结果</returns>
    [Description("根据起始地址和长度将字节数组转换成带16进制字符串")]
    public static String GetHexStringFromByteArray(Byte[] value, Int32 start, Int32 count, String segment = " ")
    {
        var b = ByteArrayLib.GetByteArrayFromByteArray(value, start, count);

        var StringBuilder = new StringBuilder();

        foreach (var item in b)
        {
            if (segment.Length == 0)
            {
                StringBuilder.Append(String.Format("{0:X2}", item));
            }
            else
            {
                StringBuilder.Append(String.Format("{0:X2}{1}", item, segment));
            }
        }

        if (segment.Length != 0 && StringBuilder.Length > 1 && (StringBuilder.ToString()[(StringBuilder.Length - segment.Length)..] == segment))
        {
            StringBuilder.Remove(StringBuilder.Length - segment.Length, segment.Length);
        }

        return StringBuilder.ToString();
    }

    /// <summary>
    /// 将整个字节数组转换成带16进制字符串
    /// </summary>
    /// <param name="source">字节数组</param>
    /// <param name="segment">连接符</param>
    /// <returns>转换结果</returns>
    [Description("将整个字节数组转换成带16进制字符串")]
    public static String GetHexStringFromByteArray(Byte[] source, String segment = " ") => GetHexStringFromByteArray(source, 0, source.Length, segment);

    /// <summary>
    /// 将字节数组转换成西门子字符串
    /// </summary>
    /// <param name="data">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <returns>转换结果</returns>
    [Description("将字节数组转换成西门子字符串")]
    public static String GetSiemensStringFromByteArray(Byte[] data, Int32 start)
    {
        Int32 valid = data[start + 1];
        if (valid > 0)
        {
            return Encoding.GetEncoding("GBK").GetString(ByteArrayLib.GetByteArrayFromByteArray(data, start + 2, valid));
        }
        else
        {
            return String.Empty;
        }
    }

    /// <summary>
    /// 根据起始地址和长度将各种类型数组转换成字符串
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <param name="value">数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="length">长度</param>
    /// <param name="segment">连接符</param>
    /// <returns>返回结果</returns>
    [Description("根据起始地址和长度将各种类型数组转换成字符串")]
    public static String GetStringFromValueArray<T>(T[] value, Int32 start, Int32 length, String segment = " ")
    {

        if (start < 0) throw new ArgumentException("开始索引不能为负数");

        if (length <= 0) throw new ArgumentException("长度必须为正数");

        if (value.Length < (start + length)) throw new ArgumentException("字节数组长度不够或开始索引太大");

        var result = new T[length];

        Array.Copy(value, start, result, 0, length);

        return GetStringFromValueArray(result, segment);

    }

    /// <summary>
    /// 各种类型数组转换成字符串
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <param name="value">数组</param>
    /// <param name="segment">连接符</param>
    /// <returns>返回结果</returns>
    [Description("各种类型数组转换成字符串")]
    public static String GetStringFromValueArray<T>(T[] value, String segment = " ")
    {
        var StringBuilder = new StringBuilder();

        if (value.Length > 0)
        {
            foreach (var item in value)
            {
                if (segment.Length == 0)
                {
                    StringBuilder.Append(item?.ToString());
                }
                else
                {
                    StringBuilder.Append(item?.ToString() + segment.ToString());
                }
            }
        }

        if (segment.Length != 0 && StringBuilder.Length > 1 && (StringBuilder.ToString()[(StringBuilder.Length - segment.Length)..] == segment))
        {
            StringBuilder.Remove(StringBuilder.Length - segment.Length, segment.Length);
        }

        return StringBuilder.ToString();
    }

}