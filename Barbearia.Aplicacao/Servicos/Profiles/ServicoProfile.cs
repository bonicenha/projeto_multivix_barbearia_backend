using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Barbearia.DataTransfer.Servicos.Request;
using Barbearia.DataTransfer.Servicos.Response;
using Barbearia.Dominio.Servicos.Entidades;
using Barbearia.Dominio.Servicos.Repositorios.Filtros;
using Barbearia.Dominio.Servicos.Servicos.Comandos;

namespace Barbearia.Aplicacao.Servicos.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<Servico, ServicoResponse>();
            CreateMap<ServicoListarRequest, ServicoListarFiltro>();
            CreateMap<ServicoRequest, ServicoComando>();
        }
    }
}