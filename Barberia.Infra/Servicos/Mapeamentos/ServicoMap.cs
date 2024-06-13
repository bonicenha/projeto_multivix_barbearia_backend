using Barbearia.Dominio.Servicos.Entidades;
using FluentNHibernate.Mapping;

namespace Barberia.Infra.Servicos.Mapeamentos
{
    public class ServicoMap : ClassMap<Servico>
    {
        public ServicoMap()
        {
            Schema("barbearia");
            Table("servico");
            Id(x => x.Id, "id");
            Map(x => x.Nome, "nome");
            Map(x => x.Valor, "valor");
        }
    }
}