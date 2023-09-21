using Application.Dto.ResponseNS.ResponseFactory;
using System.Xml.Linq;

namespace Application.Dto.Response.StatusResponseNS
{
    public class ServiceResponseFactory : IServiceResponseFactory
    {
        public StatusResponse WrongNumberOfFields()
        {
            return new ErrorResponse(11001, "Formato de template incorrecto. Cantidad de campos variables invalida");
        }

        public StatusResponse UnexpectedField(string expectedField, string receivedField)
        {
            return new ErrorResponse(11002, "Formato de template incorrecto. Se esperaba el campo " + expectedField + " pero se recibio " + receivedField);
        }

        public StatusResponse UnexpectedDataType(string expectedType, string receivedType)
        {
            return new ErrorResponse(11003, "Formato de template incorrecto. Se esperaba el campo del tipo " + expectedType + " pero se recibio el valor " + receivedType);
        }

        public StatusResponse Ok()
        {
            return new OkResponse(200, "Ok");
        }
    }
}