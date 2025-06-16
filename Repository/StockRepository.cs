using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos.stock;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.models;

namespace webapi.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<stock> CreateAsync(stock stockmodel)
        {
            await _context.Stock.AddAsync(stockmodel);
            await _context.SaveChangesAsync();
            return stockmodel;
        }

        public async Task<stock> DeleteAsync(int id)
        {
            var stockmodel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(stockmodel == null)
            {
                return null;
            }
            _context.Stock.Remove(stockmodel);
            await _context.SaveChangesAsync();
            return stockmodel;
        }

        public async Task<List<stock>> GetAllAsync()
        {
            return await _context.Stock.Include(c=> c.Comments).ToListAsync();
        }

        public async Task<stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.Include(c=> c.Comments).FirstOrDefaultAsync(i=> i.Id == id);
          
        }

        public Task<bool> StockExist(int id)
        {
            Console.WriteLine("jabbbba");
            return _context.Stock.AnyAsync(x => x.Id == id);
        }

        public async Task<stock> UpdateAsync(int id, stock stockmodel1)
        {
            var StockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(StockModel == null)
            {
                return null;
            }
            
            StockModel.Symbol = stockmodel1.Symbol;
            StockModel.Purchase = stockmodel1.Purchase;
            StockModel.LastDiv = stockmodel1.LastDiv;
            StockModel.Industry = stockmodel1.Industry;
            await _context.SaveChangesAsync();
            return StockModel;
        }
    }
}