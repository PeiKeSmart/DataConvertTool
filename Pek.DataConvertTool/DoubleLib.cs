using System.ComponentModel;

using NewLife;

namespace Pek.DataConvertTool;

/// <summary>
/// Double类型数据转换类
/// </summary>
[Description("Double类型数据转换类")]
public class DoubleLib
{
    /// <summary>
    /// 将字节数组中某8个字节转换成Double类型
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始位置</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>Double类型数值</returns>
    [Description("将字节数组中某8个字节转换成Double类型")]
    public static Double GetDoubleFromByteArray(Byte[] value, Int32 start = 0, DataFormat dataFormat = DataFormat.ABCD)
    {
        var data = ByteArrayLib.Get8BytesFromByteArray(value, start, dataFormat);
        return BitConverter.ToDouble(data, 0);
    }

    /// <summary>
    /// 将字节数组转换成Double数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>Double数组</returns>
    [Description("将字节数组转换成Double数组")]
    public static Double[] GetDoubleArrayFromByteArray(Byte[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        if (value == null) throw new ArgumentNullException("检查数组长度是否为空");

        if (value.Length % 8 != 0) throw new ArgumentNullException("检查数组长度是否为8的倍数");

        var values = new Double[value.Length / 8];

        for (var i = 0; i < value.Length / 8; i++)
        {
            values[i] = GetDoubleFromByteArray(value, 8 * i, dataFormat);
        }

        return values;
    }

    /// <summary>
    /// 将Double字符串转换成双精度浮点型数组
    /// </summary>
    /// <param name="value">Double字符串</param>
    /// <param name="spilt">分割符</param>
    /// <returns>双精度浮点型数组</returns>
    [Description("将Double字符串转换成双精度浮点型数组")]
    public static Double[] GetDoubleArrayFromString(String? value, String spilt = " ")
    {
        if (value.IsNullOrWhiteSpace()) return [];

        value = value.Trim();

        var result = new List<Double>();

        try
        {
            if (value.Contains(spilt))
            {
                var str = value.Split([spilt], StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in str)
                {
                    result.Add(Convert.ToDouble(item.Trim()));
                }
            }
            else
            {
                result.Add(Convert.ToDouble(value.Trim()));
            }

            return [.. result];
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("数据转换失败：" + ex.Message);
        }
    }
}