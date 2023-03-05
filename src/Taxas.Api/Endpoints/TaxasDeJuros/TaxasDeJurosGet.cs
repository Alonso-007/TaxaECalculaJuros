using Microsoft.AspNetCore.Authorization;
using Taxas.Api.Domain.TaxasDeJuros;

namespace Taxas.Api.Endpoints.TaxasDeJuros;

public class TaxasDeJurosGet
{
    public static string Template => "/taxasdejuros";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [AllowAnonymous]
    public static IResult Action(ITaxasPercentuais taxasPercentuais)
    {
        return Results.Ok(taxasPercentuais.PercentualTaxa());
    }
}