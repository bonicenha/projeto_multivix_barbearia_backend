using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barbearia.Dominio.Util;
using Barbearia.Dominio.Util.Enumeradores;

namespace Barbearia.DataTransfer.Servicos.Request
{
    public class ServicoListarRequest : PaginacaoFiltro
    {
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public ServicoListarRequest() : base(cpOrd: "Id", tpOrd: TipoOrdenacaoEnum.Desc)
        {
        }
    }
}