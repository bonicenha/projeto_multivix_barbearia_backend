namespace Barbearia.Dominio.Servicos.Entidades
{
    public class Servico
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        protected Servico()
        {
        }

        public Servico(string nome, decimal valor)
        {
            SetNome(nome);
            SetValor(valor);
        }

        public virtual void SetNome(string nome)
        {
            Nome = nome;
        }

        public virtual void SetValor(decimal valor)
        {
            Valor = valor;
        }
    }
}