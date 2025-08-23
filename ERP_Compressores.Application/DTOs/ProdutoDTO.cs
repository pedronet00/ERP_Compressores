using ERP_Compressores.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ERP_Compressores.Domain.Constants;

namespace ERP_Compressores.Application.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [StringLength(100, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string Nome { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [StringLength(255, ErrorMessage = DataAnnotationMessages.STRLENGTH)]
    public string Descricao { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public int CategoriaProdutoId { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    [Range(0.01, 1000000.00, ErrorMessage = DataAnnotationMessages.RANGE)]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public int EmpresaId { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public int QuantidadeEstoque { get; set; }

    [Required(ErrorMessage = DataAnnotationMessages.REQUIRED)]
    public int FornecedorId { get; set; }

}
