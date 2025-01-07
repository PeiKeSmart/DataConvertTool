namespace Pek.DataConvertTool;

public static class SpanHelper
{
    /// <summary>
    /// 大端转为小端。C#数据格式默认为小端  高位在前，低位在后为大端模式
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static void ConvertBigToLitter(this Span<Byte> bytes)
    {
        var length = bytes.Length;
        for (var i = 0; i < length / 2; i++)
        {
            var temp = bytes[i];
            bytes[i] = bytes[length - 1 - i];
            bytes[length - 1 - i] = temp;
        }
    }

    public static String ToHex(this ReadOnlySpan<Byte> data, Int32 offset = 0, Int32 count = -1)
    {
        if (data.IsEmpty)
        {
            return "";
        }

        if (count < 0)
        {
            count = data.Length - offset;
        }
        else if (offset + count > data.Length)
        {
            count = data.Length - offset;
        }

        if (count == 0)
        {
            return "";
        }

        // 创建一个字符数组来存储结果
        var result = new Char[count * 2];
        var resultIndex = 0;

        for (var i = 0; i < count; i++)
        {
            var b = data[offset + i];
            result[resultIndex++] = GetHexValue(b >> 4);   // 高四位
            result[resultIndex++] = GetHexValue(b & 0xF); // 低四位
        }

        // 将字符数组转换为字符串
        return new String(result);
    }

    /// <summary>
    /// 将一个半字节（4 位）转换为其对应的十六进制字符的辅助方法
    /// </summary>
    /// <param name="nibble">4 位（二进制位），也就是一个字节（8 位）的半字节</param>
    /// <returns></returns>
    private static Char GetHexValue(Int32 nibble) => (Char)(nibble < 10 ? '0' + nibble : 'A' + (nibble - 10));


}
