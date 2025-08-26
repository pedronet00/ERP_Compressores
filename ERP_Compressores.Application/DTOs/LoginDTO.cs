using ERP_Compressores.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.DTOs;

public class LoginDTO
{
    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public string? Email { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public string? Password { get; set; }
}
