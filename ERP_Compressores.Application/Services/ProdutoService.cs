using AutoMapper;
using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IProdutoRepository _repo;

    public ProdutoService(IUnitOfWork unitOfWork, IMapper mapper, IProdutoRepository repo)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ProdutoViewModel> ActivateProduto(int id)
    {
        var produto = await _repo.GetProdutoByIdAsync(id);

        if (produto.Status is true)
            throw new Exception("Produto já ativo ou não encontrado.");

        await _repo.ActivateProduto(produto);

        await _unitOfWork.Commit();

        return _mapper.Map<ProdutoViewModel>(produto);
    }

    public async Task<ProdutoViewModel> AddProdutoAsync(ProdutoDTO produto)
    {
        if (produto is null)
            throw new Exception("Produto é necessário.");

        var produtoEntity = _mapper.Map<Produtos>(produto);

        var novoProduto = await _repo.AddProdutoAsync(produtoEntity);

        await _unitOfWork.Commit();

        return _mapper.Map<ProdutoViewModel>(novoProduto);
    }

    public async Task<ProdutoViewModel> DeactivateProduto(int id)
    {
        var produto = await _repo.GetProdutoByIdAsync(id);

        if (produto.Status is false)
            throw new Exception("Produto já inativo ou não encontrado.");

        await _repo.DeactivateProduto(produto);

        await _unitOfWork.Commit();

        return _mapper.Map<ProdutoViewModel>(produto);
    }

    public async Task<bool> DeleteProdutoAsync(int id)
    {
        var produto = await _repo.GetProdutoByIdAsync(id);

        if (produto is null)
            throw new Exception("Produto não encontrado.");

        var result = await _repo.DeleteProdutoAsync(id);

        if (result)
            await _unitOfWork.Commit();

        return result;
    }

    public async Task<IEnumerable<ProdutoViewModel>> GetAllProdutosAsync()
    {
        var produtos = await _repo.GetAllProdutosAsync();

        return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
    }

    public async Task<ProdutoViewModel> GetProdutoByIdAsync(int id)
    {
        var produto = await _repo.GetProdutoByIdAsync(id);

        if (produto is null)
            throw new Exception("Produto não encontrado.");

        return _mapper.Map<ProdutoViewModel>(produto);
    }

    public async Task<ProdutoViewModel> UpdateProdutoAsync(ProdutoDTO produto)
    {
        if(produto.Id is <= 0)
            throw new Exception("Id inválido.");

        var produtoEntity = _mapper.Map<Produtos>(produto);

        var produtoAtualizado = await _repo.UpdateProdutoAsync(produtoEntity);

        await _unitOfWork.Commit();

        return _mapper.Map<ProdutoViewModel>(produtoAtualizado);

    }
}
