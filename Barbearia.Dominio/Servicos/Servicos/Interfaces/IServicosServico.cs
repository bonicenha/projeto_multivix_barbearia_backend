using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barbearia.Dominio.Servicos.Entidades;
using Barbearia.Dominio.Servicos.Servicos.Comandos;

namespace Barbearia.Dominio.Servicos.Servicos.Interfaces
{
    public interface IServicosServico
    {
        Servico Validar(int id);
        Servico Instanciar(ServicoComando comando);
        Servico Inserir(ServicoComando comando);
        Servico Editar(int id, ServicoComando comando);
    }
}