using System.Runtime.Serialization;
using System.Text;

namespace Barbearia.Dominio.Excecoes;

[Serializable]
public class TamanhoDeAtributoInvalidoExcecao : RegraDeNegocioExcecao
{
    public TamanhoDeAtributoInvalidoExcecao()
    {
    }
    public TamanhoDeAtributoInvalidoExcecao(string atributo) : base(MontaMensagemErro(atributo, null, null))
    {
    }
    public TamanhoDeAtributoInvalidoExcecao(string atributo, int? tamanhoMinimo, int? tamanhoMaximo) : base(MontaMensagemErro(atributo, tamanhoMinimo, tamanhoMaximo))
    {
    }
    private static string MontaMensagemErro(string atributo, int? tamanhoMinimo, int? tamanhoMaximo)
    {
        StringBuilder sb = new("Tamanho do campo " + atributo + " inválido.");
        if (tamanhoMinimo.HasValue)
        {
            sb.Append(" Tamanho mínimo: ");
            sb.Append(tamanhoMinimo.Value);
            sb.Append('.');
        }
        if (tamanhoMaximo.HasValue)
        {
            sb.Append(" Tamanho máximo: ");
            sb.Append(tamanhoMaximo.Value);
            sb.Append('.');
        }
        return sb.ToString();
    }

    protected TamanhoDeAtributoInvalidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}

