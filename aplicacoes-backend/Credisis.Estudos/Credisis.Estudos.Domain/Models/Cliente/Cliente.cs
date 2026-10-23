using Credisis.Estudos.Domain.Common;

namespace Credisis.Estudos.Domain.Models.Cliente
{
    public class Cliente : BaseEntity
    {
        public Cliente() {}

        public Cliente(string nome, string email)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(nome));
            if(string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email não pode ser nulo ou vazio.", nameof(email));
            Nome = nome;
            Email = email;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
