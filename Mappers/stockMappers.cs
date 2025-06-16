using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Dtos.stock;
using webapi.models;

namespace webapi.Mappers
{
    public static  class stockMappers
    {
        public static stockDtos ToStockDto(this stock stockModel)
        {
            return new stockDtos
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName =  stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(x => x.ToCommentDto()).ToList(),
            };
        }

        public static stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        {
            return new stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,
            };
        }
        public static stock ToStockFromUpdateDto(this UpdateStockDtos stockDto)
        {
            return new stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,
            };
        }
    }
}