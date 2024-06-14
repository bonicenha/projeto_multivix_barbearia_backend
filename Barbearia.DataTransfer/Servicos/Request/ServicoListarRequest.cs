using Barbearia.Dominio.Util;
using Barbearia.Dominio.Util.Enumeradores;

namespace Barbearia.DataTransfer.Servicos.Request
{
    public class ServicoListarRequest : PaginacaoFiltro
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public ServicoListarRequest() : base(cpOrd: "Id", tpOrd: TipoOrdenacaoEnum.Desc)
        {
        }
    }
}