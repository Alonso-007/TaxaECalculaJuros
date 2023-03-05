using Taxas.Api.Domain.TaxasDeJuros;
using Taxas.Teste.TaxasDeJuros.Builders;

namespace Taxas.Teste.TaxasDeJuros;

public class TaxasPercentuaisTeste
{
    private readonly TaxasPercentuaisBuilder _builder;
	private readonly ITaxasPercentuais taxasPercentuais;

    public TaxasPercentuaisTeste()
	{
		_builder= new TaxasPercentuaisBuilder();
        taxasPercentuais = new TaxasPercentuais();
    }

	[Fact]
    public void RetornoValorPercentualCorreto()
    {
        var valorPercentual = taxasPercentuais.PercentualTaxa();

        var domain = _builder
            .ValorPercentualCorreto()
            .BuildService();

        var resultado = domain.PercentualTaxa();

        Assert.Equal(valorPercentual, resultado, 2);
    }

    [Fact]
    public void RetornoValorPercentualInCorreto()
    {
        var valorPercentual = taxasPercentuais.PercentualTaxa();

        var domain = _builder
            .ValorPercentualIncorreto()
            .BuildService();

        var resultado = domain.PercentualTaxa();

        Assert.NotEqual(valorPercentual, resultado, 2);
    }

}