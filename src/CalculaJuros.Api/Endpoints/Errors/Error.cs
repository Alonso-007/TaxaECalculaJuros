using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;

namespace CalculaJuros.Api.Endpoints.Errors
{
    public class Error
    {
        public static string Template => "/error";

        public static Delegate Handle => Action;

        [AllowAnonymous]
        public static IResult Action(HttpContext http)
        {
            var error = http.Features?.Get<IExceptionHandlerFeature>()?.Error;

            if (error is not null)
            {
                if (error is HttpRequestException)
                    return Results.Problem(title: "Api de taxas esta indisponivel", statusCode: 500);

                else if (error is BadHttpRequestException)
                    return Results.Problem(title: "Erro nos valores passados para o calculo", detail: error.Message, statusCode: 400);
            }

            var message = "Erro inesperado entre em contato com administrador do sistema";

            return Results.Problem(title: "Algum erro aconteceu", detail: message, statusCode: 500);
        }
    }
}
