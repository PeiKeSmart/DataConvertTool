using System.ComponentModel;

namespace Pek.DataConvertTool;

/// <summary>
/// 操作结果类
/// </summary>
[Description("操作结果类")]
public class OperateResult
{
    /// <summary>
    /// 结果是否成功
    /// </summary>
    public Boolean IsSuccess { get; set; }
    /// <summary>
    /// 错误描述
    /// </summary>
    public String Message { get; set; } = "UnKnown";
    /// <summary>
    /// 错误代号
    /// </summary>
    public Int32 ErrorCode { get; set; } = 99999;

    public OperateResult()
    {
    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">操作是否成功</param>
    public OperateResult(Boolean isSuccess) => IsSuccess = isSuccess;

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">操作是否成功</param>
    /// <param name="message">结果信息</param>
    public OperateResult(Boolean isSuccess, String message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">操作是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">结果信息</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message)
    {
        IsSuccess = isSuccess;
        ErrorCode = errorCode;
        Message = message;
    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="message">结果信息</param>
    public OperateResult(String message) => Message = message;

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">结果信息</param>
    public OperateResult(Int32 errorCode, String message)
    {
        ErrorCode = errorCode;
        Message = message;
    }

    /// <summary>
    /// 创建一个操作成功结果
    /// </summary>
    /// <returns></returns>
    public static OperateResult CreateSuccessResult() => new(true, 0, "Success");

    /// <summary>
    /// 创建一个操作失败结果，带结果信息
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static OperateResult CreateFailResult(String message) => new(false, 99999, message);

    /// <summary>
    /// 创建一个操作失败结果，不带结果信息
    /// </summary>
    /// <returns></returns>
    public static OperateResult CreateFailResult() => new(false, 99999, "UnKnown");

    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="value">值</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T> CreateSuccessResult<T>(T value) => new(true, 0, "Success", value);

    /// <summary>
    /// 创建带一个数据的操作失败结果
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="result">操作结果对象</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T> CreateFailResult<T>(OperateResult result) => new(false, result.ErrorCode, result.Message);

    /// <summary>
    /// 创建带一个数据的操作失败结果
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="message">错误信息</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T> CreateFailResult<T>(String message) => new(false, 99999, message);

    /// <summary>
    /// 创建带二个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <param name="value1">值1</param>
    /// <param name="value2">值2</param>
    /// <returns>带二个数据的操作结果</returns>
    public static OperateResult<T1, T2> CreateSuccessResult<T1, T2>(T1 value1, T2 value2) => new(true, 0, "", value1, value2);

    /// <summary>
    /// 创建带二个数据的操作失败结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <param name="result">操作结果</param>
    /// <returns>带二个数据的操作结果</returns>
    public static OperateResult<T1, T2> CreateFailResult<T1, T2>(OperateResult result) => new(false, result.ErrorCode, result.Message);

    /// <summary>
    /// 创建带二个数据的操作失败结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <param name="message">错误信息</param>
    /// <returns>带二个数据的操作结果</returns>
    public static OperateResult<T1, T2> CreateFailResult<T1, T2>(String message) => new(false, 99999, message);

    /// <summary>
    /// 创建带三个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <param name="value1">值1</param>
    /// <param name="value2">值2</param>
    /// <param name="value3">值3</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3> CreateSuccessResult<T1, T2, T3>(T1 value1, T2 value2, T3 value3) => new(true, 0, "Success", value1, value2, value3);

    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <param name="result">操作结果</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3> CreateFailResult<T1, T2, T3>(OperateResult result) => new(false, result.ErrorCode, result.Message);

    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <param name="message">错误信息</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3> CreateFailResult<T1, T2, T3>(String message) => new(false, 99999, message);

    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <typeparam name="T4">类型4</typeparam>
    /// <param name="value1">值1</param>
    /// <param name="value2">值2</param>
    /// <param name="value3">值3</param>
    /// <param name="value4">值4</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3, T4> CreateSuccessResult<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4) => new(true, 0, "Success", value1, value2, value3, value4);


    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <typeparam name="T4">类型4</typeparam>
    /// <param name="result">操作结果</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3, T4> CreateFailResult<T1, T2, T3, T4>(OperateResult result) => new(false, result.ErrorCode, result.Message);

    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <typeparam name="T4">类型4</typeparam>
    /// <param name="message">错误信息</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3, T4> CreateFailResult<T1, T2, T3, T4>(String message) => new(false, 99999, message);

    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <typeparam name="T4">类型4</typeparam>
    /// <typeparam name="T5">类型5</typeparam>
    /// <param name="value1">值1</param>
    /// <param name="value2">值2</param>
    /// <param name="value3">值3</param>
    /// <param name="value4">值4</param>
    /// <param name="value5">值5</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3, T4, T5> CreateSuccessResult<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5) => new(true, 0, "Success", value1, value2, value3, value4, value5);

    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <typeparam name="T4">类型4</typeparam>
    /// <typeparam name="T5">类型5</typeparam>
    /// <param name="result">操作结果</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3, T4, T5> CreateFailResult<T1, T2, T3, T4, T5>(OperateResult result) => new(false, result.ErrorCode, result.Message);

    /// <summary>
    /// 创建带一个数据的操作成功结果
    /// </summary>
    /// <typeparam name="T1">类型1</typeparam>
    /// <typeparam name="T2">类型2</typeparam>
    /// <typeparam name="T3">类型3</typeparam>
    /// <typeparam name="T4">类型4</typeparam>
    /// <typeparam name="T5">类型5</typeparam>
    /// <param name="message">错误信息</param>
    /// <returns>带一个数据的操作结果</returns>
    public static OperateResult<T1, T2, T3, T4, T5> CreateFailResult<T1, T2, T3, T4, T5>(String message) => new(false, 99999, message);
}

/// <summary>
/// 带一个数据的操作结果类
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class OperateResult<T> : OperateResult
{
    /// <summary>
    ///  数据
    /// </summary>
    public T? Content { get; set; }

    /// <summary>
    /// 构造方法
    /// </summary>
    public OperateResult() : base()
    {

    }
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">操作是否成功</param>
    public OperateResult(Boolean isSuccess) : base(isSuccess)
    {
    }
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="message">错误信息</param>
    public OperateResult(String message) : base(message)
    {
    }
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Int32 errorCode, String message) : base(errorCode, message)
    {
    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message) : base(isSuccess, errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    /// <param name="content">数据</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message, T content) : base(isSuccess, errorCode, message) => Content = content;
}

/// <summary>
/// 带二个数据的操作结果类
/// </summary>
/// <typeparam name="T1">类型1</typeparam>
/// <typeparam name="T2">类型2</typeparam>
public class OperateResult<T1, T2> : OperateResult
{
    /// <summary>
    /// 构造方法
    /// </summary>
    public OperateResult() : base()
    {
    }
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">操作是否成功</param>
    public OperateResult(Boolean isSuccess) : base(isSuccess)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="message">错误信息</param>
    public OperateResult(String message) : base(message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Int32 errorCode, String message) : base(errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message) : base(isSuccess, errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    /// <param name="content1">数据1</param>
    /// <param name="content2">数据2</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message, T1 content1, T2 content2) : base(isSuccess, errorCode, message)
    {
        Content1 = content1;
        Content2 = content2;
    }

    /// <summary>
    /// 数据1
    /// </summary>
    public T1? Content1 { get; set; }

    /// <summary>
    /// 数据2
    /// </summary>
    public T2? Content2 { get; set; }
}

/// <summary>
/// 带三个数据的操作结果类
/// </summary>
/// <typeparam name="T1">类型1</typeparam>
/// <typeparam name="T2">类型2</typeparam>
/// <typeparam name="T3">类型3</typeparam>
public class OperateResult<T1, T2, T3> : OperateResult
{
    /// <summary>
    /// 构造方法
    /// </summary>
    public OperateResult() : base()
    {
    }
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">操作是否成功</param>
    public OperateResult(Boolean isSuccess) : base(isSuccess)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="message">错误信息</param>
    public OperateResult(String message) : base(message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Int32 errorCode, String message) : base(errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message) : base(isSuccess, errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    /// <param name="content1">数据1</param>
    /// <param name="content2">数据2</param>
    /// <param name="content3">数据3</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message, T1 content1, T2 content2, T3 content3) : base(isSuccess, errorCode, message)
    {
        Content1 = content1;
        Content2 = content2;
        Content3 = content3;
    }

    /// <summary>
    /// 数据1
    /// </summary>
    public T1? Content1 { get; set; }

    /// <summary>
    /// 数据2
    /// </summary>
    public T2? Content2 { get; set; }

    /// <summary>
    /// 数据3
    /// </summary>
    public T3? Content3 { get; set; }
}

/// <summary>
/// 带四个数据的操作结果类
/// </summary>
/// <typeparam name="T1">类型1</typeparam>
/// <typeparam name="T2">类型2</typeparam>
/// <typeparam name="T3">类型3</typeparam>
/// <typeparam name="T4">类型4</typeparam>
public class OperateResult<T1, T2, T3, T4> : OperateResult
{
    /// <summary>
    /// 构造方法
    /// </summary>
    public OperateResult() : base()
    {
    }
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">操作是否成功</param>
    public OperateResult(Boolean isSuccess) : base(isSuccess)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="message">错误信息</param>
    public OperateResult(String message) : base(message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Int32 errorCode, String message) : base(errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message) : base(isSuccess, errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    /// <param name="content1">数据1</param>
    /// <param name="content2">数据2</param>
    /// <param name="content3">数据3</param>
    /// <param name="content4">数据4</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message, T1 content1, T2 content2, T3 content3, T4 content4) : base(isSuccess, errorCode, message)
    {
        Content1 = content1;
        Content2 = content2;
        Content3 = content3;
        Content4 = content4;
    }

    /// <summary>
    /// 数据1
    /// </summary>
    public T1? Content1 { get; set; }

    /// <summary>
    /// 数据2
    /// </summary>
    public T2? Content2 { get; set; }

    /// <summary>
    /// 数据3
    /// </summary>
    public T3? Content3 { get; set; }

    /// <summary>
    /// 数据4
    /// </summary>
    public T4? Content4 { get; set; }

}

/// <summary>
/// 带五个数据的操作结果类
/// </summary>
/// <typeparam name="T1">类型1</typeparam>
/// <typeparam name="T2">类型2</typeparam>
/// <typeparam name="T3">类型3</typeparam>
/// <typeparam name="T4">类型4</typeparam>
/// <typeparam name="T5">类型5</typeparam>
public class OperateResult<T1, T2, T3, T4, T5> : OperateResult
{
    /// <summary>
    /// 构造方法
    /// </summary>
    public OperateResult() : base()
    {
    }
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">操作是否成功</param>
    public OperateResult(Boolean isSuccess) : base(isSuccess)
    {
    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="message">错误信息</param>
    public OperateResult(String message) : base(message)
    {
    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Int32 errorCode, String message) : base(errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message) : base(isSuccess, errorCode, message)
    {

    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="isSuccess">是否成功</param>
    /// <param name="errorCode">错误代码</param>
    /// <param name="message">错误信息</param>
    /// <param name="content1">数据1</param>
    /// <param name="content2">数据2</param>
    /// <param name="content3">数据3</param>
    /// <param name="content4">数据4</param>
    /// <param name="content5">数据5</param>
    public OperateResult(Boolean isSuccess, Int32 errorCode, String message, T1 content1, T2 content2, T3 content3, T4 content4, T5 content5) : base(isSuccess, errorCode, message)
    {
        Content1 = content1;
        Content2 = content2;
        Content3 = content3;
        Content4 = content4;
        Content5 = content5;
    }

    /// <summary>
    /// 数据1
    /// </summary>
    public T1? Content1 { get; set; }

    /// <summary>
    /// 数据2
    /// </summary>
    public T2? Content2 { get; set; }

    /// <summary>
    /// 数据3
    /// </summary>
    public T3? Content3 { get; set; }

    /// <summary>
    /// 数据4
    /// </summary>
    public T4? Content4 { get; set; }

    /// <summary>
    /// 数据5
    /// </summary>
    public T5? Content5 { get; set; }
}