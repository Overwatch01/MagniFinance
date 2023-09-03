namespace MagniFinance.Infrastructure.ResponseHandler;

public class ResponseCode
{
    public const string OkResponse = "00";
    public const string BadRequest = "MF01";
    public const string RecordNotFound = "MF02";
    public const string FailedRequest = "MF03";

    private readonly Dictionary<string, string> ResponseDescriptions = new Dictionary<string, string>()
    {
        { OkResponse, "Successful" },
        { BadRequest, "Bad Request" },
        { RecordNotFound, "Record not found" },
        { FailedRequest, "Request failed" }
    };

    public static string GetResponseDescription(string code)
    {
        var responseCode = new ResponseCode();
        return responseCode.ResponseDescriptions.TryGetValue(code, out var description) ? description : "Unknown Response";
    }
}