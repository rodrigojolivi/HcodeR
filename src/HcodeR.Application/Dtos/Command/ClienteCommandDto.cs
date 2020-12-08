using HcodeR.Application.Attributes;
using HcodeR.Crosscutting.Validations;
using System.ComponentModel.DataAnnotations;

namespace HcodeR.Application.Dtos.Command
{
    public class ClienteCommandDto
    {
        [Required(ErrorMessage = MessageDataAnnotation.NullOrEmpty)]
        [MaxLength(100, ErrorMessage = MessageDataAnnotation.MaxCharacter)]
        public string Nome { get; set; }

        [Required(ErrorMessage = MessageDataAnnotation.NullOrEmpty)]
        [CustomClienteValidation(ErrorMessage = MessageDataAnnotation.LessThanOrEqualZero)]
        public int Idade { get; set; }
    }
}
