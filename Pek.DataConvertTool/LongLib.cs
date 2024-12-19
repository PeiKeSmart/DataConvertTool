using System.ComponentModel;

using NewLife;

namespace Pek.DataConvertTool;

/// <summary>
/// Long类型数据转换类
/// </summary>
[Description("Long类型数据转换类")]
public class LongLib
{
    /// <summary>
    /// 字节数组中截取转成64位整型
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回一个Long类型</returns>
    [Description("字节数组中截取转成64位整型")]
    public static Int64 GetLongFromByteArray(Byte[] value, Int32 start = 0, DataFormat dataFormat = DataFormat.ABCD)
    {
        var data = ByteArrayLib.Get8BytesFromByteArray(value, start, dataFormat);
        return BitConverter.ToInt64(data, 0);
    }

    /// <summary>
    /// 将字节数组中截取转成64位整型数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回Long数组</returns>
    [Description("将字节数组中截取转成64位整型数组")]
    public static Int64[] GetLongArrayFromByteArray(Byte[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        if (value == null) throw new ArgumentNullException("检查数组长度是否为空");

        if (value.Length % 8 != 0) throw new ArgumentNullException("检查数组长度是否为8的倍数");

        var values = new Int64[value.Length / 8];

        for (var i = 0; i < value.Length / 8; i++)
        {
            values[i] = GetLongFromByteArray(value, 8 * i, dataFormat);
        }
        return values;
    }

    /// <summary>
    /// 将字符串转转成64位整型数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="spilt">分隔符</param>
    /// <returns>返回Long数组</returns>
    [Description("将字符串转转成64位整型数组")]
    public static Int64[] GetLongArrayFromString(String? value, String spilt = " ")
    {
        if (value.IsNullOrWhiteSpace()) return [];

        value = value.Trim();

        var result = new List<Int64>();

        try
        {
            if (value.Contains(spilt))
            {
                var str = value.Split([spilt], StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in str)
                {
                    result.Add(Convert.ToInt64(item.Trim()));
                }
            }
            else
            {
                result.Add(Convert.ToInt64(value.Trim()));
            }

            return [.. result];
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("数据转换失败：" + ex.Message);
        }

    }
}