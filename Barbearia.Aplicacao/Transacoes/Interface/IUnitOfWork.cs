namespace Barbearia.Aplicacao.Transacoes.Interface;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}
