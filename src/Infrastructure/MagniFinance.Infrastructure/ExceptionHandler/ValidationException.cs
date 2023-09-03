using System.Net;

namespace MagniFinance.Infrastructure.ExceptionHandler;

public class ValidationException<T> : Exception
{
    public string ResponseCode { get; private set; }
    public string ResponseMessage { get; private set; }
    public string ResponseDescription { get; private set; }
    public T Errors { get; private set; }
    public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.BadRequest;
    
    public ValidationException(string respCode, string respDescription, T errors) : base(ResponseHandler.ResponseCode.GetResponseDescription(respCode))
    {
        ResponseCode = respCode;
        ResponseMessage = ResponseHandler.ResponseCode.GetResponseDescription(respCode);
        ResponseDescription = ResponseHandler.ResponseCode.GetResponseDescription(respCode);
        Errors = errors;
    }

    public ValidationException(HttpStatusCode httpStatusCode, string respCode, string respDescription, T errors) : base(ResponseHandler.ResponseCode.GetResponseDescription(respCode))
    {
        StatusCode = httpStatusCode;
        ResponseCode = respCode;
        ResponseMessage = ResponseHandler.ResponseCode.GetResponseDescription(respCode);
        ResponseDescription = ResponseHandler.ResponseCode.GetResponseDescription(respCode);
        Errors = errors;
    }
    
}