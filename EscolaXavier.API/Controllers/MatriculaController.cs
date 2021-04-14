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
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var resultado = await _matriculaService.ObterTodos();
                return Ok(Resultado<List<Matricula>>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<List<Matricula>>.Erro(e.Message));
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
                var resultado = await _matriculaService.ObterPorId(id);
                return Ok(Resultado<Matricula>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<Matricula>.Erro(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Matricula matricula)
        {
            try
            {
                var resultado = await _matriculaService.Cadastrar(matricula);
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
        public async Task<IActionResult> Editar([FromBody] Matricula matricula)
        {
            try
            {
                var resultado = await _matriculaService.Editar(matricula);
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
                var resultado = await _matriculaService.Excluir(id);
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

