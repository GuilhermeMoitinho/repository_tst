using WebApi_ASPNETCore.Domain;
using WebApi_ASPNETCore.Models;

namespace WebApi_ASPNETCore.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly IRepository _repository;

        public FuncionarioService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<ServiceResponse<FuncionarioModel>> CreateFuncionarios(FuncionarioModel modelCreate)
        {
            if (modelCreate is null) return null;

            var response = _repository.CreateFuncionarios(modelCreate);

            return response;
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionarios(Guid id)
        {
            if (id == Guid.Empty) return null;

            var response = _repository.DeleteFuncionarios(id);

            return response;
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            var response = _repository.GetFuncionarios();

            return response;
        }

        public Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(Guid id)
        {
            if (id == Guid.Empty) return null;

            var response = _repository.GetFuncionariosById(id);

            return response;
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(Guid id)
        {
            if (id == Guid.Empty) return null;

            var response = _repository.InativaFuncionario(id);

            return response;
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarios(FuncionarioModel modelUpdate, Guid id)
        {
            if (modelUpdate is null || id == null) return null;

            var response = _repository.UpdateFuncionarios(modelUpdate, id);

            return response;
        }
    }
}