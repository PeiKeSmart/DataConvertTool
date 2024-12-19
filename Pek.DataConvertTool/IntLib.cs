using System.ComponentModel;

using NewLife;

namespace Pek.DataConvertTool;

/// <summary>
/// Int类型数据转换类
/// </summary>
[Description("Int类型数据转换类")]
public class IntLib
{
    /// <summary>
    /// 字节数组中截取转成32位整型
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回int类型</returns>
    [Description("字节数组中截取转成32位整型")]
    public static Int32 GetIntFromByteArray(Byte[] value, Int32 start = 0, DataFormat dataFormat = DataFormat.ABCD)
    {
        var data = ByteArrayLib.Get4BytesFromByteArray(value, start, dataFormat);
        return BitConverter.ToInt32(data, 0);
    }

    /// <summary>
    /// 将字节数组中截取转成32位整型数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回int数组</returns>
    [Description("将字节数组中截取转成32位整型数组")]
    public static Int32[] GetIntArrayFromByteArray(Byte[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        if (value == null) throw new ArgumentNullException("检查数组长度是否为空");

        if (value.Length % 4 != 0) throw new ArgumentNullException("检查数组长度是否为4的倍数");

        var values = new Int32[value.Length / 4];

        for (var i = 0; i < value.Length / 4; i++)
        {
            values[i] = GetIntFromByteArray(value, 4 * i, dataFormat);
        }

        return values;
    }

    /// <summary>
    /// 将字符串转转成32位整型数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="spilt">分隔符</param>
    /// <returns>返回int数组</returns>
    [Description("将字符串转转成32位整型数组")]
    public static Int32[] GetIntArrayFromString(String? value, String spilt = " ")
    {
        if (value.IsNullOrWhiteSpace()) return [];

        value = value.Trim();

        var result = new List<Int32>();

        try
        {
            if (value.Contains(spilt))
            {
                var str = value.Split([spilt], StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in str)
                {
                    result.Add(Convert.ToInt32(item.Trim()));
                }
            }
            else
            {
                result.Add(Convert.ToInt32(value.Trim()));
            }

            return [.. result];
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("数据转换失败：" + ex.Message);
        }
    }

    /// <summary>
    /// 通过布尔长度取整数
    /// </summary>
    /// <param name="boolLength">布尔长度</param>
    /// <returns>整数</returns>
    [Description("通过布尔长度取整数")]
    public static Int32 GetByteLengthFromBoolLength(Int32 boolLength) => boolLength % 8 == 0 ? boolLength / 8 : boolLength / 8 + 1;
}