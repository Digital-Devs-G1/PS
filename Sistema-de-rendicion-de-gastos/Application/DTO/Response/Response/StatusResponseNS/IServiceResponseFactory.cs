
namespace Application.Dto.Response.StatusResponseNS
{
    public interface IServiceResponseFactory
    {
        public StatusResponse Ok();
        public StatusResponse WrongNumberOfFields();
        public StatusResponse UnexpectedField(string expectedField, string receivedField);
        public StatusResponse UnexpectedDataType(int expectedType, string receivedType);
    }
}
