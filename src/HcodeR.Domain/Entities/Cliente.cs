using HcodeR.Core.Domain.Entities;
using HcodeR.Core.Domain.Validations;

namespace HcodeR.Domain.Entities
{
    public class Cliente : Entity, IAggregateRoot
    {
        public Cliente(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;

            Validar();
        }

        public string Nome { get; private set; }
        public int Idade { get; private set; }

        private void Validar()
        {
            ValidarNome();
            ValidarIdade();
        }

        private void ValidarNome()
        {
            if (Validate.IsNullOrEmpty(Nome)) throw new DomainException(Message.NullOrEmpty("Nome do cliente"));
        }

        private void ValidarIdade()
        {
            if (Validate.IsLessThanOrEqualZero(Idade)) throw new DomainException(Message.LessThanOrEqualZero("Idade do cliente"));
        }
    }
}
