using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IServicosAppServicos servicosAppServicos;

        public ServicoController(IServicosAppServicos servicosAppServicos)
        {
            this.servicosAppServicos = servicosAppServicos;
        }

        /// <summary>
        /// Recupera uma cantina por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ServicoResponse> Recuperar(int id)
        {
            var response = servicosAppServicos.Recuperar(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Listar cantinas
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
        /// Editar uma cantina por Id
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
        /// Excluir uma cantina por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Excluir(int id)
        {
            servicosAppServicos.Excluir(id);
            return Ok();
        }

        ///<summary>
        /// Criar Cantina.
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        public ActionResult Inserir([FromBody] ServicoRequest request)
        {
            var response = servicosAppServicos.Inserir(request);
            return Ok(response);
        } 
    }
}