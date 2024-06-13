using Barbearia.Dominio.Servicos.Entidades;
using Barbearia.Dominio.Servicos.Repositorios;
using Barbearia.Dominio.Servicos.Repositorios.Filtros;
using Barbearia.Infra.Genericos;
using NHibernate;

namespace Barberia.Infra.Servicos.Repositorios
{
    public class ServicosRepositorio : GenericoRepositorio<Servico>, IServicosRepositorio
    {
        public ServicosRepositorio(ISession session) : base(session)
        {
        }

        public IQueryable<Servico> Filtrar(ServicoListarFiltro filtro)
        {
            IQueryable<Servico> query = Query();

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
            {
                query = query.Where(d => d.Nome.Contains(filtro.Nome));
            }

            if (filtro.Valor.HasValue)
            {
                query = query.Where(x => x.Valor == filtro.Valor.Value);
            }

            return query;
        }
    }
}