using Escola.Application.Interfaces.Services;
using Escola.Domain;
using Escola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscolaXavier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
    
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var resultado = await _alunoService.ObterTodos();
                return Ok(Resultado<List<Aluno>>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<List<Aluno>>.Erro(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var resultado = await _alunoService.ObterPorId(id);
                return Ok(Resultado<Aluno>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<Aluno>.Erro(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Aluno aluno)
        {
            try
            {
                var resultado = await _alunoService.Cadastrar(aluno);
                return Ok(Resultado<string>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<string>.Erro(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Aluno aluno)
        {
            try
            {
                var resultado = await _alunoService.Editar(aluno);
                return Ok(Resultado<string>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<string>.Erro(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var resultado = await _alunoService.Excluir(id);
                return Ok(Resultado<string>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<string>.Erro(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
