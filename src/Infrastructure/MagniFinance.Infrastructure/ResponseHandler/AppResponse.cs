namespace MagniFinance.Infrastructure.ResponseHandler;

public class AppResponse<T, E>
{
    public AppResponse(string respCode, string respMessage, T data, E errors)
    {
        RespCode = respCode;
        RespMessage = respMessage;
        RespDescription = ResponseCode.GetResponseDescription(respCode);
        Data = data;
        Errors = errors;

    }
    public AppResponse(string respCode, string respMessage, T data)
    {
        RespCode = respCode;
        RespMessage = respMessage;
        RespDescription = ResponseCode.GetResponseDescription(respCode);
        Data = data;
    }
    
    public string RespCode { get; set; }
    public string RespDescription { get; set; }
    public string RespMessage { get; set; }

    public T Data { get; set; }
    public E Errors { get; set; }
}