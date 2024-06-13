using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barbearia.Dominio.Genericos;
using Barbearia.Dominio.Servicos.Entidades;
using Barbearia.Dominio.Servicos.Repositorios.Filtros;

namespace Barbearia.Dominio.Servicos.Repositorios
{
    public interface IServicosRepositorio : IGenericoRepositorio<Servico>
    {
        IQueryable<Servico> Filtrar(ServicoListarFiltro filtro);
    }
}