
using System.Text.Json;

namespace WebAPI.Errors
{
    public class ApiError
    {
        public ApiError(int errorCode, string errorMessage, string errorDetail = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDetail = errorDetail;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetail { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}