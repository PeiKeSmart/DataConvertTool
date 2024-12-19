using System.ComponentModel;

namespace Pek.DataConvertTool;

/// <summary>
/// 非常好用的字节集合类
/// </summary>
[Description("非常好用的字节集合类")]
public class ByteArray
{

    #region 初始化

    private List<Byte> list = [];

    /// <summary>
    /// 通过索引获取值
    /// </summary>
    /// <param name="index">索引</param>
    /// <returns>返回字节</returns>
    public Byte this[Int32 index]
    {
        get => list[index];
        set => list[index] = value;
    }

    /// <summary>
    /// 返回长度
    /// </summary>
    public Int32 Length => list.Count;

    #endregion

    #region 获取字节数组

    /// <summary>
    /// 属性，返回字节数组
    /// </summary>
    public Byte[] Array => [.. list];
    #endregion

    #region 相关方法
    /// <summary>
    /// 清空字节数组
    /// </summary>
    [Description("清空字节数组")]
    public void Clear() => list = [];


    /// <summary>
    /// 添加可变字节数组
    /// </summary>
    /// <param name="items">字节数组</param>
    [Description("添加可变字节数组")]
    public void Add(params Byte[] items) => list.AddRange(items);

    /// <summary>
    /// 添加一个ByteArray对象
    /// </summary>
    /// <param name="byteArray">ByteArray对象</param>
    [Description("添加一个ByteArray对象")]
    public void Add(ByteArray byteArray) => Add(byteArray.Array);

    /// <summary>
    /// 添加一个ushort类型数值
    /// </summary>
    /// <param name="value">ushort类型数值</param>
    [Description("添加一个ushort类型数值")]
    public void Add(UInt16 value)
    {
        list.Add((Byte)(value >> 8));
        list.Add((Byte)value);
    }

    /// <summary>
    /// 添加一个short类型数值
    /// </summary>
    /// <param name="value">short类型数值</param>
    [Description("添加一个short类型数值")]
    public void Add(Int16 value)
    {
        list.Add((Byte)(value >> 8));
        list.Add((Byte)value);
    }

    #endregion

}