using System.Net;

namespace MagniFinance.Infrastructure.ExceptionHandler;

public class AppException<T> : Exception
{
    public string ResponseCode { get; private set; }
    public string ResponseMessage { get; private set; }
    public string ResponseDescription { get; private set; }
    public T Errors { get; private set; }
    public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.BadRequest;


    public AppException(string respCode, string responseMessage, T errors) : base(responseMessage)
    {
        ResponseCode = respCode;
        ResponseMessage = responseMessage;
        ResponseDescription = ResponseHandler.ResponseCode.GetResponseDescription(respCode);
        Errors = errors;
    }

    public AppException(HttpStatusCode httpStatusCode, string respCode, string responseMessage, T errors) : base(responseMessage)
    {
        StatusCode = httpStatusCode;
        ResponseCode = respCode;
        ResponseMessage = responseMessage;
        ResponseDescription = ResponseHandler.ResponseCode.GetResponseDescription(respCode);
        Errors = errors;
    }
    
    public AppException(HttpStatusCode httpStatusCode, string respCode, string responseMessage) : base(responseMessage)
    {
        StatusCode = httpStatusCode;
        ResponseCode = respCode;
        ResponseMessage = responseMessage;
        ResponseDescription = ResponseHandler.ResponseCode.GetResponseDescription(respCode);
    }
}