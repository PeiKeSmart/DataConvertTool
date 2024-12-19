using System.ComponentModel;

namespace Pek.DataConvertTool;

/// <summary>
/// 数值线性转换类
/// </summary>
[Description("数值线性转换类")]
public class MigrationLib
{
    private static readonly String ByteMax = Byte.MaxValue.ToString();
    private static readonly String ByteMin = Byte.MinValue.ToString();

    private static readonly String ShortMax = Int16.MaxValue.ToString();
    private static readonly String ShortMin = Int16.MinValue.ToString();

    private static readonly String UShortMax = UInt16.MaxValue.ToString();
    private static readonly String UShortMin = UInt16.MinValue.ToString();

    private static readonly String IntMax = Int32.MaxValue.ToString();
    private static readonly String IntMin = Int32.MinValue.ToString();

    private static readonly String UIntMax = UInt32.MaxValue.ToString();
    private static readonly String UIntMin = UInt32.MinValue.ToString();

    private static readonly String FloatMax = Single.MaxValue.ToString();
    private static readonly String FloatMin = Single.MinValue.ToString();

    private static readonly String LongMax = Int64.MaxValue.ToString();
    private static readonly String LongMin = Int64.MinValue.ToString();

    private static readonly String ULongMax = UInt64.MaxValue.ToString();
    private static readonly String ULongMin = UInt64.MinValue.ToString();

    private static readonly String DoubleMax = Double.MaxValue.ToString();
    private static readonly String DoubleMin = Double.MinValue.ToString();

    private static String GetErrorMsg(DataType type)
    {
        var result = String.Empty;

        switch (type)
        {
            case DataType.Byte:
                result = "设置范围：" + ByteMin + "-" + ByteMax;
                break;
            case DataType.Short:
                result = "设置范围：" + ShortMin + "-" + ShortMax;
                break;
            case DataType.UShort:
                result = "设置范围：" + UShortMin + "-" + UShortMax;
                break;
            case DataType.Int:
                result = "设置范围：" + IntMin + "-" + IntMax;
                break;
            case DataType.UInt:
                result = "设置范围：" + UIntMin + "-" + UIntMax;
                break;
            case DataType.Long:
                result = "设置范围：" + LongMin + "-" + LongMax;
                break;
            case DataType.ULong:
                result = "设置范围：" + ULongMin + "-" + ULongMax;
                break;
            case DataType.Float:
                result = "设置范围：" + FloatMin + "-" + FloatMax;
                break;
            case DataType.Double:
                result = "设置范围：" + DoubleMin + "-" + DoubleMax;
                break;
            case DataType.Bool:
                break;
            case DataType.String:
                break;
            case DataType.ByteArray:
                break;
            case DataType.HexString:
                break;
            default:
                result = "非有效值类型";
                break;
        }
        return result;
    }

    /// <summary>
    /// 获取线性转换结果
    /// </summary>
    /// <param name="value">原始值</param>
    /// <param name="scale">线性系数</param>
    /// <param name="offset">线性偏移</param>
    /// <returns>带操作结果的转换结果</returns>
    [Description("获取线性转换结果")]
    public static OperateResult<Object> GetMigrationValue(Object value, Single scale, Single offset)
    {
        if (scale == 1.0 && offset == 0.0)
        {
            return OperateResult.CreateSuccessResult(value);
        }
        else
        {
            Object val;
            try
            {
                var type = value.GetType().Name;
                val = type.ToLower() switch
                {
                    "byte" or "int16" or "uint16" or "int32" or "uint32" or "single" => Convert.ToSingle((Convert.ToSingle(value) * scale + offset).ToString("N4")),
                    "int64" or "uint64" or "double" => Convert.ToDouble((Convert.ToDouble(value) * scale + offset).ToString("N4")),
                    _ => value,
                };
                return OperateResult.CreateSuccessResult(val);
            }
            catch (Exception ex)
            {
                return new OperateResult<Object>("转换出错：" + ex.Message);
            }
        }
    }

    /// <summary>
    /// 线性转换后的设定值
    /// </summary>
    /// <param name="set">设定值</param>
    /// <param name="type">数据类型</param>
    /// <param name="scale">线性系数</param>
    /// <param name="offset">线性偏移</param>
    /// <returns>带操作结果的转换结果</returns>
    [Description("线性转换后的设定值")]
    public static OperateResult<String> SetMigrationValue(String set, DataType type, Single scale, Single offset)
    {
        var result = new OperateResult<String>(false);
        if (scale == 1.0 && offset == 0.0)
        {
            try
            {
                switch (type)
                {
                    case DataType.Byte:
                        result.Content = Convert.ToByte(set).ToString();
                        break;
                    case DataType.Short:
                        result.Content = Convert.ToInt16(set).ToString();
                        break;
                    case DataType.UShort:
                        result.Content = Convert.ToUInt16(set).ToString();
                        break;
                    case DataType.Int:
                        result.Content = Convert.ToInt32(set).ToString();
                        break;
                    case DataType.UInt:
                        result.Content = Convert.ToUInt32(set).ToString();
                        break;
                    case DataType.Long:
                        result.Content = Convert.ToInt64(set).ToString();
                        break;
                    case DataType.ULong:
                        result.Content = Convert.ToUInt64(set).ToString();
                        break;
                    case DataType.Float:
                        result.Content = Convert.ToSingle(set).ToString();
                        break;
                    case DataType.Double:
                        result.Content = Convert.ToDouble(set).ToString();
                        break;
                    case DataType.Bool:
                        break;
                    case DataType.String:
                        break;
                    case DataType.ByteArray:
                        break;
                    case DataType.HexString:
                        break;
                    default:
                        result.Content = set;
                        break;
                }
                result.IsSuccess = true;
                return result;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.Message = "转换出错，" + GetErrorMsg(type);
                return result;
            }
        }
        else
        {
            try
            {
                switch (type)
                {
                    case DataType.Byte:
                        result.Content = Convert.ToByte((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.Short:
                        result.Content = Convert.ToInt16((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.UShort:
                        result.Content = Convert.ToUInt16((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.Int:
                        result.Content = Convert.ToInt32((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.UInt:
                        result.Content = Convert.ToUInt32((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.Long:
                        result.Content = Convert.ToInt64((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.ULong:
                        result.Content = Convert.ToUInt64((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.Float:
                        result.Content = Convert.ToSingle((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.Double:
                        result.Content = Convert.ToDouble((Convert.ToSingle(set) - offset) / scale).ToString();
                        break;
                    case DataType.Bool:
                        break;
                    case DataType.String:
                        break;
                    case DataType.ByteArray:
                        break;
                    case DataType.HexString:
                        break;
                    default:
                        result.Content = set;
                        break;
                }
                result.IsSuccess = true;
                return result;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.Message = "转换出错，" + GetErrorMsg(type);
                return result;
            }
        }
    }

}