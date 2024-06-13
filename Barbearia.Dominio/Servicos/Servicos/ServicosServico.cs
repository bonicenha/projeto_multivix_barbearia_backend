using Barbearia.Dominio.Excecoes;
using Barbearia.Dominio.Servicos.Entidades;
using Barbearia.Dominio.Servicos.Repositorios;
using Barbearia.Dominio.Servicos.Servicos.Comandos;
using Barbearia.Dominio.Servicos.Servicos.Interfaces;

namespace Barbearia.Dominio.Servicos.Servicos
{
    public class ServicosServico : IServicosServico
    {
        private readonly IServicosRepositorio servicosRepositorio;

        public ServicosServico(IServicosRepositorio servicosRepositorio)
        {
            this.servicosRepositorio = servicosRepositorio;
        }

        public Servico Editar(int id, ServicoComando comando)
        {
            Servico servico = Validar(id);
            servico.SetNome(comando.Nome);
            servico.SetValor(comando.Valor);
            return servicosRepositorio.Editar(servico);
        }

        public Servico Inserir(ServicoComando comando)
        {
            Servico servico = Instanciar(comando);
            return servicosRepositorio.Inserir(servico);
        }

        public Servico Instanciar(ServicoComando comando)
        {
            return new Servico(comando.Nome, comando.Valor);
        }

        public Servico Validar(int id)
        {
            Servico servico = servicosRepositorio.Recuperar(id);

            if (servico == null)
            {
                throw new RegraDeNegocioExcecao("Serviço não encontrado.");
            }
            return servico;
        }
    }
}