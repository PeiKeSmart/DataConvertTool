using System.ComponentModel;

using NewLife;

namespace Pek.DataConvertTool;

/// <summary>
/// Float类型数据转换类
/// </summary>
[Description("Float类型数据转换类")]
public class FloatLib
{
    /// <summary>
    /// 将字节数组中某4个字节转换成Float类型
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回一个浮点数</returns>
    [Description("将字节数组中某4个字节转换成Float类型")]
    public static Single GetFloatFromByteArray(Byte[] value, Int32 start = 0, DataFormat dataFormat = DataFormat.ABCD)
    {
        var b = ByteArrayLib.Get4BytesFromByteArray(value, start, dataFormat);
        return BitConverter.ToSingle(b, 0);
    }

    /// <summary>
    /// 将字节数组转换成Float数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回浮点数组</returns>
    [Description("将字节数组转换成Float数组")]
    public static Single[] GetFloatArrayFromByteArray(Byte[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        if (value == null) throw new ArgumentNullException("检查数组长度是否为空");

        if (value.Length % 4 != 0) throw new ArgumentNullException("检查数组长度是否为4的倍数");

        var values = new Single[value.Length / 4];

        for (var i = 0; i < value.Length / 4; i++)
        {
            values[i] = GetFloatFromByteArray(value, 4 * i, dataFormat);
        }

        return values;
    }

    /// <summary>
    /// 将Float字符串转换成单精度浮点型数组
    /// </summary>
    /// <param name="value">Float字符串</param>
    /// <param name="spilt">分隔符</param>
    /// <returns>单精度浮点型数组</returns>
    [Description("将Float字符串转换成单精度浮点型数组")]
    public static Single[] GetFloatArrayFromString(String? value, String spilt = " ")
    {
        if (value.IsNullOrWhiteSpace()) return [];

        value = value.Trim();

        var result = new List<Single>();

        try
        {
            if (value.Contains(spilt))
            {
                var str = value.Split([spilt], StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in str)
                {
                    result.Add(Convert.ToSingle(item.Trim()));
                }
            }
            else
            {
                result.Add(Convert.ToSingle(value.Trim()));
            }
            return [.. result];
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("数据转换失败：" + ex.Message);
        }
    }
}