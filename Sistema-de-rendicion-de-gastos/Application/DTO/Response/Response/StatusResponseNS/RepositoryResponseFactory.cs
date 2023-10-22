using Application.Dto.ResponseNS.ResponseFactory;
using System.Xml.Linq;

namespace Application.Dto.Response.StatusResponseNS
{/*
    public class RepositoryResponseFactory : IRepositoryResponseFactory
    {
        public StatusResponse DbUpdateException()
        {
            return new ErrorResponse(21001, "Error al enviar actualizaciones a la base de datos.");
        }

        public StatusResponse DbUpdateConcurrencyException()
        {
            return new ErrorResponse(21002, "Un comando de base de datos no afectaba al número esperado de filas. Esto suele indicar una infracción de simultaneidad optimista; es decir, se ha cambiado una fila en la base de datos desde que se consultó.");
        }

        public StatusResponse DbEntityValidationException()
        {
            return new ErrorResponse(21003, "Se anuló el guardado porque se produjo un error en la validación de los valores de propiedad de entidad.");
        }

        public StatusResponse NotSupportedException()
        {
            return new ErrorResponse(21004, "Se intentó usar un comportamiento no admitido, como ejecutar varios comandos asincrónicos simultáneamente en la misma instancia de contexto.");
        }

        public StatusResponse ObjectDisposedException()
        {
            return new ErrorResponse(21005, "Se ha eliminado el contexto o la conexión.");
        }

        public StatusResponse InvalidOperationException()
        {
            return new ErrorResponse(21006, "Se produjo algún error al intentar procesar entidades en el contexto antes o después de enviar comandos a la base de datos.");
        }

        public StatusResponse Ok()
        {
            return new OkResponse(200, "Ok");
        }
    }*/
}