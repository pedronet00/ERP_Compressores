using ERP_Compressores.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace ERP_Compressores.Application.DTOs;

public class EmpresaDTO
{

    public int Id { get; set; }

    [Required(ErrorMessage=DataAnnotationMessages.REQUIRED)]
    [StringLength(100, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [EmailAddress(ErrorMessage = DataAnnotationMessages.EMAIL)]
    public string? Email { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [StringLength(14, MinimumLength = 14, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string? Cnpj { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [StringLength(15, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [StringLength(200, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string? Endereco { get; set; }

}
