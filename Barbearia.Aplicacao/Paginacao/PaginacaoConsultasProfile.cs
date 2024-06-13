using AutoMapper;
using Barbearia.Dominio.Util;

namespace Barbearia.Aplicacao.Paginacao;

public class PaginacaoConsultasProfile : Profile
{
    public PaginacaoConsultasProfile()
    {
        CreateMap(typeof(PaginacaoConsulta<>), typeof(PaginacaoConsulta<>));
    }
}
