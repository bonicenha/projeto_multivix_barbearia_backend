using Barbearia.Aplicacao.Servicos.Servicos.Interfaces;
using Barbearia.DataTransfer.Servicos.Request;
using Barbearia.DataTransfer.Servicos.Response;
using Barbearia.Dominio.Util;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.API.Controllers.Servicos
{
    [ApiController]
    [Route("api/servicos")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicosAppServico servicosAppServicos;

        public ServicoController(IServicosAppServico servicosAppServicos)
        {
            this.servicosAppServicos = servicosAppServicos;
        }

        /// <summary>
        /// Recupera um atendimento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ServicoResponse> Recuperar(int id)
        {
            ServicoResponse response = servicosAppServicos.Recuperar(id);

            return Ok(response);
        }

        /// <summary>
        /// Lista os atendimentos com paginação
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PaginacaoConsulta<ServicoResponse>> Listar([FromQuery] ServicoListarRequest request)
        {
            var response = servicosAppServicos.Listar(request);

            return Ok(response);
        }

        /// <summary>
        /// Adiciona um atendimento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ServicoResponse> Inserir([FromBody] ServicoRequest request)
        {
            ServicoResponse response = servicosAppServicos.Inserir(request);

            return Ok(response);
        }

        /// <summary>
        /// Edita um atendimento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<ServicoResponse> Editar(int id, [FromBody] ServicoRequest request)
        {
            ServicoResponse response = servicosAppServicos.Editar(id, request);

            return Ok(response);
        }

        /// <summary>
        /// Exclui um atendimento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            servicosAppServicos.Excluir(id);

            return Ok();
        }
    }
}