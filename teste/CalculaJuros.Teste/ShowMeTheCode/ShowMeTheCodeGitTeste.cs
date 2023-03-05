using CalculaJuros.Api.Domain.ShowMeTheCode;

namespace CalculaJuros.Teste.ShowMeTheCode;
public class ShowMeTheCodeGitTeste
{
    private readonly IShowMeTheCodeGit _showMeTheCodeGit;

    public ShowMeTheCodeGitTeste()
    {
        _showMeTheCodeGit = new ShowMeTheCodeGit();
    }

    [Fact]
    public void UlrValida()
    {
        var url = _showMeTheCodeGit.RetornaUrlGit();

        Assert.True(Uri.IsWellFormedUriString(url, UriKind.Absolute));
    }

    [Fact]
    public void UlrValidaEPrefixoGit()
    {
        var url = _showMeTheCodeGit.RetornaUrlGit();

        Assert.True(Uri.IsWellFormedUriString(url, UriKind.Absolute));
        Assert.StartsWith("https://github.com/", url);
    }
}
