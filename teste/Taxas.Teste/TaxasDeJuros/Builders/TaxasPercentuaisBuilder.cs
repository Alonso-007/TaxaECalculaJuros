using Moq;
using Taxas.Api.Domain.TaxasDeJuros;

namespace Taxas.Teste.TaxasDeJuros.Builders;
public class TaxasPercentuaisBuilder
{
    private readonly Mock<ITaxasPercentuais> _taxasPercentuais;

	public TaxasPercentuaisBuilder()
	{
        _taxasPercentuais = new Mock<ITaxasPercentuais>();
    }

    public TaxasPercentuaisBuilder ValorPercentualCorreto()
    {
        _taxasPercentuais
            .Setup(s => s.PercentualTaxa())
            .Returns(0.01D);

        return this;
    }

    public TaxasPercentuaisBuilder ValorPercentualIncorreto()
    {
        _taxasPercentuais
            .Setup(s => s.PercentualTaxa())
            .Returns(0.02D);

        return this;
    }

    public ITaxasPercentuais BuildService()
    {
        return _taxasPercentuais.Object;
    }
}
