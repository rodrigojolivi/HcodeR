namespace HcodeR.Core.Domain.Validations
{
    public class Message
    {
        public const string RegistrationSuccessfullyComplete = "Cadastro efetuado com sucesso !";

        public const string RecordUpdatedSuccessfully = "Registro atualizado com sucesso !";

        public const string RecordDeletedSuccessfully = "Registro excluído com sucesso !";

        public static string NotExist(string value)
        {
            return $"{value} não existe";
        }

        public static string NullOrEmpty(string value)
        {
            return $"{value} não pode ser nulo ou vazio";
        }

        public static string LessThanOrEqualZero(string value)
        {
            return $"{value} não pode ser menor ou igual a zero";
        }

        public static string Custom(string message)
        {
            return $"{message}";
        }
    }
}
