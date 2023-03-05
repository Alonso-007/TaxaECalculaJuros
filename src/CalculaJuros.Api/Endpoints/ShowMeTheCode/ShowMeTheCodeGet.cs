using CalculaJuros.Api.Domain.ShowMeTheCode;
using Microsoft.AspNetCore.Authorization;

namespace CalculaJuros.Api.Endpoints.ShowMeTheCode
{
    public class ShowMeTheCodeGet
    {
        public static string Template => "/showmethecode";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        [AllowAnonymous]
        public static IResult Action(IShowMeTheCodeGit showMeTheCodeGit)
        {
            return Results.Ok(showMeTheCodeGit.RetornaUrlGit());
        }
    }
}
