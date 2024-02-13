using WebApi_ASPNETCore.Domain.Base;
using WebApi_ASPNETCore.Enums;

namespace WebApi_ASPNETCore.Models
{
    public class FuncionarioModel : baseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; }  = DateTime.Now.ToLocalTime();
    }
}