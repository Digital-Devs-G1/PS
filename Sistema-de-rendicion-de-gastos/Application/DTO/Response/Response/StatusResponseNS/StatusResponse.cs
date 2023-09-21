namespace Application.Dto.Response.StatusResponseNS
{
    public abstract class StatusResponse
    {
        public int Code { get; }
        public string Message { get; }

        public StatusResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public abstract bool IsError();
    }
}