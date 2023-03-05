using CalculaJuros.Api.Domain.CalculoDeJuros;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using System.Net.Http.Headers;

namespace CalculaJuros.Api.Endpoints.CalculaJuros
{
    public class CalculaJurosGet
    {
        public static string Template => "/calculajuros";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        [AllowAnonymous]
        public static async Task<IResult> Action(double valorInicial, int tempo, ICalcularJurosComposto calcularJurosComposto, IConfiguration configuration)
        {
            if (valorInicial < 0 || tempo < 0)
            {
                throw new BadHttpRequestException("Os valor inicial e tempo tem que ser maiores que zero");
            }

            using (var client = new HttpClient())
            {
                GetHeader(client);

                using (var response = await client.GetAsync(configuration["ApiJuros"]))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jurosAsString = await response.Content.ReadAsStringAsync();

                        var juros = Convert.ToDouble(jurosAsString, CultureInfo.InvariantCulture);

                        var valorFinal = calcularJurosComposto.RealizaCalculoDeJurosComposto(valorInicial, juros, tempo);

                        return Results.Ok(valorFinal.ToString("0.00"));
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o valor do percentual dos juros: " + response.StatusCode);
                    }
                }
            }
        }

        private static void GetHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
