using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos.stock;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class stockController : ControllerBase
    {
        private readonly IStockRepository _StockRepo;
        private readonly ApplicationDBContext _context;
        public stockController(ApplicationDBContext context,IStockRepository StockRepo)
        {
            _context = context;
            _StockRepo = StockRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stock = await _StockRepo.GetAllAsync();
            var StockDto = stock.Select(s=>s.ToStockDto());
            return Ok(stock);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _StockRepo.GetByIdAsync(id); //_context.Stock.FindAsync(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto CreateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var StockModel = CreateDto.ToStockFromCreateDto();
            await _StockRepo.CreateAsync(StockModel);
            //await _context.Stock.AddAsync(StockModel);
            //await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = StockModel.Id}, StockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateStockDtos updateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StockModel = updateDto.ToStockFromUpdateDto();
            var UpdatedStockModel = await _StockRepo.UpdateAsync(id,StockModel);
            Console.WriteLine(id);                     //_context.Stock.FirstOrDefaultAsync(x => x.Id== id);
            if(StockModel == null)
            {
                return NotFound();
            }
            //StockModel.Symbol = updateDto.Symbol;
            //StockModel.Purchase = updateDto.Purchase;
            //StockModel.LastDiv = updateDto.LastDiv;
            //StockModel.Industry = updateDto.Industry;
            //StockModel.MarketCap = updateDto.MarketCap;
            //await _context.SaveChangesAsync();
            return Ok(UpdatedStockModel.ToStockDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StockModel = await _StockRepo.DeleteAsync(id);//_context.Stock.FirstOrDefault(x => x.Id == id);
            if(StockModel == null)
            {
                return NotFound();
            }
            else
            {
                //_context.Stock.Remove(StockModel);
                //await _context.SaveChangesAsync();
                return NoContent();
            }
            
        }
    }
}