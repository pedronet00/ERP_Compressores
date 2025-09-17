using AutoMapper;
using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Services;

public class CategoriaProdutoService : ICategoriaProdutoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICategoriaProdutoRepository _repo;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "CATEGORIA_PRODUTO";

    public CategoriaProdutoService(IUnitOfWork unitOfWork, IMapper mapper, ICategoriaProdutoRepository repo, IMemoryCache cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repo = repo;
        _cache = cache;
    }

    public async Task<CategoriaProdutoViewModel> ActivateCategoria(int id)
    {
        var categoria = await _repo.GetCategoriaByIdAsync(id);

        if (categoria is null || categoria.Status == true)
            throw new Exception("Categoria já ativa ou não encontrada.");

        await _repo.ActivateCategoria(categoria);

        await _unitOfWork.Commit();

        return _mapper.Map<CategoriaProdutoViewModel>(categoria);
        
    }

    public async Task<CategoriaProdutoViewModel> AddCategoriaAsync(CategoriaProdutoDTO categoria)
    {
        if(categoria is null)
            throw new Exception("Categoria é necessária.");

        var categoriaEntity = _mapper.Map<Domain.Entities.CategoriaProduto>(categoria);

        var novaCategoria = await _repo.AddCategoriaAsync(categoriaEntity);

        await _unitOfWork.Commit();

        return _mapper.Map<CategoriaProdutoViewModel>(novaCategoria);

    }

    public async Task<CategoriaProdutoViewModel> DeactivateCategoria(int id)
    {
        var categoria = await _repo.GetCategoriaByIdAsync(id);

        if (categoria is null || categoria.Status == false)
            throw new Exception("Categoria já inativa ou não encontrada.");

        await _repo.ActivateCategoria(categoria);

        await _unitOfWork.Commit();

        return _mapper.Map<CategoriaProdutoViewModel>(categoria);
    }

    public async Task<bool> DeleteCategoriaAsync(int id)
    {
        var categoria = await _repo.GetCategoriaByIdAsync(id);

        if (categoria is null)
            throw new Exception("Categoria não encontrada.");

        await _repo.DeleteCategoriaAsync(id);

        await _unitOfWork.Commit();

        return true;
    }

    public async Task<IEnumerable<CategoriaProdutoViewModel>> GetAllCategoriasAsync()
    {
        if (!_cache.TryGetValue(CacheKey, out IEnumerable<CategoriaProdutoViewModel> categorias))
        {
            var entidades = await _repo.GetAllCategoriasAsync();

            if (entidades is not null && entidades.Any())
            {
                categorias = _mapper.Map<IEnumerable<CategoriaProdutoViewModel>>(entidades);

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30),
                    SlidingExpiration = TimeSpan.FromSeconds(15),
                    Priority = CacheItemPriority.High
                };

                _cache.Set(CacheKey, categorias, cacheOptions);
            }
            else
            {
                return Enumerable.Empty<CategoriaProdutoViewModel>();
            }
        }

        return categorias;
    }


    public async Task<CategoriaProdutoViewModel> GetCategoriaByIdAsync(int id)
    {
        var categoria = await _repo.GetCategoriaByIdAsync(id);

        if (categoria is null)
            throw new Exception("Categoria não encontrada.");

        return _mapper.Map<CategoriaProdutoViewModel>(categoria);
    }

    public async Task<CategoriaProdutoViewModel> UpdateCategoriaAsync(CategoriaProdutoDTO categoria)
    {
        if (categoria.Id is <= 0)
            throw new Exception("Categoria inválida."); 

        var categoriaEntity = _mapper.Map<Domain.Entities.CategoriaProduto>(categoria);

        var categoriaAtualizada = await _repo.UpdateCategoriaAsync(categoriaEntity);

        await _unitOfWork.Commit();

        return _mapper.Map<CategoriaProdutoViewModel>(categoriaAtualizada);
    }
}
