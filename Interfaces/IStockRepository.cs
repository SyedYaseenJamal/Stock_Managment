using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Dtos.stock;
using webapi.Helpers;
using webapi.models;

namespace webapi.Interfaces
{
    public interface IStockRepository
    {
        Task<List<stock>> GetAllAsync(QueryObject query);
        Task<stock?> GetByIdAsync(int id);
        Task<stock> CreateAsync(stock stockmodel);
        Task<stock> UpdateAsync(int id, stock stockDtos);
        Task<stock> DeleteAsync(int id);
        Task<bool> StockExist(int id);
    }
}