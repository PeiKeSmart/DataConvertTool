using System.ComponentModel;
using System.Text;

using NewLife;

namespace Pek.DataConvertTool;

/// <summary>
/// 字节数组类型数据转换类
/// </summary>
[Description("字节数组类型数据转换类")]
public class ByteArrayLib
{
    /// <summary>
    /// 根据起始地址和长度自定义截取字节数组
    /// </summary>
    /// <param name="data">字节数组</param>
    /// <param name="start">开始字节</param>
    /// <param name="length">截取长度</param>
    /// <returns>字节数组</returns>
    [Description("根据起始地址和长度自定义截取字节数组")]
    public static Byte[] GetByteArrayFromByteArray(Byte[] data, Int32 start, Int32 length)
    {
        if (start < 0) throw new ArgumentException("开始索引不能为负数");

        if (length <= 0) throw new ArgumentException("长度必须为正数");

        if (data.Length < (start + length)) throw new ArgumentException("字节数组长度不够或开始索引太大");

        var result = new Byte[length];

        Array.Copy(data, start, result, 0, length);

        return result;
    }

    /// <summary>
    /// 根据起始地址自定义截取字节数组
    /// </summary>
    /// <param name="data">字节数组</param>
    /// <param name="start">开始字节</param>
    /// <returns>字节数组</returns>
    [Description("根据起始地址自定义截取字节数组")]
    public static Byte[] GetByteArrayFromByteArray(Byte[] data, Int32 start) => GetByteArrayFromByteArray(data, start, data.Length - start);

    /// <summary>
    /// 从字节数组中截取2个字节,并按指定字节序返回
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="dataFormat">字节顺序，默认为ABCD</param>
    /// <returns>字节数组</returns> 
    [Description("从字节数组中截取2个字节,并按指定字节序返回")]
    public static Byte[] Get2BytesFromByteArray(Byte[] value, Int32 start, DataFormat dataFormat = DataFormat.ABCD)
    {
        var res = GetByteArrayFromByteArray(value, start, 2);

        switch (dataFormat)
        {
            case DataFormat.ABCD:
            case DataFormat.CDAB:
                return res.Reverse().ToArray();
            case DataFormat.BADC:
            case DataFormat.DCBA:
                return res;
            default:
                break;
        }
        return res;
    }

    /// <summary>
    /// 从字节数组中截取4个字节,并按指定字节序返回
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="dataFormat">字节顺序，默认为ABCD</param>
    /// <returns>字节数组</returns>
    [Description("从字节数组中截取4个字节,并按指定字节序返回")]
    public static Byte[] Get4BytesFromByteArray(Byte[] value, Int32 start, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = GetByteArrayFromByteArray(value, start, 4);

        var res = new Byte[4];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
                res[0] = resTemp[3];
                res[1] = resTemp[2];
                res[2] = resTemp[1];
                res[3] = resTemp[0];
                break;
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                res[2] = resTemp[3];
                res[3] = resTemp[2];
                break;
            case DataFormat.BADC:
                res[0] = resTemp[2];
                res[1] = resTemp[3];
                res[2] = resTemp[0];
                res[3] = resTemp[1];
                break;
            case DataFormat.DCBA:
                res = resTemp;
                break;
        }
        return res;
    }

    /// <summary>
    /// 从字节数组中截取8个字节,并按指定字节序返回
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="dataFormat">字节顺序，默认为ABCD</param>
    /// <returns>字节数组</returns>
    [Description("从字节数组中截取8个字节,并按指定字节序返回")]
    public static Byte[] Get8BytesFromByteArray(Byte[] value, Int32 start, DataFormat dataFormat = DataFormat.ABCD)
    {
        var res = new Byte[8];

        var resTemp = GetByteArrayFromByteArray(value, start, 8);

        if (resTemp == null) return [];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
                res[0] = resTemp[7];
                res[1] = resTemp[6];
                res[2] = resTemp[5];
                res[3] = resTemp[4];
                res[4] = resTemp[3];
                res[5] = resTemp[2];
                res[6] = resTemp[1];
                res[7] = resTemp[0];
                break;
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                res[2] = resTemp[3];
                res[3] = resTemp[2];
                res[4] = resTemp[5];
                res[5] = resTemp[4];
                res[6] = resTemp[7];
                res[7] = resTemp[6];
                break;
            case DataFormat.BADC:
                res[0] = resTemp[6];
                res[1] = resTemp[7];
                res[2] = resTemp[4];
                res[3] = resTemp[5];
                res[4] = resTemp[2];
                res[5] = resTemp[3];
                res[6] = resTemp[0];
                res[7] = resTemp[1];
                break;
            case DataFormat.DCBA:
                res = resTemp;
                break;
        }
        return res;
    }

    /// <summary>
    /// 比较两个字节数组是否完全相同
    /// </summary>
    /// <param name="value1">字节数组1</param>
    /// <param name="value2">字节数组2</param>
    /// <returns>是否相同</returns>
    [Description("比较两个字节数组是否完全相同")]
    public static Boolean GetByteArrayEquals(Byte[] value1, Byte[] value2)
    {
        if (value1 == null || value2 == null) return false;
        if (value1.Length != value2.Length) return false;
        for (var i = 0; i < value1.Length; i++)
        {
            if (value1[i] != value2[i])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 将单个字节转换成字节数组
    /// </summary>
    /// <param name="value">单个字节</param>
    /// <returns>字节数组</returns>
    [Description("将单个字节转换成字节数组")]
    public static Byte[] GetByteArrayFromByte(Byte value) => [value];

    /// <summary>
    /// 将Short类型数值转换成字节数组
    /// </summary>
    /// <param name="value">Short类型数值</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Short类型数值转换成字节数组")]
    public static Byte[] GetByteArrayFromShort(Int16 value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = BitConverter.GetBytes(value);

        var res = new Byte[2];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                break;
            case DataFormat.BADC:
            case DataFormat.DCBA:
                res = resTemp;
                break;
            default:
                break;
        }
        return res;
    }

    /// <summary>
    /// 将UShort类型数值转换成字节数组
    /// </summary>
    /// <param name="value">UShort类型数值</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将UShort类型数值转换成字节数组")]
    public static Byte[] GetByteArrayFromUShort(UInt16 value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = BitConverter.GetBytes(value);

        var res = new Byte[2];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                break;
            case DataFormat.BADC:
            case DataFormat.DCBA:
                res = resTemp;
                break;
            default:
                break;
        }
        return res;
    }

    /// <summary>
    /// 将Int类型数值转换成字节数组
    /// </summary>
    /// <param name="value">Int类型数值</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Int类型数值转换成字节数组")]
    public static Byte[] GetByteArrayFromInt(Int32 value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = BitConverter.GetBytes(value);

        var res = new Byte[4];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
                res[0] = resTemp[3];
                res[1] = resTemp[2];
                res[2] = resTemp[1];
                res[3] = resTemp[0];
                break;
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                res[2] = resTemp[3];
                res[3] = resTemp[2];
                break;
            case DataFormat.BADC:
                res[0] = resTemp[2];
                res[1] = resTemp[3];
                res[2] = resTemp[0];
                res[3] = resTemp[1];
                break;
            case DataFormat.DCBA:
                res = resTemp;
                break;
        }
        return res;
    }

    /// <summary>
    /// 将UInt类型数值转换成字节数组
    /// </summary>
    /// <param name="value">UInt类型数值</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将UInt类型数值转换成字节数组")]
    public static Byte[] GetByteArrayFromUInt(UInt32 value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = BitConverter.GetBytes(value);

        var res = new Byte[4];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
                res[0] = resTemp[3];
                res[1] = resTemp[2];
                res[2] = resTemp[1];
                res[3] = resTemp[0];
                break;
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                res[2] = resTemp[3];
                res[3] = resTemp[2];
                break;
            case DataFormat.BADC:
                res[0] = resTemp[2];
                res[1] = resTemp[3];
                res[2] = resTemp[0];
                res[3] = resTemp[1];
                break;
            case DataFormat.DCBA:
                res = resTemp;
                break;
        }
        return res;
    }

    /// <summary>
    /// 将Float数值转换成字节数组
    /// </summary>
    /// <param name="value">Float类型数值</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Float数值转换成字节数组")]
    public static Byte[] GetByteArrayFromFloat(Single value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = BitConverter.GetBytes(value);

        var res = new Byte[4];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
                res[0] = resTemp[3];
                res[1] = resTemp[2];
                res[2] = resTemp[1];
                res[3] = resTemp[0];
                break;
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                res[2] = resTemp[3];
                res[3] = resTemp[2];
                break;
            case DataFormat.BADC:
                res[0] = resTemp[2];
                res[1] = resTemp[3];
                res[2] = resTemp[0];
                res[3] = resTemp[1];
                break;
            case DataFormat.DCBA:
                res = resTemp;
                break;
        }
        return res;
    }

    /// <summary>
    /// 将Double类型数值转换成字节数组
    /// </summary>
    /// <param name="value">Double类型数值</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Double类型数值转换成字节数组")]
    public static Byte[] GetByteArrayFromDouble(Double value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = BitConverter.GetBytes(value);

        var res = new Byte[8];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
                res[0] = resTemp[7];
                res[1] = resTemp[6];
                res[2] = resTemp[5];
                res[3] = resTemp[4];
                res[4] = resTemp[3];
                res[5] = resTemp[2];
                res[6] = resTemp[1];
                res[7] = resTemp[0];
                break;
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                res[2] = resTemp[3];
                res[3] = resTemp[2];
                res[4] = resTemp[5];
                res[5] = resTemp[4];
                res[6] = resTemp[7];
                res[7] = resTemp[6];
                break;
            case DataFormat.BADC:
                res[0] = resTemp[6];
                res[1] = resTemp[7];
                res[2] = resTemp[4];
                res[3] = resTemp[5];
                res[4] = resTemp[2];
                res[5] = resTemp[3];
                res[6] = resTemp[0];
                res[7] = resTemp[1];
                break;
            case DataFormat.DCBA:
                res = resTemp;
                break;
        }
        return res;
    }

    /// <summary>
    /// 将Long类型数值转换成字节数组
    /// </summary>
    /// <param name="value">Long类型数值</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Long类型数值转换成字节数组")]
    public static Byte[] GetByteArrayFromLong(Int64 value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = BitConverter.GetBytes(value);

        var res = new Byte[8];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
                res[0] = resTemp[7];
                res[1] = resTemp[6];
                res[2] = resTemp[5];
                res[3] = resTemp[4];
                res[4] = resTemp[3];
                res[5] = resTemp[2];
                res[6] = resTemp[1];
                res[7] = resTemp[0];
                break;
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                res[2] = resTemp[3];
                res[3] = resTemp[2];
                res[4] = resTemp[5];
                res[5] = resTemp[4];
                res[6] = resTemp[7];
                res[7] = resTemp[6];
                break;
            case DataFormat.BADC:
                res[0] = resTemp[6];
                res[1] = resTemp[7];
                res[2] = resTemp[4];
                res[3] = resTemp[5];
                res[4] = resTemp[2];
                res[5] = resTemp[3];
                res[6] = resTemp[0];
                res[7] = resTemp[1];
                break;
            case DataFormat.DCBA:
                res = resTemp;
                break;
        }
        return res;
    }

    /// <summary>
    /// 将ULong类型数值转换成字节数组
    /// </summary>
    /// <param name="value">ULong类型数值</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将ULong类型数值转换成字节数组")]
    public static Byte[] GetByteArrayFromULong(UInt64 value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var resTemp = BitConverter.GetBytes(value);

        var res = new Byte[8];

        switch (dataFormat)
        {
            case DataFormat.ABCD:
                res[0] = resTemp[7];
                res[1] = resTemp[6];
                res[2] = resTemp[5];
                res[3] = resTemp[4];
                res[4] = resTemp[3];
                res[5] = resTemp[2];
                res[6] = resTemp[1];
                res[7] = resTemp[0];
                break;
            case DataFormat.CDAB:
                res[0] = resTemp[1];
                res[1] = resTemp[0];
                res[2] = resTemp[3];
                res[3] = resTemp[2];
                res[4] = resTemp[5];
                res[5] = resTemp[4];
                res[6] = resTemp[7];
                res[7] = resTemp[6];
                break;
            case DataFormat.BADC:
                res[0] = resTemp[6];
                res[1] = resTemp[7];
                res[2] = resTemp[4];
                res[3] = resTemp[5];
                res[4] = resTemp[2];
                res[5] = resTemp[3];
                res[6] = resTemp[0];
                res[7] = resTemp[1];
                break;
            case DataFormat.DCBA:
                res = resTemp;
                break;
        }
        return res;
    }

    /// <summary>
    /// 将Short数组转换成字节数组
    /// </summary>
    /// <param name="value">Short数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Short数组转换成字节数组")]
    public static Byte[] GetByteArrayFromShortArray(Int16[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var array = new ByteArray();

        foreach (var item in value)
        {
            array.Add(GetByteArrayFromShort(item, dataFormat));
        }
        return array.Array;
    }

    /// <summary>
    /// 将UShort数组转换成字节数组
    /// </summary>
    /// <param name="value">UShort数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将UShort数组转换成字节数组")]
    public static Byte[] GetByteArrayFromUShortArray(UInt16[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var array = new ByteArray();

        foreach (var item in value)
        {
            array.Add(GetByteArrayFromUShort(item, dataFormat));
        }
        return array.Array;
    }

    /// <summary>
    /// 将Int类型数组转换成字节数组
    /// </summary>
    /// <param name="value">Int类型数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Int类型数组转换成字节数组")]
    public static Byte[] GetByteArrayFromIntArray(Int32[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var array = new ByteArray();

        foreach (var item in value)
        {
            array.Add(GetByteArrayFromInt(item, dataFormat));
        }
        return array.Array;
    }

    /// <summary>
    /// 将UInt类型数组转换成字节数组
    /// </summary>
    /// <param name="value">UInt类型数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将UInt类型数组转换成字节数组")]
    public static Byte[] GetByteArrayFromUIntArray(UInt32[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var array = new ByteArray();

        foreach (var item in value)
        {
            array.Add(GetByteArrayFromUInt(item, dataFormat));
        }
        return array.Array;
    }

    /// <summary>
    /// 将Float类型数组转成字节数组
    /// </summary>
    /// <param name="value">Float类型数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Float类型数组转成字节数组")]
    public static Byte[] GetByteArrayFromFloatArray(Single[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var array = new ByteArray();

        foreach (var item in value)
        {
            array.Add(GetByteArrayFromFloat(item, dataFormat));
        }
        return array.Array;
    }

    /// <summary>
    /// 将Double类型数组转成字节数组
    /// </summary>
    /// <param name="value">Double类型数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Double类型数组转成字节数组")]
    public static Byte[] GetByteArrayFromDoubleArray(Double[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var array = new ByteArray();

        foreach (var item in value)
        {
            array.Add(GetByteArrayFromDouble(item, dataFormat));
        }
        return array.Array;
    }

    /// <summary>
    /// 将Long类型数组转换成字节数组
    /// </summary>
    /// <param name="value">Long类型数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将Long类型数组转换成字节数组")]
    public static Byte[] GetByteArrayFromLongArray(Int64[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var array = new ByteArray();

        foreach (var item in value)
        {
            array.Add(GetByteArrayFromLong(item, dataFormat));
        }
        return array.Array;
    }

    /// <summary>
    /// 将ULong类型数组转换成字节数组
    /// </summary>
    /// <param name="value">ULong类型数组</param>
    /// <param name="dataFormat">字节顺序</param>
    /// <returns>字节数组</returns>
    [Description("将ULong类型数组转换成字节数组")]
    public static Byte[] GetByteArrayFromULongArray(UInt64[] value, DataFormat dataFormat = DataFormat.ABCD)
    {
        var array = new ByteArray();

        foreach (var item in value)
        {
            array.Add(GetByteArrayFromULong(item, dataFormat));
        }
        return array.Array;
    }

    /// <summary>
    /// 将指定编码格式的字符串转换成字节数组
    /// </summary>
    /// <param name="value">字符串</param>
    /// <param name="encoding">编码格式</param>
    /// <returns>字节数组</returns>
    [Description("将指定编码格式的字符串转换成字节数组")]
    public static Byte[] GetByteArrayFromString(String value, Encoding encoding) => encoding.GetBytes(value);

    /// <summary>
    /// 将16进制字符串按照空格分隔成字节数组
    /// </summary>
    /// <param name="value">16进制字符串</param>
    /// <param name="spilt">分隔符</param>
    /// <returns>字节数组</returns>
    [Description("将16进制字符串按照空格分隔成字节数组")]
    public static Byte[] GetByteArrayFromHexString(String? value, String spilt = " ")
    {
        if (value.IsNullOrWhiteSpace()) return [];

        value = value.Trim();//去除空格

        var result = new List<Byte>();

        try
        {
            if (value.Contains(spilt))
            {
                var str = value.Split([spilt], StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in str)
                {
                    result.Add(Convert.ToByte(item.Trim(), 16));
                }
            }
            else
            {
                result.Add(Convert.ToByte(value.Trim(), 16));
            }
            return [.. result];
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("数据转换失败：" + ex.Message);
        }
    }

    /// <summary>
    /// 将16进制字符串不用分隔符转换成字节数组（每2个字符为1个字节）
    /// </summary>
    /// <param name="value">16进制字符串</param>
    /// <returns>字节数组</returns>
    [Description("将16进制字符串不用分隔符转换成字节数组（每2个字符为1个字节）")]
    public static Byte[] GetByteArrayFromHexStringWithoutSpilt(String value)
    {
        if (value.Length % 2 != 0) throw new ArgumentNullException("检查字符串长度是否为偶数");

        var result = new List<Byte>();
        try
        {
            for (var i = 0; i < value.Length; i += 2)
            {
                var temp = value.Substring(i, 2);

                result.Add(Convert.ToByte(temp, 16));
            }
            return [.. result];
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("数据转换失败：" + ex.Message);
        }
    }

    /// <summary>
    /// 将byte数据转换成一个Asii格式字节数组
    /// </summary>
    /// <param name="value">byte数据</param>
    /// <returns>字节数组</returns>
    [Description("将byte数据转换成一个Asii格式字节数组")]
    public static Byte[] GetAsciiByteArrayFromValue(Byte value) => Encoding.ASCII.GetBytes(value.ToString("X2"));

    /// <summary>
    /// 将short数据转换成一个Ascii格式字节数组
    /// </summary>
    /// <param name="value">short数据</param>
    /// <returns>字节数组</returns>
    [Description("将short数据转换成一个Ascii格式字节数组")]
    public static Byte[] GetAsciiByteArrayFromValue(Int16 value) => Encoding.ASCII.GetBytes(value.ToString("X4"));

    /// <summary>
    /// 将ushort数据转换成一个Ascii格式字节数组
    /// </summary>
    /// <param name="value">ushort数据</param>
    /// <returns>字节数组</returns>
    [Description("将ushort数据转换成一个Ascii格式字节数组")]
    public static Byte[] GetAsciiByteArrayFromValue(UInt16 value) => Encoding.ASCII.GetBytes(value.ToString("X4"));

    /// <summary>
    /// 将String数据转换成一个Ascii格式字节数组
    /// </summary>
    /// <param name="value">String数据</param>
    /// <returns>字节数组</returns>
    [Description("将String数据转换成一个Ascii格式字节数组")]
    public static Byte[] GetAsciiByteArrayFromValue(String value) => Encoding.ASCII.GetBytes(value);

    /// <summary>
    /// 将布尔数组转换成字节数组
    /// </summary>
    /// <param name="data">布尔数组</param>
    /// <returns>字节数组</returns>
    [Description("将布尔数组转换成字节数组")]
    public static Byte[] GetByteArrayFromBoolArray(Boolean[] data)
    {
        if (data == null || data.Length == 0) throw new ArgumentNullException("检查数组长度是否正确"); ;

        var result = new Byte[data.Length % 8 != 0 ? data.Length / 8 + 1 : data.Length / 8];

        //遍历每个字节
        for (var i = 0; i < result.Length; i++)
        {
            var total = data.Length < 8 * (i + 1) ? data.Length - 8 * i : 8;

            //遍历当前字节的每个位赋值
            for (var j = 0; j < total; j++)
            {
                result[i] = ByteLib.SetbitValue(result[i], j, data[8 * i + j]);
            }
        }
        return result;
    }

    /// <summary>
    /// 将西门子字符串转换成字节数组
    /// </summary>
    /// <param name="value">西门子字符串</param>
    /// <returns>字节数组</returns>
    [Description("将西门子字符串转换成字节数组")]
    public static Byte[] GetByteArrayFromSiemensString(String value)
    {
        var data = GetByteArrayFromString(value, Encoding.GetEncoding("GBK"));
        var result = new Byte[data.Length + 2];
        result[0] = (Byte)(data.Length + 2);
        result[1] = (Byte)data.Length;
        Array.Copy(data, 0, result, 2, data.Length);
        return result;
    }

    /// <summary>
    /// 将欧姆龙CIP字符串转换成字节数组
    /// </summary>
    /// <param name="data">西门子字符串</param>
    /// <returns>字节数组</returns>
    [Description("将欧姆龙CIP字符串转换成字节数组")]
    public static Byte[] GetByteArrayFromOmronCIPString(String data)
    {
        var b = GetByteArrayFromString(data, Encoding.ASCII);

        var res = GetEvenByteArray(b);

        var array = new Byte[res.Length + 2];
        array[0] = BitConverter.GetBytes(array.Length - 2)[0];
        array[1] = BitConverter.GetBytes(array.Length - 2)[1];
        Array.Copy(res, 0, array, 2, res.Length);
        return array;
    }

    /// <summary>
    /// 扩展为偶数长度字节数组
    /// </summary>
    /// <param name="data">原始字节数据</param>
    /// <returns>返回字节数组</returns>
    [Description("扩展为偶数长度字节数组")]
    public static Byte[] GetEvenByteArray(Byte[] data)
    {
        if (data == null) return [];

        if (data.Length % 2 != 0)
            return GetFixedLengthByteArray(data, data.Length + 1);
        else
            return data;
    }

    /// <summary>
    /// 扩展或压缩字节数组到指定数量
    /// </summary>
    /// <param name="data">原始字节数据</param>
    /// <param name="length">指定长度</param>
    /// <returns>返回字节数组</returns>
    [Description("扩展或压缩字节数组到指定数量")]
    public static Byte[] GetFixedLengthByteArray(Byte[] data, Int32 length)
    {
        if (data == null) return new Byte[length];

        if (data.Length == length) return data;

        var buffer = new Byte[length];

        Array.Copy(data, buffer, Math.Min(data.Length, buffer.Length));

        return buffer;
    }


    /// <summary>
    /// 将字节数组转换成Ascii字节数组
    /// </summary>
    /// <param name="value">字节数组</param>
    /// <param name="segment">分隔符</param>
    /// <returns>ASCII字节数组</returns>
    [Description("将字节数组转换成Ascii字节数组")]
    public static Byte[] GetAsciiBytesFromByteArray(Byte[] value, String segment = "") => Encoding.ASCII.GetBytes(StringLib.GetHexStringFromByteArray(value, segment));


    /// <summary>
    /// 将Ascii字节数组转换成字节数组
    /// </summary>
    /// <param name="value">ASCII字节数组</param>
    /// <returns>字节数组</returns>
    [Description("将Ascii字节数组转换成字节数组")]
    public static Byte[] GetBytesArrayFromAsciiByteArray(Byte[] value) => GetByteArrayFromHexStringWithoutSpilt(Encoding.ASCII.GetString(value));

    /// <summary>
    /// 将2个字节数组进行合并
    /// </summary>
    /// <param name="bytes1">字节数组1</param>
    /// <param name="bytes2">字节数组2</param>
    /// <returns>返回字节数组</returns>
    [Description("将2个字节数组进行合并")]
    public static Byte[] GetByteArrayFromTwoByteArray(Byte[] bytes1, Byte[] bytes2)
    {
        if (bytes1 == null && bytes2 == null) return [];
        if (bytes1 == null) return bytes2;
        if (bytes2 == null) return bytes1;

        var buffer = new Byte[bytes1.Length + bytes2.Length];
        bytes1.CopyTo(buffer, 0);
        bytes2.CopyTo(buffer, bytes1.Length);
        return buffer;
    }

    /// <summary>
    /// 将3个字节数组进行合并
    /// </summary>
    /// <param name="bytes1">字节数组1</param>
    /// <param name="bytes2">字节数组2</param>
    /// <param name="bytes3">字节数组3</param>
    /// <returns>返回字节数组</returns>
    [Description("将3个字节数组进行合并")]
    public static Byte[] GetByteArrayFromThreeByteArray(Byte[] bytes1, Byte[] bytes2, Byte[] bytes3) => GetByteArrayFromTwoByteArray(GetByteArrayFromTwoByteArray(bytes1, bytes2), bytes3);

    /// <summary>
    /// 将字节数组中的某个数据修改
    /// </summary>
    /// <param name="sourceArray">字节数组</param>
    /// <param name="value">数据，确定好类型</param>
    /// <param name="start">开始索引</param>
    /// <param name="offset">偏移，布尔及字符串才起作用</param>
    /// <returns>返回字节数组</returns>
    [Description("将字节数组中的某个数据修改")]
    public static Byte[] SetByteArray(Byte[] sourceArray, Object value, Int32 start, Int32 offset)
    {
        var name = value.GetType().Name;
        Byte[]? b;
        switch (name.ToLower())
        {
            case "boolean":
                Array.Copy(GetByteArrayFromByte(ByteLib.SetbitValue(sourceArray[start], offset, Convert.ToBoolean(value))), 0, sourceArray, start, 1);
                break;
            case "byte":
                Array.Copy(GetByteArrayFromByte(Convert.ToByte(value)), 0, sourceArray, start, 1);
                break;
            case "int16":
                Array.Copy(GetByteArrayFromShort(Convert.ToInt16(value)), 0, sourceArray, start, 2);
                break;
            case "uint16":
                Array.Copy(GetByteArrayFromUShort(Convert.ToUInt16(value)), 0, sourceArray, start, 2);
                break;
            case "int32":
                Array.Copy(GetByteArrayFromInt(Convert.ToInt32(value)), 0, sourceArray, start, 4);
                break;
            case "uint32":
                Array.Copy(GetByteArrayFromUInt(Convert.ToUInt32(value)), 0, sourceArray, start, 4);
                break;
            case "single":
                Array.Copy(GetByteArrayFromFloat(Convert.ToSingle(value)), 0, sourceArray, start, 4);
                break;
            case "double":
                Array.Copy(GetByteArrayFromDouble(Convert.ToDouble(value)), 0, sourceArray, start, 8);
                break;
            case "int64":
                Array.Copy(GetByteArrayFromLong(Convert.ToInt64(value)), 0, sourceArray, start, 8);
                break;
            case "uint64":
                Array.Copy(GetByteArrayFromULong(Convert.ToUInt64(value)), 0, sourceArray, start, 8);
                break;
            case "byte[]":
                b = GetByteArrayFromHexString(value.ToString());
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            case "int16[]":
                b = GetByteArrayFromShortArray(ShortLib.GetShortArrayFromString(value.ToString()));
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            case "uint16[]":
                b = GetByteArrayFromUShortArray(UShortLib.GetUShortArrayFromString(value.ToString()));
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            case "int32[]":
                b = GetByteArrayFromIntArray(IntLib.GetIntArrayFromString(value.ToString()));
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            case "uint32[]":
                b = GetByteArrayFromUIntArray(UIntLib.GetUIntArrayFromString(value.ToString()));
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            case "single[]":
                b = GetByteArrayFromFloatArray(FloatLib.GetFloatArrayFromString(value.ToString()));
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            case "double[]":
                b = GetByteArrayFromDoubleArray(DoubleLib.GetDoubleArrayFromString(value.ToString()));
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            case "int64[]":
                b = GetByteArrayFromLongArray(LongLib.GetLongArrayFromString(value.ToString()));
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            case "uint64[]":
                b = GetByteArrayFromULongArray(ULongLib.GetULongArrayFromString(value.ToString()));
                Array.Copy(b, 0, sourceArray, start, b.Length);
                break;
            default:
                break;
        }

        return sourceArray;

    }
}