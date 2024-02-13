using WebApi_ASPNETCore.Models;

namespace WebApi_ASPNETCore.Domain
{
    public interface IRepository
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServiceResponse<FuncionarioModel>> CreateFuncionarios(FuncionarioModel modelCreate);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(Guid id);
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarios(FuncionarioModel modelUpdate, Guid id);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionarios(Guid id);
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(Guid id);
    }
}
