using AutoMapper;
using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Entities;

namespace ERP_Compressores.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        
        CreateMap<Empresas, EmpresaDTO>().ReverseMap();
        CreateMap<EmpresaDTO, Empresas>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<Empresas, EmpresaViewModel>().ReverseMap();

        CreateMap<Fornecedores, FornecedorDTO>().ReverseMap();
        CreateMap<FornecedorDTO, Fornecedores>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<Fornecedores, FornecedorViewModel>().ReverseMap();

        CreateMap<CategoriaProduto, CategoriaProdutoDTO>().ReverseMap();
        CreateMap<CategoriaProdutoDTO, CategoriaProduto>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<CategoriaProduto, CategoriaProdutoViewModel>().ReverseMap();


        //CreateMap<Produtos, ProdutoDTO>();
        //CreateMap<Clientes, ClienteDTO>();
        //CreateMap<Vendas, VendaDTO>();
        //CreateMap<ItensVendas, ItemVendaDTO>();
        //CreateMap<Usuarios, UsuarioDTO>();
        //CreateMap<Orcamentos, OrcamentoDTO>();
        //CreateMap<ItensOrcamento, ItemOrcamentoDTO>();
        //CreateMap<VisitasTecnicas, VisitaTecnicaDTO>();
    }
}
