using Barbearia.Dominio.Util;
using Barbearia.Dominio.Util.Enumeradores;

namespace Barbearia.Dominio.Genericos;

public interface IGenericoRepositorio<T> where T : class
{
    T Recuperar(int id);
    T Inserir(T entidade);
    T Editar(T entidade);
    void Excluir(T entidade);
    PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd);
    IQueryable<T> Query();
    Task<T> RecuperarAsync(int id);
    Task<T> InserirAsync(T entidade);
    Task<T> EditarAsync(T entidade);
    Task ExcluirAsync(T entidade);
}
