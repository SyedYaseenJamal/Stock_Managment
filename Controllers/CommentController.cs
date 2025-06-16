using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos.Comment;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.models;

namespace webapi.Controllers
{   
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IStockRepository _StockRepo;
        private readonly ICommentRepository _CommentRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _CommentRepo = commentRepo;
            _StockRepo = stockRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Comments = await _CommentRepo.GetAllAsync();
            var CommentDto = Comments.Select(s=>s.ToCommentDto());
            return Ok(CommentDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _CommentRepo.GetByIdAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{StockId}")]
        public async Task<IActionResult> Create([FromRoute] int StockId, CreateCommentrequest CreateDto)
        {
            if(!await _StockRepo.StockExist(StockId))
            {
                return BadRequest("Stock does Not Exist");
            }
            var CommentModel = CreateDto.ToCommentFromCreate(StockId);
            await _CommentRepo.CreateAsync(CommentModel);
            Console.WriteLine("xyz");
            return CreatedAtAction(nameof(GetById), new { id = CommentModel.Id}, CommentModel.ToCommentDto());

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto UpdateDto)
        {
            var comment = await _CommentRepo.UpdateAsync(id, UpdateDto.ToCommentFromUpdate());
            if(comment == null)
            {
               return NotFound("Comment Not Found");
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var commentModel = await _CommentRepo.DeleteAsync(id);
            if(commentModel == null)
            {
                return NotFound("Comment Does not Exist");
            }
            return Ok(commentModel);
        }
    }   
}