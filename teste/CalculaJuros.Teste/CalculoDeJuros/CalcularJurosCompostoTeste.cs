using CalculaJuros.Api.Domain.CalculoDeJuros;

namespace CalculaJuros.Teste.CalculoDeJuros;
public class CalcularJurosCompostoTeste
{
    private readonly ICalcularJurosComposto _calcularJurosComposto;

	public CalcularJurosCompostoTeste()
	{
        _calcularJurosComposto = new CalcularJurosComposto();
    }

    [Theory]
    [InlineData(100, 0.01D, 5, 105.10D)]
    [InlineData(10, 0.01D, 100, 27.05D)]
    public void RealizaCalculoDeJurosComposto(double valorInicial, double juros, int tempo, double valorFinalTeste)
    {
        var valorFinal = _calcularJurosComposto.RealizaCalculoDeJurosComposto(valorInicial, juros, tempo);

        Assert.Equal(valorFinalTeste, valorFinal);
    }
}
