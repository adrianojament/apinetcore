using System;
using System.Collections.Generic;
using alterdata.votador.api.Models;
using alterdata.votador.api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace alterdata.votador.api.Controllers
{
    public class FundoCapitalController : Controller
    {
        private readonly IFundoCapitalRepository _repositorio;

        public FundoCapitalController(IFundoCapitalRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("api/v1/fundocapital")]
        public IActionResult ListarFundos()
        {
            return Ok(_repositorio.ListarFundos());
        }

        [HttpPost("api/v1/fundocapital")]
        public IActionResult Adicionar([FromBody]FundoCapital fundo)
        {
            _repositorio.Adicionar(fundo);
            return Ok();
        }

        [HttpPut("api/v1/fundocapital/{id}")]
        public IActionResult Alterar(Guid id, [FromBody]FundoCapital fundo)
        {
            var fundoCapitalAntigo = _repositorio.ObterPorId(id);
            if (fundoCapitalAntigo == null)
                return NotFound();

            fundoCapitalAntigo.Nome = fundo.Nome;
            fundoCapitalAntigo.ValorAtual = fundo.ValorAtual;
            fundoCapitalAntigo.ValorNecessario = fundo.ValorNecessario;
            fundoCapitalAntigo.DataResgate = fundo.DataResgate;

            _repositorio.Alterar(fundoCapitalAntigo);

            return Ok();
        }

        [HttpGet("api/v1/fundocapital/{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            var fundoCapital = _repositorio.ObterPorId(id);
            if (fundoCapital == null)
                return NotFound();

            return Ok(fundoCapital);
        }

        [HttpDelete("api/v1/fundocapital/{id}")]
        public IActionResult Remover(Guid id)
        {
            var fundoCapitalAntigo = _repositorio.ObterPorId(id);
            if (fundoCapitalAntigo == null)
                return NotFound();
            
            _repositorio.RemoverFundo(fundoCapitalAntigo);
            return Ok();
        }
    }
}