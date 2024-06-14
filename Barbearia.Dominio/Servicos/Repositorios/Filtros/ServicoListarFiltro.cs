using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barbearia.Dominio.Util;
using Barbearia.Dominio.Util.Enumeradores;

namespace Barbearia.Dominio.Servicos.Repositorios.Filtros
{
    public class ServicoListarFiltro : PaginacaoFiltro
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public ServicoListarFiltro() : base(cpOrd: "Id", tpOrd: TipoOrdenacaoEnum.Desc)
        {
        }
    }
}