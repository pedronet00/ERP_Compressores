using System.ComponentModel.DataAnnotations;
using ERP_Compressores.Domain.Constants;

namespace ERP_Compressores.Application.DTOs;

public class ClienteDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [MaxLength(100, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [MaxLength(14, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [MaxLength(15, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [EmailAddress(ErrorMessage = DataAnnotationMessages.EMAIL)]
    public string? Email { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [MaxLength(200, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string? Endereco { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public int EmpresaId { get; set; }
}
