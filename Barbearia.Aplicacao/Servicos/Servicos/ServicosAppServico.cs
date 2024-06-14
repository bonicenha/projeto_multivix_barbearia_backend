using AutoMapper;
using Barbearia.Aplicacao.Servicos.Servicos.Interfaces;
using Barbearia.Aplicacao.Transacoes.Interface;
using Barbearia.DataTransfer.Servicos.Request;
using Barbearia.DataTransfer.Servicos.Response;
using Barbearia.Dominio.Servicos.Entidades;
using Barbearia.Dominio.Servicos.Repositorios;
using Barbearia.Dominio.Servicos.Repositorios.Filtros;
using Barbearia.Dominio.Servicos.Servicos.Comandos;
using Barbearia.Dominio.Servicos.Servicos.Interfaces;
using Barbearia.Dominio.Util;

namespace Barbearia.Aplicacao.Servicos.Servicos
{
    public class ServicosAppServico : IServicosAppServico
    {
        private readonly IServicosRepositorio servicosRepositorio;
        private readonly IServicosServico servicosServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ServicosAppServico(IServicosRepositorio servicosRepositorio, IServicosServico servicosServico, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.servicosRepositorio = servicosRepositorio;
            this.servicosServico = servicosServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public ServicoResponse Editar(int id, ServicoRequest request)
        {
            var comando = mapper.Map<ServicoComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Servico servico = servicosServico.Editar(id, comando);
                unitOfWork.Commit();
                return mapper.Map<ServicoResponse>(servico);;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public ServicoResponse Inserir(ServicoRequest request)
        {
            var comando = mapper.Map<ServicoComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                var servico = servicosServico.Inserir(comando);
                unitOfWork.Commit();
                return mapper.Map<ServicoResponse>(servico);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public PaginacaoConsulta<ServicoResponse> Listar(ServicoListarRequest request)
        {
            ServicoListarFiltro filtros = mapper.Map<ServicoListarFiltro>(request);

            IQueryable<Servico> query = servicosRepositorio.Filtrar(filtros);

            PaginacaoConsulta<Servico> servicos = servicosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

            PaginacaoConsulta<ServicoResponse> response;

            response = mapper.Map<PaginacaoConsulta<ServicoResponse>>(servicos);

        return response;
        }

        public ServicoResponse Recuperar(int id)
        {
            Servico servico = servicosServico.Validar(id);
            var response = mapper.Map<ServicoResponse>(servico);
            return response;
        }

        public void Excluir(int id)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Servico servico = servicosServico.Validar(id);
                servicosRepositorio.Excluir(servico);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}