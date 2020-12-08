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
            var nome = "Jo�o da Silva";
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
            var nomeValido = "Jo�o da Silva";
            var nomeInvalido = "Jo�o da Silva Jo�o da Silva Jo�o da Silva Jo�o da Silva Jo�o da Silva Jo�o da Silva Jo�o da Silva Jo�";

            var r = nomeInvalido.Length;

            var ex = Assert.Throws<DomainException>(() => new Cliente("", idade));
            Assert.Equal(expected: "Nome do cliente n�o pode ser nulo ou vazio", actual: ex.Message);

            ex = Assert.Throws<DomainException>(() => new Cliente(nomeInvalido, idade));
            Assert.Equal(expected: "Nome do cliente n�o pode ter mais de 100 caracteres", actual: ex.Message);

            ex = Assert.Throws<DomainException>(() => new Cliente(nomeValido, idade));
            Assert.Equal(expected: "Idade do cliente n�o pode ser menor ou igual a zero", actual: ex.Message);
        }
    }
}
