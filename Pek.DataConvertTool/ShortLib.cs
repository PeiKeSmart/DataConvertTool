using System.ComponentModel;

using NewLife;

namespace Pek.DataConvertTool;

/// <summary>
/// Short类型数据转换类
/// </summary>
[Description("Short类型数据转换类")]
public class ShortLib
{
    /// <summary>
    /// 字节数组中截取转成16位整型
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回Short结果</returns>
    [Description("字节数组中截取转成16位整型")]
    public static Int16 GetShortFromByteArray(Byte[] value, Int32 start = 0, DataFormat dataFormat = DataFormat.ABCD)
    {
        var data = ByteArrayLib.Get2BytesFromByteArray(value, start, dataFormat);
        return BitConverter.ToInt16(data, 0);
    }

    /// <summary>
    /// 将字节数组中截取转成16位整型数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="type">数据格式</param>
    /// <returns>返回Short数组</returns>
    [Description("将字节数组中截取转成16位整型数组")]
    public static Int16[] GetShortArrayFromByteArray(Byte[] value, DataFormat type = DataFormat.ABCD)
    {
        if (value == null) throw new ArgumentNullException("检查数组长度是否为空");

        if (value.Length % 2 != 0) throw new ArgumentNullException("检查数组长度是否为偶数");

        var result = new Int16[value.Length / 2];

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = GetShortFromByteArray(value, i * 2, type);
        }
        return result;
    }

    /// <summary>
    /// 将字符串转转成16位整型数组
    /// </summary>
    /// <param name="value">带转换字符串</param>
    /// <param name="spilt">分割符</param>
    /// <returns>返回Short数组</returns>
    [Description("将字符串转转成16位整型数组")]
    public static Int16[] GetShortArrayFromString(String? value, String spilt = " ")
    {
        if (value.IsNullOrWhiteSpace()) return [];

        value = value.Trim();

        var result = new List<Int16>();

        try
        {
            if (value.Contains(spilt))
            {
                var str = value.Split([spilt], StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in str)
                {
                    result.Add(Convert.ToInt16(item.Trim()));
                }
            }
            else
            {
                result.Add(Convert.ToInt16(value.Trim()));
            }

            return [.. result];
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("数据转换失败：" + ex.Message);
        }
    }

    /// <summary>
    /// 设置字节数组某个位
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="offset">某个位</param>
    /// <param name="bitVal">True或者False</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回short结果</returns>
    [Description("设置字节数组某个位")]
    public static Int16 SetBitValueFrom2ByteArray(Byte[] value, Int32 offset, Boolean bitVal, DataFormat dataFormat = DataFormat.ABCD)
    {
        if (offset >= 0 && offset <= 7)
        {
            value[1] = ByteLib.SetbitValue(value[1], offset, bitVal);
        }
        else
        {
            value[0] = ByteLib.SetbitValue(value[0], offset - 8, bitVal);
        }
        return GetShortFromByteArray(value, 0, dataFormat);
    }

    /// <summary>
    /// 设置16位整型某个位
    /// </summary>
    /// <param name="value">Short数据</param>
    /// <param name="offset">某个位</param>
    /// <param name="bitVal">True或者False</param>
    /// <param name="dataFormat">数据格式</param>
    /// <returns>返回Short结果</returns>
    [Description("设置16位整型某个位")]
    public static Int16 SetBitValueFromShort(Int16 value, Int32 offset, Boolean bitVal, DataFormat dataFormat = DataFormat.ABCD)
    {
        var data = ByteArrayLib.GetByteArrayFromShort(value, dataFormat);

        return SetBitValueFrom2ByteArray(data, offset, bitVal, dataFormat);
    }

    /// <summary>
    /// 通过布尔长度取整数
    /// </summary>
    /// <param name="boolLength">布尔长度</param>
    /// <returns>整数</returns>
    [Description("通过布尔长度取整数")]
    public static Int16 GetByteLengthFromBoolLength(Int32 boolLength) => boolLength % 8 == 0 ? (Int16)(boolLength / 8) : (Int16)(boolLength / 8 + 1);
}