using System.Runtime.Serialization;
using System.Text;

namespace Barbearia.Dominio.Excecoes;

public class LimiteDeValorInvalidoExcecao : RegraDeNegocioExcecao
{
    public LimiteDeValorInvalidoExcecao()
    {
    }
    public LimiteDeValorInvalidoExcecao(string atributo) : base(MontaMensagemErro(atributo, null, null))
    {
    }
    public LimiteDeValorInvalidoExcecao(string atributo, int? tamanhoMinimo, int? tamanhoMaximo) : base(MontaMensagemErro(atributo, tamanhoMinimo, tamanhoMaximo))
    {
    }
    private static string MontaMensagemErro(string atributo, int? tamanhoMinimo, int? tamanhoMaximo)
    {
        StringBuilder sb = new("Limite de valores do campo " + atributo + " inválido.");
        if (tamanhoMinimo.HasValue)
        {
            sb.Append($" Valor mínimo: {tamanhoMinimo.Value}.");
        }
        if (tamanhoMaximo.HasValue)
        {
            sb.Append($" Valor máximo: {tamanhoMaximo.Value}.");
        }
        return sb.ToString();
    }

    protected LimiteDeValorInvalidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}


