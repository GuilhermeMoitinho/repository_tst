using Microsoft.AspNetCore.Mvc;
using WebApi_ASPNETCore.Models;
using WebApi_ASPNETCore.Service.FuncionarioService;

namespace WebApi_ASPNETCore.Controllers
{
    [ApiController]
    [Route("api/v1/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioService;

        public FuncionarioController(IFuncionarioInterface funcionarioService)
            => _funcionarioService = funcionarioService;
        
        [HttpGet]
        public async Task<ActionResult>
            GetFuncionarios() =>      
              Ok(await _funcionarioService.GetFuncionarios());

        [ActionName("GetFuncionariosById")]
        [HttpGet("{id}")]
        public async Task<ActionResult>
            GetFuncionariosById(Guid id) =>     
            Ok(await _funcionarioService.GetFuncionariosById(id));
        

        [HttpPost]
        public async Task<ActionResult>
            CreateFuncionarios(FuncionarioModel modelCreate)
        {
            if (modelCreate is null) return BadRequest();
            var response = new ServiceResponse<FuncionarioModel>();
            var dado = await _funcionarioService.CreateFuncionarios(modelCreate);

            response = new ServiceResponse<FuncionarioModel>
            {
                Sucesso = true,
                Mensagem = "Processo tranquilo",
                Dados = dado.Dados
            };

            

            return CreatedAtAction(nameof(GetFuncionariosById), new {Id = modelCreate.Id}, response);
        }       
            
        [HttpPut]
        public async Task<ActionResult>
            UpdateFuncionarios
            (FuncionarioModel modelCreate, Guid id)
        {
            await _funcionarioService.UpdateFuncionarios(modelCreate, id);
            return NoContent();
        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult>
            InativaFuncionario(Guid id)
        {
            await _funcionarioService.InativaFuncionario(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult>
            DeleteFuncionarios(Guid id)
        {
            await _funcionarioService.DeleteFuncionarios(id);
            return NoContent();
        }



    }
}