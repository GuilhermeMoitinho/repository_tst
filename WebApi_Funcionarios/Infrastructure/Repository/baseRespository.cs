using WebApi_ASPNETCore.Infrastructure.DataContext;
using WebApi_ASPNETCore.Domain;
using WebApi_ASPNETCore.Models;

namespace WebApi_ASPNETCore.Infrastructure.Repository
{
    public class baseRespository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public baseRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<FuncionarioModel>> CreateFuncionarios(FuncionarioModel modelCreate)
        {
            ServiceResponse<FuncionarioModel> serviceresponse = new ServiceResponse<FuncionarioModel>();

            try
            {

                if (modelCreate == null)
                {
                    return null;
                }

                await _context.AddAsync(modelCreate);
                await _context.SaveChangesAsync();

                serviceresponse.Mensagem = "Dado criado com sucesso!";

            }
            catch (Exception ex)
            {

                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionarios(Guid id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.Find(id);

                if (funcionario == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Funcionario não foi encontrado!";
                    serviceresponse.Sucesso = false;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceresponse.Dados = _context.Funcionarios.ToList();
                serviceresponse.Mensagem = "Funcionario deletado com sucesso!";


            }
            catch (Exception ex)
            {

                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceresponse.Dados = _context.Funcionarios.ToList();

                if (serviceresponse.Dados.Count == 0)
                {
                    serviceresponse.Mensagem = "Sem dados por enquanto!";
                }
                else
                {
                    serviceresponse.Mensagem = "Processo concluido com sucesso!";
                }

            }
            catch (Exception ex)
            {

                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(Guid id)
        {
            ServiceResponse<FuncionarioModel> serviceresponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.Find(id);

                if (funcionario == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Funcionario não foi encontrado!";
                    serviceresponse.Sucesso = false;
                }

                serviceresponse.Dados = funcionario;
                serviceresponse.Mensagem = "Funcionario encontrado!";

            }
            catch (Exception ex)
            {

                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(Guid id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.Find(id);

                if (funcionario == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Funcionario não foi encontrado!";
                    serviceresponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceresponse.Dados = _context.Funcionarios.ToList();
                serviceresponse.Mensagem = "Funcionario desativado com sucesso!";

            }
            catch (Exception ex)
            {

                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarios(FuncionarioModel modelUpdate, Guid id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.Find(id);

                if (funcionario == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Funcionario não foi encontrado!";
                    serviceresponse.Sucesso = false;
                }

                funcionario.Nome = modelUpdate.Nome;
                funcionario.Sobrenome = modelUpdate.Sobrenome;
                funcionario.Departamento = modelUpdate.Departamento;
                funcionario.Ativo = modelUpdate.Ativo;
                funcionario.Turno = modelUpdate.Turno;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceresponse.Dados = _context.Funcionarios.ToList();
                serviceresponse.Mensagem = "Funcionario atualizado com sucesso!";

            }
            catch (Exception ex)
            {

                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }
    }
}

