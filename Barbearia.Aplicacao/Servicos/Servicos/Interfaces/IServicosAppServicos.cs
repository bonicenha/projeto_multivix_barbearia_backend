
using Barbearia.DataTransfer.Servicos.Request;
using Barbearia.DataTransfer.Servicos.Response;
using Barbearia.Dominio.Util;

namespace Barbearia.Aplicacao.Servicos.Servicos.Interfaces
{
    public interface IServicosAppServicos
    {
        PaginacaoConsulta<ServicoResponse> Listar(ServicoListarRequest request);
        ServicoResponse Recuperar(int id);
        ServicoResponse Inserir(ServicoRequest request);
        ServicoResponse Editar(int id, ServicoRequest request);
        void Excluir(int id);
    }
}