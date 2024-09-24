namespace WebApplication1.Model
{
    public class ValidationErrorResponse : ErrorResponse
    {
        (string, string) Errors { get; set; }
    }
}
