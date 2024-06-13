using Barbearia.Aplicacao.Transacoes.Interface;
using NHibernate;

namespace Barbearia.Aplicacao.Transacoes;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ISession session;
    private ITransaction transaction;

    public UnitOfWork(ISession session)
    {
        this.session = session;        
    }

    public void BeginTransaction()
    {
        this.transaction = session.BeginTransaction();
    }

    public void Commit()
    {
        if(transaction != null && transaction.IsActive)
        {
            transaction.Commit();
        }        
    }

     public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }

            if (session != null)
            {
                session.Dispose();
                session = null;
            }
        }
    }

    public void Rollback()
    {
        if(transaction != null && transaction.IsActive)
        {
            transaction.Rollback();
        }
    }
}
