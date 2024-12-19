using System.Collections;
using System.ComponentModel;

namespace Pek.DataConvertTool;

/// <summary>
/// Bit类型数据转换类
/// </summary>
[Description("Bit类型数据转换类")]
public class BitLib
{
    /// <summary>
    /// 返回某个字节的指定位
    /// </summary>
    /// <param name="value">字节</param>
    /// <param name="offset">偏移位</param>
    /// <remarks>偏移位0-7有效，否则结果不正确</remarks>
    /// <returns>布尔结果</returns>
    [Description("返回某个字节的指定位")]
    public static Boolean GetBitFromByte(Byte value, Int32 offset) => (value & (1 << offset)) != 0;//return (data & (byte)Math.Pow(2, offset)) != 0;

    /// <summary>
    /// 获取字节数组(长度为2)中的指定位
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="offset">偏移位</param>
    /// <param name="isLittleEndian">大小端</param>
    /// <remarks>偏移位0-15有效，否则结果不正确</remarks>
    /// <returns>布尔结果</returns>
    [Description("获取字节数组(长度为2)中的指定位")]
    public static Boolean GetBitFrom2Bytes(Byte[] value, Int32 offset, Boolean isLittleEndian = true)
    {
        if (value.Length < 2) throw new ArgumentException("数组长度小于2");

        if (isLittleEndian)
        {
            return GetBitFrom2Bytes(value[1], value[0], offset);
        }
        else
        {
            return GetBitFrom2Bytes(value[0], value[1], offset);
        }
    }

    /// <summary>
    /// 获取高低字节的指定位
    /// </summary>
    /// <param name="high">高位字节</param>
    /// <param name="low">低位字节</param>
    /// <param name="offset">偏移位</param>
    /// <remarks>偏移位0-15有效，否则结果不正确</remarks>
    /// <returns>布尔结果</returns>
    [Description("获取高低字节的指定位")]
    public static Boolean GetBitFrom2Bytes(Byte high, Byte low, Int32 offset)
    {
        if (offset >= 0 && offset <= 7)
        {
            return GetBitFromByte(low, offset);
        }
        else
        {
            return GetBitFromByte(high, offset - 8);
        }
    }

    /// <summary>
    /// 返回字节数组中某个字节的指定位
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">字节索引</param>
    /// <param name="offset">偏移位</param>
    /// <remarks>偏移位0-7有效，否则结果不正确</remarks> 
    /// <returns>布尔结果</returns>
    [Description("返回字节数组中某个字节的指定位")]
    public static Boolean GetBitFromByteArray(Byte[] value, Int32 start, Int32 offset)
    {
        if (start > value.Length - 1) throw new ArgumentException("数组长度不够或开始索引太大");

        return GetBitFromByte(value[start], offset);
    }

    /// <summary>
    /// 返回字节数组中某2个字节的指定位
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">字节索引</param>
    /// <param name="offset">偏移位</param>
    /// <param name="isLittleEndian">大小端</param>
    /// <remarks>偏移位0-15有效，否则结果不正确</remarks> 
    /// <returns>布尔结果</returns>
    [Description("返回字节数组中某2个字节的指定位")]
    public static Boolean GetBitFrom2BytesArray(Byte[] value, Int32 start, Int32 offset, Boolean isLittleEndian = true)
    {
        if (start > value.Length - 2) throw new ArgumentException("数组长度不够或开始索引太大");

        var array = new Byte[] { value[start], value[start + 1] };

        return GetBitFrom2Bytes(array, offset, isLittleEndian);
    }

    /// <summary>
    /// 根据一个Short返回指定位
    /// </summary>
    /// <param name="value">short数值</param>
    /// <param name="offset">偏移位</param>
    /// <param name="isLittleEndian">大小端</param>
    /// <remarks>偏移位0-15有效，否则结果不正确</remarks>
    /// <returns>布尔结果</returns>
    [Description("根据一个Short返回指定位")]
    public static Boolean GetBitFromShort(Int16 value, Int32 offset, Boolean isLittleEndian = true) => GetBitFrom2Bytes(BitConverter.GetBytes(value), offset, !isLittleEndian);

    /// <summary>
    /// 根据一个UShort返回指定位
    /// </summary>
    /// <param name="value">short数值</param>
    /// <param name="offset">偏移位</param>
    /// <param name="isLittleEndian">大小端</param>
    /// <remarks>偏移位0-15有效，否则结果不正确</remarks>
    /// <returns>布尔结果</returns>
    [Description("根据一个UShort返回指定位")]
    public static Boolean GetBitFromUShort(UInt16 value, Int32 offset, Boolean isLittleEndian = true) => GetBitFrom2Bytes(BitConverter.GetBytes(value), offset, !isLittleEndian);

    /// <summary>
    /// 将字节数组转换成布尔数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="length">布尔数组长度</param>
    /// <returns>布尔数组</returns>
    [Description("将字节数组转换成布尔数组")]
    public static Boolean[] GetBitArrayFromByteArray(Byte[] value, Int32 length) => GetBitArrayFromByteArray(value, 0, length);

    /// <summary>
    /// 将字节数组转换成布尔数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="length">布尔数组长度</param>
    /// <returns>布尔数组</returns>
    [Description("将字节数组转换成布尔数组")]
    public static Boolean[] GetBitArrayFromByteArray(Byte[] value, Int32 start, Int32 length)
    {
        if (length <= 0) throw new ArgumentException("长度必须为正数");

        if (start < 0) throw new ArgumentException("开始索引必须为非负数");

        if (start + length > value.Length * 8) throw new ArgumentException("数组长度不够或长度太大");

        var bitArr = new BitArray(value);

        var bools = new Boolean[length];

        for (var i = 0; i < length; i++)
        {
            bools[i] = bitArr[i + start];
        }
        return bools;
    }

    /// <summary>
    /// 将字节数组转换成布尔数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <returns>布尔数组</returns>
    [Description("将字节数组转换成布尔数组")]
    public static Boolean[] GetBitArrayFromByteArray(Byte[] value) => GetBitArrayFromByteArray(value, value.Length * 8);

    /// <summary>
    /// 将一个字节转换成布尔数组
    /// </summary>
    /// <param name="value">字节</param>
    /// <returns>布尔数组</returns>
    [Description("将一个字节转换成布尔数组")]
    public static Boolean[] GetBitArrayFromByte(Byte value) => GetBitArrayFromByteArray([value]);

    /// <summary>
    /// 根据位开始和长度截取布尔数组
    /// </summary>
    /// <param name="value">布尔数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="length">长度</param>
    /// <returns>返回布尔数组</returns>
    [Description("根据位开始和长度截取布尔数组")]
    public static Boolean[] GetBitArrayFromBitArray(Boolean[] value, Int32 start, Int32 length)
    {
        if (start < 0) throw new ArgumentException("开始索引不能为负数");

        if (length <= 0) throw new ArgumentException("长度必须为正数");

        if (value.Length < (start + length)) throw new ArgumentException("数组长度不够或开始索引太大");

        var result = new Boolean[length];

        Array.Copy(value, start, result, 0, length);

        return result;
    }

    /// <summary>
    /// 从布尔数组中截取某个布尔
    /// </summary>
    /// <param name="value">布尔数组</param>
    /// <param name="start">开始索引</param>
    /// <returns>返回布尔</returns>
    [Description("从布尔数组中截取某个布尔")]
    public static Boolean GetBitFromBitArray(Boolean[] value, Int32 start)
    {
        if (start > value.Length - 1) throw new ArgumentException("布尔数组长度不够或开始索引太大");

        return value[start];
    }


    /// <summary>
    /// 将字符串按照指定的分隔符转换成布尔数组
    /// </summary>
    /// <param name="value">待转换字符串</param>
    /// <param name="spilt">分割符</param>
    /// <returns>返回布尔数组</returns>
    [Description("将字符串按照指定的分隔符转换成布尔数组")]
    public static Boolean[] GetBitArrayFromBitArrayString(String value, String spilt = " ")
    {
        value = value.Trim();

        var result = new List<Boolean>();

        if (value.Contains(spilt))
        {
            var Strings = value.Split([spilt], StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in Strings)
            {
                result.Add(IsBoolean(item));
            }
        }
        else
        {
            result.Add(IsBoolean(value));
        }

        return result.ToArray();
    }

    /// <summary>
    /// 判断是否为布尔
    /// </summary>
    /// <param name="value">布尔字符串</param>
    /// <returns>布尔结果</returns>
    [Description("判断是否为布尔")]
    public static Boolean IsBoolean(String value) => value == "1" || value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
}