using Application.DTO.Response;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.API.Handlers;
using System.Net;

namespace Presentation.Handlers
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            string message = context.Exception.Message;
            if (context.Exception is InvalidFormatIdException ||
               context.Exception is BadRequestException ) 
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (
                context.Exception is NonExistentReferenceException ||
                context.Exception is NoFilterMatchesException ||
                context.Exception is NotFoundException
                )
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else if(context.Exception is ConflictException)
            {
                statusCode = HttpStatusCode.Conflict;
            }
            else if (
                context.Exception is InvalidTokenInformation ||
                context.Exception is MicroserviceComunicationException ||
                context.Exception is InvalidMicroserviceResponseFormatException ||
                context.Exception is MicroserviceErrorResponseException ||
                context.Exception is UnprocesableContentException
                )
            {
                statusCode = HttpStatusCode.UnprocessableEntity;
                message = "Inconvenientes en la comunicacion entre microservicios";
                /*
                 * 
                 * RESOLVER LOGER O CONSOLE
                 * 
                **message.Add("context.Exception.Message");
                 * 
                 */
            }
            else
                message = "Ha ocurrido un error interno.";
            
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(new ErrorResponse() 
            { 
                message = message 
            });
        }
    }
}
