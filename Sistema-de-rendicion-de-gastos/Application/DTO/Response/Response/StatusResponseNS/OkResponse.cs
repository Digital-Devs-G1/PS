using Application.Dto.Response.StatusResponseNS;

namespace Application.Dto.ResponseNS.ResponseFactory
{
    public class OkResponse : StatusResponse
    {
        public OkResponse(int code, string message) : base(code, message)
        {
        }

        public override bool IsError()
        {
            return false;
        }
    }
}
