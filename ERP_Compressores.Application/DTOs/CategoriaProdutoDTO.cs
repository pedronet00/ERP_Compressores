using System.ComponentModel.DataAnnotations;
using ERP_Compressores.Domain.Constants;

namespace ERP_Compressores.Application.DTOs;

public class CategoriaProdutoDTO
{
    
    public int Id { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [MaxLength(100, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string Nome { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public int EmpresaId { get; set; }
}
