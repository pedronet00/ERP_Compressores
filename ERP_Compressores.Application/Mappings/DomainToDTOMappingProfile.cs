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

        CreateMap<Usuarios, UsuarioDTO>().ReverseMap();
        CreateMap<UsuarioDTO, Usuarios>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<Usuarios, UsuarioViewModel>().ReverseMap();

        CreateMap<Fornecedores, FornecedorDTO>().ReverseMap();
        CreateMap<FornecedorDTO, Fornecedores>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<Fornecedores, FornecedorViewModel>().ReverseMap();

        CreateMap<VisitasTecnicas, VisitasTecnicasDTO>().ReverseMap();
        CreateMap<VisitasTecnicasDTO, VisitasTecnicas>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<VisitasTecnicas, VisitasTecnicasViewModel>().ReverseMap();

        CreateMap<CategoriaProduto, CategoriaProdutoDTO>().ReverseMap();
        CreateMap<CategoriaProdutoDTO, CategoriaProduto>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<CategoriaProduto, CategoriaProdutoViewModel>().ReverseMap();

        CreateMap<Produtos, ProdutoDTO>().ReverseMap();
        CreateMap<ProdutoDTO, Produtos>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<Produtos, ProdutoViewModel>().ReverseMap();

        CreateMap<Clientes, ClienteDTO>().ReverseMap();
        CreateMap<ClienteDTO, Clientes>().ForMember(dest => dest.Guid, opt => opt.Ignore());
        CreateMap<Clientes, ClienteViewModel>().ReverseMap();

        CreateMap<Vendas, RegistrarVendaDTO>().ReverseMap();
        CreateMap<Vendas, VendasViewModel>()
            .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.Cliente.Nome))
            .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.ItensVenda));

        CreateMap<ItensVendas, ItemVendaDTO>().ReverseMap();


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
