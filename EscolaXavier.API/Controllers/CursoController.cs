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
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var resultado = await _cursoService.ObterTodos();
                return Ok(Resultado<List<Curso>>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<List<Curso>>.Erro(e.Message));
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
                var resultado = await _cursoService.ObterPorId(id);
                return Ok(Resultado<Curso>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<Curso>.Erro(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Curso curso)
        {
            try
            {
                var resultado = await _cursoService.Cadastrar(curso);
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
        public async Task<IActionResult> Editar([FromBody] Curso curso)
        {
            try
            {
                var resultado = await _cursoService.Editar(curso);
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
                var resultado = await _cursoService.Excluir(id);
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
