using HcodeR.Application.Dtos.Base;

namespace HcodeR.Application.Dtos.Query
{
    public class ClienteQueryDto : BaseDto
    {
        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}
