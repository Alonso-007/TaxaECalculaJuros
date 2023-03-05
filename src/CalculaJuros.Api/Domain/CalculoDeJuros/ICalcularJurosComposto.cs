namespace CalculaJuros.Api.Domain.CalculoDeJuros
{
    public interface ICalcularJurosComposto
    {
        double RealizaCalculoDeJurosComposto(double valorInicial, double juros, int tempo);
    }
}
