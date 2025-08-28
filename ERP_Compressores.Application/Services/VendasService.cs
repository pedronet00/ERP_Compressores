using AutoMapper;
using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Services
{
    public class VendasService : IVendasService
    {
        private readonly IVendasRepository _vendasRepository;
        private readonly IItensVendasRepository _itensRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VendasService(
            IVendasRepository vendasRepository,
            IItensVendasRepository itensRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper) // injetar AutoMapper
        {
            _vendasRepository = vendasRepository;
            _itensRepository = itensRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VendasViewModel> RegistrarVendaAsync(RegistrarVendaDTO dto)
        {
            var valorOriginal = dto.Itens.Sum(i => i.Quantidade * i.ValorUnitario);
            var valorTotal = valorOriginal - (valorOriginal * dto.DescontoPercentual / 100);

            var venda = new Vendas(
                dto.ClienteId,
                DateTime.Now,
                valorTotal,
                dto.Descricao,
                dto.EmpresaId,
                valorOriginal,
                dto.DescontoPercentual
            );

            await _vendasRepository.AdicionarAsync(venda);
            await _unitOfWork.Commit();

            var itens = dto.Itens.Select(i =>
                new ItensVendas(i.ProdutoId, i.Quantidade, i.ValorUnitario, venda.Id)
            ).ToList();

            foreach (var item in itens)
                await _itensRepository.AdicionarAsync(item);

            await _unitOfWork.Commit();

            // Mapear para ViewModel antes de retornar
            return _mapper.Map<VendasViewModel>(venda);
        }

        public async Task<VendasViewModel?> ObterVendaAsync(int id)
        {
            var venda = await _vendasRepository.ObterPorIdAsync(id);
            if (venda == null) return null;

            return _mapper.Map<VendasViewModel>(venda);
        }

        public async Task<IEnumerable<VendasViewModel>> ListarVendasAsync()
        {
            var vendas = await _vendasRepository.ListarAsync();
            return _mapper.Map<IEnumerable<VendasViewModel>>(vendas);
        }

        public async Task<int> CountVendas()
        {
            return await _vendasRepository.CountVendas();
        }

        public async Task<List<VendasPorMesViewModel>> ObterVendasAgrupadasPorMesAsync()
        {
            var vendas = await _vendasRepository.ListarAsync();

            var agrupadas = vendas
                .GroupBy(v => new { v.DataVenda.Year, v.DataVenda.Month })
                .Select(g => new VendasPorMesViewModel
                {
                    Ano = g.Key.Year,
                    Mes = g.Key.Month,
                    TotalVendas = g.Count(),
                    ValorTotal = g.Sum(x => x.ValorTotal)
                })
                .OrderBy(v => v.Ano)
                .ThenBy(v => v.Mes)
                .ToList();

            return agrupadas;
        }
    }
}
