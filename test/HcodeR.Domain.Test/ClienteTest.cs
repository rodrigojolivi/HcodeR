using HcodeR.Core.Domain.Validations;
using HcodeR.Domain.Entities;
using System;
using Xunit;

namespace HcodeR.Domain.Test
{
    public class ClienteTest
    {
        [Trait("Cliente", "Construtor")]
        [Fact(DisplayName = "Validar construtor retorna sucesso")]
        public void Validar_Construtor_Retorna_Sucesso()
        {
            var nome = "João da Silva";
            var idade = 25;

            var cliente = new Cliente(nome, idade);

            Assert.IsType<Guid>(cliente.Id);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(idade, cliente.Idade);
            Assert.IsType<DateTime>(cliente.CreatedAt);
            Assert.IsType<DateTime>(cliente.UpdatedAt);
        }

        [Trait("Cliente", "Construtor")]
        [Fact(DisplayName = "Validar construtor retorna erro")]
        public void Validar_Construtor_Retorna_Erro()
        {
            var idade = 0;
            var nomeValido = "João da Silva";
            var nomeInvalido = "João da Silva João da Silva João da Silva João da Silva João da Silva João da Silva João da Silva Joã";

            var r = nomeInvalido.Length;

            var ex = Assert.Throws<DomainException>(() => new Cliente("", idade));
            Assert.Equal(expected: "Nome do cliente não pode ser nulo ou vazio", actual: ex.Message);

            ex = Assert.Throws<DomainException>(() => new Cliente(nomeInvalido, idade));
            Assert.Equal(expected: "Nome do cliente não pode ter mais de 100 caracteres", actual: ex.Message);

            ex = Assert.Throws<DomainException>(() => new Cliente(nomeValido, idade));
            Assert.Equal(expected: "Idade do cliente não pode ser menor ou igual a zero", actual: ex.Message);
        }
    }
}
