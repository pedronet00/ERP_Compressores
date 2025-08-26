using ERP_Compressores.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.DTOs;

public class RegisterDTO
{
    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public string? UserName { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public string? Email { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public string? Password { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public string? Role { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public string? Phone { get; set; }

    public bool Status { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public int EmpresaId { get; set; }
}
