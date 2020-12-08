using System;
using System.ComponentModel.DataAnnotations;

namespace HcodeR.Application.Dtos.Base
{
    public class BaseDto
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
