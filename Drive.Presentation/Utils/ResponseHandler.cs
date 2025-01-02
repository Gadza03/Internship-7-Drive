using Drive.Domain.Enums;

namespace Drive.Presentation.Utils
{
    public static class ResponseHandler
    {
        public static string ErrorMessage(ResponseResultType resultType)
        {
            return resultType switch
            {
                ResponseResultType.Success => "Operation completed successfully.",
                ResponseResultType.NotFound => "The requested item was not found.",
                ResponseResultType.AlreadyExists => "An item with the same name already exists.",
                ResponseResultType.NoChanges => "No changes were made to the data.",
                ResponseResultType.ValidationError => "The input data is invalid.",
                _ => "An unknown error occurred."
            };
        }
    }
}
