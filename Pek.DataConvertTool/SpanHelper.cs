namespace Pek.DataConvertTool;

public class SpanHelper
{
    /// <summary>
    /// 大端转为小端。C#数据格式默认为小端  高位在前，低位在后为大端模式
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static void ConvertBigToLitter(Span<Byte> bytes)
    {
        var length = bytes.Length;
        for (var i = 0; i < length / 2; i++)
        {
            var temp = bytes[i];
            bytes[i] = bytes[length - 1 - i];
            bytes[length - 1 - i] = temp;
        }
    }
}
