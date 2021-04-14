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
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;

        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var resultado = await _materiaService.ObterTodos();
                return Ok(Resultado<List<Materia>>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<List<Materia>>.Erro(e.Message));
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
                var resultado = await _materiaService.ObterPorId(id);
                return Ok(Resultado<Materia>.OK(resultado));
            }
            catch (ValidacaoException e)
            {
                return Ok(Resultado<Materia>.Erro(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Materia materia)
        {
            try
            {
                var resultado = await _materiaService.Cadastrar(materia);
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
        public async Task<IActionResult> Editar([FromBody] Materia materia)
        {
            try
            {
                var resultado = await _materiaService.Editar(materia);
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
                var resultado = await _materiaService.Excluir(id);
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

