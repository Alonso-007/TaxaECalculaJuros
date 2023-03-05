namespace CalculaJuros.Api.Domain.CalculoDeJuros
{
    public class CalcularJurosComposto : ICalcularJurosComposto
    {
        public double RealizaCalculoDeJurosComposto(double valorInicial, double juros, int tempo)
        {
            var valorFinal = valorInicial * Math.Pow((1 + juros), tempo);

            return Convert.ToDouble(valorFinal.ToString("0.00"));
        }
    }
}
