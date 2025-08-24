using ERP_Compressores.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ERP_Compressores.Domain.Constants;

namespace ERP_Compressores.Application.DTOs;

public class FornecedorDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage=DataAnnotationMessages.REQUIRED)]
    [StringLength(100, ErrorMessage=DataAnnotationMessages.STRLENGTH)]
    public string? Nome { get; set; }

    [Required(ErrorMessage=DataAnnotationMessages.REQUIRED)]
    [StringLength(14, ErrorMessage=DataAnnotationMessages.STRLENGTH)]
    public string? Cnpj { get; set; }

    [Required(ErrorMessage=DataAnnotationMessages.REQUIRED)]
    [StringLength(15, ErrorMessage=DataAnnotationMessages.STRLENGTH)]
    public string? Telefone { get; set; }

    [Required(ErrorMessage=DataAnnotationMessages.REQUIRED)]
    [StringLength(100, ErrorMessage=DataAnnotationMessages.STRLENGTH)]
    [EmailAddress(ErrorMessage=DataAnnotationMessages.EMAIL)]
    public string? Email { get; set; }

    [Required(ErrorMessage=DataAnnotationMessages.REQUIRED)]
    [StringLength(200, ErrorMessage=DataAnnotationMessages.STRLENGTH)]
    public string? Endereco { get; set; }

    [Required(ErrorMessage=DataAnnotationMessages.REQUIRED)]
    public int EmpresaId { get; set; }
}
