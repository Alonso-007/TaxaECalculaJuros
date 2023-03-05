using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;

namespace Taxas.Api.Endpoints.Errors
{
    public class Error
    {
        public static string Template => "/error";

        public static Delegate Handle => Action;

        [AllowAnonymous]
        public static IResult Action(HttpContext http)
        {
            var error = http.Features?.Get<IExceptionHandlerFeature>()?.Error;

            var message = error is not null ? error.Message : "Erro inesperado entre em contato com administrador do sistema";

            return Results.Problem(title: "Algum erro aconteceu", detail: message, statusCode: 500);
        }
    }
}
